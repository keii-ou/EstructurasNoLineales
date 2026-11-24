using System.ComponentModel;
using System.Drawing.Drawing2D;
using EstructurasNoLineales.Modelos;

namespace EstructurasNoLineales.Controles;


//Panel con doble búfer que dibuja un Árbol Binario de Búsqueda.
//La posición horizontal de cada nodo es su posición en el recorrido inorden y la vertical es su nivel. 
//Los nodos resaltados se pintan en naranja

public class PanelArbol : Panel
{
    private const int Radio = 18;
    private const int SepX = 44;
    private const int SepY = 62;
    private const int Margen = 30;

    private ArbolBinarioBusqueda? _arbol;
    private readonly HashSet<int> _resaltados = new();

    public PanelArbol()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        AutoScroll = true;
        BackColor = Color.White;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ArbolBinarioBusqueda? Arbol
    {
        get => _arbol;
        set
        {
            _arbol = value;
            Actualizar();
        }
    }

    //Marca los valores indicados (por ejemplo, el camino de una búsqueda)
    public void Resaltar(IEnumerable<int> valores)
    {
        _resaltados.Clear();
        foreach (int v in valores)
            _resaltados.Add(v);
        Invalidate();
    }

    //Recalcula el tamaño de desplazamiento y vuelve a dibujar
    public void Actualizar()
    {
        if (_arbol == null || _arbol.Raiz == null)
            AutoScrollMinSize = Size.Empty;
        else
            AutoScrollMinSize = new Size(
                _arbol.Cantidad * SepX + 2 * Margen,
                _arbol.Altura() * SepY + 2 * Margen);

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        ArbolBinarioBusqueda? arbol = _arbol;
        if (arbol == null || arbol.Raiz == null)
        {
            g.DrawString("El árbol está vacío. Inserta un valor para comenzar.",
                Font, Brushes.Gray, 20, 20);
            return;
        }

        g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

        // 1) Asignar columna y nivel a cada nodo con un recorrido inorden
        var celdas = new Dictionary<NodoABB, (int Columna, int Nivel)>();
        int columna = 0;
        Distribuir(arbol.Raiz, 0, ref columna, celdas);

        // 2) Convertir a coordenadas
        int anchoArbol = arbol.Cantidad * SepX;
        int desplazamientoX = Math.Max(Margen, (ClientSize.Width - anchoArbol) / 2);

        var puntos = new Dictionary<NodoABB, Point>();
        foreach (var (nodo, celda) in celdas)
        {
            puntos[nodo] = new Point(
                desplazamientoX + celda.Columna * SepX + SepX / 2,
                Margen + celda.Nivel * SepY + Radio);
        }

        // 3) Dibujar las aristas
        using (var lapiz = new Pen(Color.DimGray, 2f))
        {
            foreach (var (nodo, punto) in puntos)
            {
                if (nodo.Izquierdo != null)
                    g.DrawLine(lapiz, punto, puntos[nodo.Izquierdo]);
                if (nodo.Derecho != null)
                    g.DrawLine(lapiz, punto, puntos[nodo.Derecho]);
            }
        }

        // 4) Dibujar los nodos
        using var borde = new Pen(Color.DarkSlateBlue, 2f);
        using var formato = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        foreach (var (nodo, punto) in puntos)
        {
            var rect = new Rectangle(punto.X - Radio, punto.Y - Radio, Radio * 2, Radio * 2);
            Color relleno = _resaltados.Contains(nodo.Valor) ? Color.Orange : Color.LightSkyBlue;

            using (var pincel = new SolidBrush(relleno))
                g.FillEllipse(pincel, rect);

            g.DrawEllipse(borde, rect);
            g.DrawString(nodo.Valor.ToString(), Font, Brushes.Black, rect, formato);
        }
    }

    private static void Distribuir(NodoABB? nodo, int nivel, ref int columna,
        Dictionary<NodoABB, (int Columna, int Nivel)> celdas)
    {
        if (nodo == null) return;

        Distribuir(nodo.Izquierdo, nivel + 1, ref columna, celdas);
        celdas[nodo] = (columna, nivel);
        columna++;
        Distribuir(nodo.Derecho, nivel + 1, ref columna, celdas);
    }
}
