using System.Text;
using EstructurasNoLineales.Modelos;
using EstructurasNoLineales.Pruebas;

namespace EstructurasNoLineales;

//Formulario principal. Toda la interfaz (controles, posiciones, textos) está definida en FormPrincipal.Designer.cs; aquí solo vive la lógica de los eventos.

public partial class FormPrincipal : Form
{
    private readonly ArbolBinarioBusqueda _arbol = new();
    private readonly Grafo _grafo = new();
    private string _ultimoReporte = string.Empty;

    public FormPrincipal()
    {
        InitializeComponent();
        panelArbol.Arbol = _arbol;
        panelGrafo.Grafo = _grafo;
    }

    private void FormPrincipal_Load(object? sender, EventArgs e)
    {
        ActualizarEstadisticasArbol();
        RefrescarGrafo();
        txtSalidaABB.Text = "Bienvenido. Inserta valores enteros o pulsa \"Cargar árbol de ejemplo\"."
                            + Environment.NewLine;
        txtValor.Focus();
    }

    
    //  PESTAÑA 1: ÁRBOL BINARIO DE BÚSQUEDA
   

    private bool TryLeerValor(out int valor)
    {
        if (int.TryParse(txtValor.Text.Trim(), out valor))
            return true;

        MessageBox.Show("Escribe un número entero válido.", "Valor inválido",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtValor.Focus();
        txtValor.SelectAll();
        return false;
    }

    private void Registrar(string mensaje)
    {
        txtSalidaABB.AppendText(mensaje + Environment.NewLine);
    }

    private void ActualizarEstadisticasArbol()
    {
        string minimo = _arbol.Minimo()?.ToString() ?? "-";
        string maximo = _arbol.Maximo()?.ToString() ?? "-";

        lblEstadisticas.Text =
            $"Nodos: {_arbol.Cantidad}  |  Altura: {_arbol.Altura()} niveles{Environment.NewLine}" +
            $"Mínimo: {minimo}  |  Máximo: {maximo}";

        panelArbol.Actualizar();
    }

    private void btnInsertar_Click(object? sender, EventArgs e)
    {
        if (!TryLeerValor(out int valor))
            return;

        if (_arbol.Insertar(valor))
        {
            Registrar($"Insertado: {valor}");
            panelArbol.Resaltar(new[] { valor });
        }
        else
        {
            Registrar($"El valor {valor} ya existe; no se permiten duplicados.");
            panelArbol.Resaltar(new[] { valor });
        }

        ActualizarEstadisticasArbol();
        txtValor.Clear();
        txtValor.Focus();
    }

    private void btnBuscar_Click(object? sender, EventArgs e)
    {
        if (!TryLeerValor(out int valor))
            return;

        var camino = new List<int>();
        NodoABB? nodo = _arbol.Buscar(valor, camino);

        panelArbol.Resaltar(camino);
        string ruta = camino.Count == 0 ? "(árbol vacío)" : string.Join(" → ", camino);

        Registrar(nodo != null
            ? $"Búsqueda de {valor}: ENCONTRADO. Camino: {ruta}"
            : $"Búsqueda de {valor}: NO encontrado. Camino recorrido: {ruta}");

        txtValor.Focus();
        txtValor.SelectAll();
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (!TryLeerValor(out int valor))
            return;

        panelArbol.Resaltar(Array.Empty<int>());

        if (_arbol.Eliminar(valor))
            Registrar($"Eliminado: {valor}");
        else
            Registrar($"No se pudo eliminar {valor}: no existe en el árbol.");

        ActualizarEstadisticasArbol();
        txtValor.Clear();
        txtValor.Focus();
    }

    private void btnLimpiarArbol_Click(object? sender, EventArgs e)
    {
        _arbol.Limpiar();
        panelArbol.Resaltar(Array.Empty<int>());
        ActualizarEstadisticasArbol();
        Registrar("Árbol vaciado.");
    }

    private void MostrarRecorrido(string nombre, List<int> valores)
    {
        panelArbol.Resaltar(Array.Empty<int>());

        if (valores.Count == 0)
            Registrar($"{nombre}: el árbol está vacío.");
        else
            Registrar($"{nombre}: {string.Join(", ", valores)}");
    }

    private void btnPreorden_Click(object? sender, EventArgs e) =>
        MostrarRecorrido("Preorden (raíz, izq, der)", _arbol.Preorden());

    private void btnInorden_Click(object? sender, EventArgs e) =>
        MostrarRecorrido("Inorden (izq, raíz, der)", _arbol.Inorden());

    private void btnPostorden_Click(object? sender, EventArgs e) =>
        MostrarRecorrido("Postorden (izq, der, raíz)", _arbol.Postorden());

    private void btnCargarEjemplo_Click(object? sender, EventArgs e)
    {
        _arbol.Limpiar();
        foreach (int v in new[] { 50, 30, 70, 20, 40, 60, 80, 10, 35, 65 })
            _arbol.Insertar(v);

        panelArbol.Resaltar(Array.Empty<int>());
        ActualizarEstadisticasArbol();
        Registrar("Árbol de ejemplo cargado: 50, 30, 70, 20, 40, 60, 80, 10, 35, 65");
    }

    private void btnPruebas_Click(object? sender, EventArgs e)
    {
        ReportePruebas reporte = PruebasABB.Ejecutar();
        _ultimoReporte = reporte.Texto;
        txtSalidaABB.Text = reporte.Texto;
        txtSalidaABB.SelectionStart = 0;
        txtSalidaABB.ScrollToCaret();
    }

    private void btnGuardarReporte_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_ultimoReporte))
            _ultimoReporte = PruebasABB.Ejecutar().Texto;

        if (saveFileDialogReporte.ShowDialog(this) != DialogResult.OK)
            return;

        File.WriteAllText(saveFileDialogReporte.FileName, _ultimoReporte, Encoding.UTF8);
        MessageBox.Show("Reporte guardado correctamente.", "Reporte",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void txtValor_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;   // evita el "beep" de Windows
            btnInsertar.PerformClick();
        }
    }

   
    //  PESTAÑA 2: GRAFOS Y DIJKSTRA
    

    /// Vuelve a llenar combos, matriz, lista y dibujo a partir del grafo.
    private void RefrescarGrafo()
    {
        foreach (ComboBox combo in new[] { cmbOrigen, cmbDestino, cmbDesde, cmbHasta })
        {
            object? anterior = combo.SelectedItem;
            combo.Items.Clear();
            foreach (string vertice in _grafo.Vertices)
                combo.Items.Add(vertice);

            if (anterior != null && combo.Items.Contains(anterior))
                combo.SelectedItem = anterior;
            else if (combo.Items.Count > 0)
                combo.SelectedIndex = 0;
        }

        // Matriz de adyacencia en el DataGridView
        dgvMatriz.Rows.Clear();
        dgvMatriz.Columns.Clear();

        IReadOnlyList<string> vertices = _grafo.Vertices;
        double[,] matriz = _grafo.MatrizAdyacencia();

        for (int j = 0; j < vertices.Count; j++)
        {
            int indiceColumna = dgvMatriz.Columns.Add("col" + j, vertices[j]);
            dgvMatriz.Columns[indiceColumna].Width = 85;
            dgvMatriz.Columns[indiceColumna].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        for (int i = 0; i < vertices.Count; i++)
        {
            int indiceFila = dgvMatriz.Rows.Add();
            DataGridViewRow fila = dgvMatriz.Rows[indiceFila];
            fila.HeaderCell.Value = vertices[i];

            for (int j = 0; j < vertices.Count; j++)
                fila.Cells[j].Value = Grafo.Formato(matriz[i, j]);
        }

        // Lista de adyacencia
        var sb = new StringBuilder();
        foreach (string vertice in vertices)
        {
            sb.Append(vertice).Append(" → ");
            var vecinos = _grafo.Vecinos(vertice);

            if (vecinos.Count == 0)
                sb.Append("(sin vecinos)");
            else
                sb.Append(string.Join(" → ", vecinos.Select(v => $"[{v.Destino}, {Grafo.Formato(v.Peso)}]")));

            sb.AppendLine();
        }
        txtLista.Text = sb.ToString();

        panelGrafo.Camino = null;
        panelGrafo.Invalidate();
    }

    private void btnAgregarVertice_Click(object? sender, EventArgs e)
    {
        string nombre = txtVertice.Text.Trim();
        if (nombre.Length == 0)
        {
            MessageBox.Show("Escribe el nombre del vértice.", "Vértice vacío",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!_grafo.AgregarVertice(nombre))
        {
            MessageBox.Show($"El vértice \"{nombre}\" ya existe.", "Vértice duplicado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        txtVertice.Clear();
        txtVertice.Focus();
        RefrescarGrafo();
    }

    private void txtVertice_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnAgregarVertice.PerformClick();
        }
    }

    private void btnAgregarArista_Click(object? sender, EventArgs e)
    {
        if (cmbOrigen.SelectedItem is not string origen || cmbDestino.SelectedItem is not string destino)
        {
            MessageBox.Show("Primero agrega vértices y elige origen y destino.", "Faltan datos",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (origen == destino)
        {
            MessageBox.Show("El origen y el destino deben ser distintos.", "Arista inválida",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _grafo.AgregarArista(origen, destino, (double)numPeso.Value, chkBidireccional.Checked);
        RefrescarGrafo();
    }

    private void btnDijkstra_Click(object? sender, EventArgs e)
    {
        if (cmbDesde.SelectedItem is not string origen || cmbHasta.SelectedItem is not string destino)
        {
            MessageBox.Show("Elige el vértice de origen y el de destino.", "Faltan datos",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        ResultadoDijkstra resultado = _grafo.Dijkstra(origen, destino);
        txtTraza.Text = string.Join(Environment.NewLine, resultado.Traza);
        panelGrafo.Camino = resultado.Camino;
    }

    private void MostrarRecorridoGrafo(string nombre, Func<string, List<string>> recorrido)
    {
        if (cmbDesde.SelectedItem is not string inicio)
        {
            MessageBox.Show("Elige el vértice inicial en el combo \"Desde\".", "Faltan datos",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        List<string> orden = recorrido(inicio);
        txtTraza.Text = $"{nombre} desde {inicio}:{Environment.NewLine}{string.Join(" → ", orden)}";
        panelGrafo.Camino = orden;
    }

    private void btnAnchura_Click(object? sender, EventArgs e) =>
        MostrarRecorridoGrafo("Recorrido en anchura (BFS)", _grafo.RecorridoAnchura);

    private void btnProfundidad_Click(object? sender, EventArgs e) =>
        MostrarRecorridoGrafo("Recorrido en profundidad (DFS)", _grafo.RecorridoProfundidad);

    private void btnEjemplo_Click(object? sender, EventArgs e)
    {
        _grafo.Limpiar();

        foreach (string ciudad in new[]
                 { "Monterrey", "Saltillo", "Torreón", "Monclova", "Piedras Negras", "Nuevo Laredo", "Reynosa" })
            _grafo.AgregarVertice(ciudad);

        // Distancias aproximadas por carretera (km), con fines didácticos
        (string, string, double)[] rutas =
        {
            ("Monterrey", "Saltillo", 85),
            ("Monterrey", "Monclova", 200),
            ("Monterrey", "Nuevo Laredo", 225),
            ("Monterrey", "Reynosa", 220),
            ("Saltillo", "Torreón", 160),
            ("Saltillo", "Monclova", 195),
            ("Torreón", "Monclova", 240),
            ("Monclova", "Piedras Negras", 245),
            ("Piedras Negras", "Nuevo Laredo", 330),
            ("Nuevo Laredo", "Reynosa", 250)
        };

        foreach (var (a, b, km) in rutas)
            _grafo.AgregarArista(a, b, km, bidireccional: true);

        RefrescarGrafo();

        cmbDesde.SelectedItem = "Torreón";
        cmbHasta.SelectedItem = "Nuevo Laredo";
        txtTraza.Text = "Red de ejemplo cargada (distancias aproximadas en km)." + Environment.NewLine +
                        "Elige origen y destino y pulsa \"Calcular ruta más corta (Dijkstra)\".";
    }

    private void btnLimpiarGrafo_Click(object? sender, EventArgs e)
    {
        _grafo.Limpiar();
        txtTraza.Clear();
        RefrescarGrafo();
    }
}
