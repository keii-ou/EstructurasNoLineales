using System.ComponentModel;
using System.Drawing.Drawing2D;
using EstructurasNoLineales.Modelos;

namespace EstructurasNoLineales.Controles;

//Panel con doble búfer que dibuja un grafo ponderado con los vértices en círculo.
//Las aristas simétricas se dibujan como línea simple; las asimétricas, como flechas.
//El camino indicado (por ejemplo, el resultado de Dijkstra) se resalta en rojo/naranja.

public class PanelGrafo : Panel
{
    private const float Radio = 16f;

    private Grafo? _grafo;
    private List<string> _camino = new();

    public PanelGrafo()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BackColor = Color.White;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Grafo? Grafo
    {
        get => _grafo;
        set
        {
            _grafo = value;
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReadOnlyList<string>? Camino
    {
        get => _camino;
        set
        {
            _camino = value == null ? new List<string>() : new List<string>(value);
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Grafo? grafo = _grafo;
        if (grafo == null || grafo.Vertices.Count == 0)
        {
            g.DrawString("El grafo está vacío. Agrega vértices o carga el ejemplo.",
                Font, Brushes.Gray, 20, 20);
            return;
        }

        Dictionary<string, PointF> posiciones = CalcularPosiciones(grafo);

        // 1) Aristas (primero, para que los vértices queden encima)
        foreach (var (a, b, peso) in grafo.Arcos())
        {
            bool hayVuelta = grafo.TryObtenerPeso(b, a, out double pesoVuelta);
            bool simetrica = hayVuelta && Math.Abs(pesoVuelta - peso) < 1e-9;

            // En una arista simétrica solo se dibuja una vez
            if (simetrica && string.CompareOrdinal(a, b) > 0)
                continue;

            bool resaltada = EnCamino(a, b) || (simetrica && EnCamino(b, a));
            DibujarArista(g, posiciones[a], posiciones[b], peso,
                conFlecha: !simetrica,
                desplazar: hayVuelta && !simetrica,
                resaltada: resaltada);
        }

        // 2) Vértices y sus nombres
        using var borde = new Pen(Color.DarkSlateBlue, 2f);
        using var formatoNombre = new StringFormat { Alignment = StringAlignment.Center };
        using var fuenteNombre = new Font(Font, FontStyle.Bold);

        foreach (string nombre in grafo.Vertices)
        {
            PointF p = posiciones[nombre];
            var rect = new RectangleF(p.X - Radio, p.Y - Radio, Radio * 2, Radio * 2);
            Color relleno = _camino.Contains(nombre) ? Color.Orange : Color.LightSkyBlue;

            using (var pincel = new SolidBrush(relleno))
                g.FillEllipse(pincel, rect);

            g.DrawEllipse(borde, rect);
            g.DrawString(nombre, fuenteNombre, Brushes.Black, p.X, p.Y + Radio + 2, formatoNombre);
        }
    }

    private Dictionary<string, PointF> CalcularPosiciones(Grafo grafo)
    {
        int n = grafo.Vertices.Count;
        float cx = ClientSize.Width / 2f;
        float cy = ClientSize.Height / 2f - 10f;
        float r = Math.Max(40f, Math.Min(ClientSize.Width / 2f - 80f, ClientSize.Height / 2f - 50f));

        var resultado = new Dictionary<string, PointF>();
        for (int i = 0; i < n; i++)
        {
            if (n == 1)
            {
                resultado[grafo.Vertices[i]] = new PointF(cx, cy);
                continue;
            }

            double angulo = 2 * Math.PI * i / n - Math.PI / 2;
            resultado[grafo.Vertices[i]] = new PointF(
                cx + r * (float)Math.Cos(angulo),
                cy + r * (float)Math.Sin(angulo));
        }
        return resultado;
    }

    private bool EnCamino(string a, string b)
    {
        for (int i = 0; i < _camino.Count - 1; i++)
            if (_camino[i] == a && _camino[i + 1] == b)
                return true;
        return false;
    }

    private void DibujarArista(Graphics g, PointF a, PointF b, double peso,
        bool conFlecha, bool desplazar, bool resaltada)
    {
        float dx = b.X - a.X;
        float dy = b.Y - a.Y;
        float largo = (float)Math.Sqrt(dx * dx + dy * dy);
        if (largo < 1f) return;

        float ux = dx / largo, uy = dy / largo;   // vector unitario
        float nx = -uy, ny = ux;                  // normal
        float desfase = desplazar ? 8f : 0f;

        var p1 = new PointF(a.X + nx * desfase + ux * Radio, a.Y + ny * desfase + uy * Radio);
        var p2 = new PointF(b.X + nx * desfase - ux * Radio, b.Y + ny * desfase - uy * Radio);

        Color color = resaltada ? Color.OrangeRed : Color.DimGray;
        using (var lapiz = new Pen(color, resaltada ? 4f : 2f))
        {
            if (conFlecha)
                lapiz.CustomEndCap = new AdjustableArrowCap(4f, 5f, true);
            g.DrawLine(lapiz, p1, p2);
        }

        // Etiqueta con el peso, al centro de la arista
        string texto = Modelos.Grafo.Formato(peso);
        SizeF tam = g.MeasureString(texto, Font);
        float mx = (p1.X + p2.X) / 2f;
        float my = (p1.Y + p2.Y) / 2f;
        var fondo = new RectangleF(mx - tam.Width / 2f, my - tam.Height / 2f, tam.Width, tam.Height);

        g.FillRectangle(Brushes.White, fondo);
        g.DrawString(texto, Font, resaltada ? Brushes.OrangeRed : Brushes.Black, fondo.Location);
    }
}
