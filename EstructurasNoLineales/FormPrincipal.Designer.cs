namespace EstructurasNoLineales
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabPrincipal = new TabControl();
            tabABB = new TabPage();
            pnlCentroABB = new Panel();
            panelArbol = new EstructurasNoLineales.Controles.PanelArbol();
            txtSalidaABB = new TextBox();
            grpOperacionesABB = new GroupBox();
            lblEstadisticas = new Label();
            btnGuardarReporte = new Button();
            btnPruebas = new Button();
            btnCargarEjemplo = new Button();
            lblPruebas = new Label();
            btnPostorden = new Button();
            btnInorden = new Button();
            btnPreorden = new Button();
            lblRecorridos = new Label();
            btnLimpiarArbol = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            btnInsertar = new Button();
            txtValor = new TextBox();
            lblValor = new Label();
            tabGrafos = new TabPage();
            pnlCentroGrafo = new Panel();
            panelGrafo = new EstructurasNoLineales.Controles.PanelGrafo();
            tlpInferior = new TableLayoutPanel();
            lblMatriz = new Label();
            lblLista = new Label();
            lblTraza = new Label();
            dgvMatriz = new DataGridView();
            txtLista = new TextBox();
            txtTraza = new TextBox();
            grpOperacionesGrafo = new GroupBox();
            btnLimpiarGrafo = new Button();
            btnEjemplo = new Button();
            btnProfundidad = new Button();
            btnAnchura = new Button();
            btnDijkstra = new Button();
            cmbHasta = new ComboBox();
            lblHasta = new Label();
            cmbDesde = new ComboBox();
            lblDesde = new Label();
            lblDijkstra = new Label();
            btnAgregarArista = new Button();
            chkBidireccional = new CheckBox();
            numPeso = new NumericUpDown();
            lblPeso = new Label();
            cmbDestino = new ComboBox();
            lblDestino = new Label();
            cmbOrigen = new ComboBox();
            lblOrigen = new Label();
            lblArista = new Label();
            btnAgregarVertice = new Button();
            txtVertice = new TextBox();
            lblVertice = new Label();
            saveFileDialogReporte = new SaveFileDialog();
            tabPrincipal.SuspendLayout();
            tabABB.SuspendLayout();
            pnlCentroABB.SuspendLayout();
            grpOperacionesABB.SuspendLayout();
            tabGrafos.SuspendLayout();
            pnlCentroGrafo.SuspendLayout();
            tlpInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatriz).BeginInit();
            grpOperacionesGrafo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPeso).BeginInit();
            SuspendLayout();
            // 
            // tabPrincipal
            // 
            tabPrincipal.Controls.Add(tabABB);
            tabPrincipal.Controls.Add(tabGrafos);
            tabPrincipal.Dock = DockStyle.Fill;
            tabPrincipal.Location = new Point(0, 0);
            tabPrincipal.Name = "tabPrincipal";
            tabPrincipal.SelectedIndex = 0;
            tabPrincipal.Size = new Size(1180, 720);
            tabPrincipal.TabIndex = 0;
            // 
            // tabABB
            // 
            tabABB.Controls.Add(pnlCentroABB);
            tabABB.Controls.Add(grpOperacionesABB);
            tabABB.Location = new Point(4, 24);
            tabABB.Name = "tabABB";
            tabABB.Padding = new Padding(3);
            tabABB.Size = new Size(1172, 692);
            tabABB.TabIndex = 0;
            tabABB.Text = "Árbol Binario de Búsqueda";
            tabABB.UseVisualStyleBackColor = true;
            // 
            // pnlCentroABB
            // 
            pnlCentroABB.Controls.Add(panelArbol);
            pnlCentroABB.Controls.Add(txtSalidaABB);
            pnlCentroABB.Dock = DockStyle.Fill;
            pnlCentroABB.Location = new Point(293, 3);
            pnlCentroABB.Name = "pnlCentroABB";
            pnlCentroABB.Size = new Size(876, 686);
            pnlCentroABB.TabIndex = 1;
            // 
            // panelArbol
            // 
            panelArbol.AutoScroll = true;
            panelArbol.BackColor = Color.White;
            panelArbol.BorderStyle = BorderStyle.FixedSingle;
            panelArbol.Dock = DockStyle.Fill;
            panelArbol.Location = new Point(0, 0);
            panelArbol.Name = "panelArbol";
            panelArbol.Size = new Size(876, 456);
            panelArbol.TabIndex = 0;
            // 
            // txtSalidaABB
            // 
            txtSalidaABB.Dock = DockStyle.Bottom;
            txtSalidaABB.Font = new Font("Consolas", 9.75F);
            txtSalidaABB.Location = new Point(0, 456);
            txtSalidaABB.Multiline = true;
            txtSalidaABB.Name = "txtSalidaABB";
            txtSalidaABB.ReadOnly = true;
            txtSalidaABB.ScrollBars = ScrollBars.Both;
            txtSalidaABB.Size = new Size(876, 230);
            txtSalidaABB.TabIndex = 1;
            txtSalidaABB.WordWrap = false;
            // 
            // grpOperacionesABB
            // 
            grpOperacionesABB.Controls.Add(lblEstadisticas);
            grpOperacionesABB.Controls.Add(btnGuardarReporte);
            grpOperacionesABB.Controls.Add(btnPruebas);
            grpOperacionesABB.Controls.Add(btnCargarEjemplo);
            grpOperacionesABB.Controls.Add(lblPruebas);
            grpOperacionesABB.Controls.Add(btnPostorden);
            grpOperacionesABB.Controls.Add(btnInorden);
            grpOperacionesABB.Controls.Add(btnPreorden);
            grpOperacionesABB.Controls.Add(lblRecorridos);
            grpOperacionesABB.Controls.Add(btnLimpiarArbol);
            grpOperacionesABB.Controls.Add(btnEliminar);
            grpOperacionesABB.Controls.Add(btnBuscar);
            grpOperacionesABB.Controls.Add(btnInsertar);
            grpOperacionesABB.Controls.Add(txtValor);
            grpOperacionesABB.Controls.Add(lblValor);
            grpOperacionesABB.Dock = DockStyle.Left;
            grpOperacionesABB.Location = new Point(3, 3);
            grpOperacionesABB.Name = "grpOperacionesABB";
            grpOperacionesABB.Size = new Size(290, 686);
            grpOperacionesABB.TabIndex = 0;
            grpOperacionesABB.TabStop = false;
            grpOperacionesABB.Text = "Operaciones del ABB";
            // 
            // lblEstadisticas
            // 
            lblEstadisticas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblEstadisticas.Location = new Point(15, 500);
            lblEstadisticas.Name = "lblEstadisticas";
            lblEstadisticas.Size = new Size(260, 80);
            lblEstadisticas.TabIndex = 14;
            lblEstadisticas.Text = "Nodos: 0  |  Altura: 0";
            // 
            // btnGuardarReporte
            // 
            btnGuardarReporte.Location = new Point(15, 448);
            btnGuardarReporte.Name = "btnGuardarReporte";
            btnGuardarReporte.Size = new Size(260, 34);
            btnGuardarReporte.TabIndex = 13;
            btnGuardarReporte.Text = "Guardar reporte (.txt)";
            btnGuardarReporte.UseVisualStyleBackColor = true;
            btnGuardarReporte.Click += btnGuardarReporte_Click;
            // 
            // btnPruebas
            // 
            btnPruebas.Location = new Point(15, 408);
            btnPruebas.Name = "btnPruebas";
            btnPruebas.Size = new Size(260, 34);
            btnPruebas.TabIndex = 12;
            btnPruebas.Text = "Ejecutar pruebas de integridad";
            btnPruebas.UseVisualStyleBackColor = true;
            btnPruebas.Click += btnPruebas_Click;
            // 
            // btnCargarEjemplo
            // 
            btnCargarEjemplo.Location = new Point(15, 368);
            btnCargarEjemplo.Name = "btnCargarEjemplo";
            btnCargarEjemplo.Size = new Size(260, 34);
            btnCargarEjemplo.TabIndex = 11;
            btnCargarEjemplo.Text = "Cargar árbol de ejemplo";
            btnCargarEjemplo.UseVisualStyleBackColor = true;
            btnCargarEjemplo.Click += btnCargarEjemplo_Click;
            // 
            // lblPruebas
            // 
            lblPruebas.AutoSize = true;
            lblPruebas.Location = new Point(15, 344);
            lblPruebas.Name = "lblPruebas";
            lblPruebas.Size = new Size(146, 15);
            lblPruebas.TabIndex = 10;
            lblPruebas.Text = "Datos de prueba y reporte:";
            // 
            // btnPostorden
            // 
            btnPostorden.Location = new Point(15, 290);
            btnPostorden.Name = "btnPostorden";
            btnPostorden.Size = new Size(260, 34);
            btnPostorden.TabIndex = 9;
            btnPostorden.Text = "Postorden (izq, der, raíz)";
            btnPostorden.UseVisualStyleBackColor = true;
            btnPostorden.Click += btnPostorden_Click;
            // 
            // btnInorden
            // 
            btnInorden.Location = new Point(15, 250);
            btnInorden.Name = "btnInorden";
            btnInorden.Size = new Size(260, 34);
            btnInorden.TabIndex = 8;
            btnInorden.Text = "Inorden (izq, raíz, der)";
            btnInorden.UseVisualStyleBackColor = true;
            btnInorden.Click += btnInorden_Click;
            // 
            // btnPreorden
            // 
            btnPreorden.Location = new Point(15, 210);
            btnPreorden.Name = "btnPreorden";
            btnPreorden.Size = new Size(260, 34);
            btnPreorden.TabIndex = 7;
            btnPreorden.Text = "Preorden (raíz, izq, der)";
            btnPreorden.UseVisualStyleBackColor = true;
            btnPreorden.Click += btnPreorden_Click;
            // 
            // lblRecorridos
            // 
            lblRecorridos.AutoSize = true;
            lblRecorridos.Location = new Point(15, 186);
            lblRecorridos.Name = "lblRecorridos";
            lblRecorridos.Size = new Size(151, 15);
            lblRecorridos.TabIndex = 6;
            lblRecorridos.Text = "Recorridos en profundidad:";
            // 
            // btnLimpiarArbol
            // 
            btnLimpiarArbol.Location = new Point(150, 134);
            btnLimpiarArbol.Name = "btnLimpiarArbol";
            btnLimpiarArbol.Size = new Size(125, 34);
            btnLimpiarArbol.TabIndex = 5;
            btnLimpiarArbol.Text = "Vaciar árbol";
            btnLimpiarArbol.UseVisualStyleBackColor = true;
            btnLimpiarArbol.Click += btnLimpiarArbol_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(15, 134);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(125, 34);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(150, 92);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(125, 34);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(15, 92);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(125, 34);
            btnInsertar.TabIndex = 2;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(15, 52);
            txtValor.MaxLength = 9;
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(150, 23);
            txtValor.TabIndex = 1;
            txtValor.KeyDown += txtValor_KeyDown;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(15, 30);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(73, 15);
            lblValor.TabIndex = 0;
            lblValor.Text = "Valor entero:";
            // 
            // tabGrafos
            // 
            tabGrafos.Controls.Add(pnlCentroGrafo);
            tabGrafos.Controls.Add(grpOperacionesGrafo);
            tabGrafos.Location = new Point(4, 24);
            tabGrafos.Name = "tabGrafos";
            tabGrafos.Padding = new Padding(3);
            tabGrafos.Size = new Size(1172, 692);
            tabGrafos.TabIndex = 1;
            tabGrafos.Text = "Grafos y Dijkstra";
            tabGrafos.UseVisualStyleBackColor = true;
            // 
            // pnlCentroGrafo
            // 
            pnlCentroGrafo.Controls.Add(panelGrafo);
            pnlCentroGrafo.Controls.Add(tlpInferior);
            pnlCentroGrafo.Dock = DockStyle.Fill;
            pnlCentroGrafo.Location = new Point(343, 3);
            pnlCentroGrafo.Name = "pnlCentroGrafo";
            pnlCentroGrafo.Size = new Size(826, 686);
            pnlCentroGrafo.TabIndex = 1;
            // 
            // panelGrafo
            // 
            panelGrafo.BackColor = Color.White;
            panelGrafo.BorderStyle = BorderStyle.FixedSingle;
            panelGrafo.Dock = DockStyle.Fill;
            panelGrafo.Location = new Point(0, 0);
            panelGrafo.Name = "panelGrafo";
            panelGrafo.Size = new Size(826, 416);
            panelGrafo.TabIndex = 0;
            // 
            // tlpInferior
            // 
            tlpInferior.ColumnCount = 3;
            tlpInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            tlpInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            tlpInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpInferior.Controls.Add(lblMatriz, 0, 0);
            tlpInferior.Controls.Add(lblLista, 1, 0);
            tlpInferior.Controls.Add(lblTraza, 2, 0);
            tlpInferior.Controls.Add(dgvMatriz, 0, 1);
            tlpInferior.Controls.Add(txtLista, 1, 1);
            tlpInferior.Controls.Add(txtTraza, 2, 1);
            tlpInferior.Dock = DockStyle.Bottom;
            tlpInferior.Location = new Point(0, 416);
            tlpInferior.Name = "tlpInferior";
            tlpInferior.RowCount = 2;
            tlpInferior.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpInferior.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInferior.Size = new Size(826, 270);
            tlpInferior.TabIndex = 1;
            // 
            // lblMatriz
            // 
            lblMatriz.Dock = DockStyle.Fill;
            lblMatriz.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMatriz.Location = new Point(3, 0);
            lblMatriz.Name = "lblMatriz";
            lblMatriz.Size = new Size(291, 24);
            lblMatriz.TabIndex = 0;
            lblMatriz.Text = "Matriz de adyacencia";
            lblMatriz.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLista
            // 
            lblLista.Dock = DockStyle.Fill;
            lblLista.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLista.Location = new Point(300, 0);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(192, 24);
            lblLista.TabIndex = 1;
            lblLista.Text = "Lista de adyacencia";
            lblLista.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTraza
            // 
            lblTraza.Dock = DockStyle.Fill;
            lblTraza.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTraza.Location = new Point(498, 0);
            lblTraza.Name = "lblTraza";
            lblTraza.Size = new Size(325, 24);
            lblTraza.TabIndex = 2;
            lblTraza.Text = "Traza de ejecución / resultado";
            lblTraza.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvMatriz
            // 
            dgvMatriz.AllowUserToAddRows = false;
            dgvMatriz.AllowUserToDeleteRows = false;
            dgvMatriz.AllowUserToResizeRows = false;
            dgvMatriz.BackgroundColor = Color.White;
            dgvMatriz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvMatriz.DefaultCellStyle = dataGridViewCellStyle1;
            dgvMatriz.Dock = DockStyle.Fill;
            dgvMatriz.Location = new Point(3, 27);
            dgvMatriz.MultiSelect = false;
            dgvMatriz.Name = "dgvMatriz";
            dgvMatriz.ReadOnly = true;
            dgvMatriz.RowHeadersWidth = 110;
            dgvMatriz.Size = new Size(291, 240);
            dgvMatriz.TabIndex = 3;
            // 
            // txtLista
            // 
            txtLista.Dock = DockStyle.Fill;
            txtLista.Font = new Font("Consolas", 9F);
            txtLista.Location = new Point(300, 27);
            txtLista.Multiline = true;
            txtLista.Name = "txtLista";
            txtLista.ReadOnly = true;
            txtLista.ScrollBars = ScrollBars.Both;
            txtLista.Size = new Size(192, 240);
            txtLista.TabIndex = 4;
            txtLista.WordWrap = false;
            // 
            // txtTraza
            // 
            txtTraza.Dock = DockStyle.Fill;
            txtTraza.Font = new Font("Consolas", 9F);
            txtTraza.Location = new Point(498, 27);
            txtTraza.Multiline = true;
            txtTraza.Name = "txtTraza";
            txtTraza.ReadOnly = true;
            txtTraza.ScrollBars = ScrollBars.Both;
            txtTraza.Size = new Size(325, 240);
            txtTraza.TabIndex = 5;
            txtTraza.WordWrap = false;
            // 
            // grpOperacionesGrafo
            // 
            grpOperacionesGrafo.Controls.Add(btnLimpiarGrafo);
            grpOperacionesGrafo.Controls.Add(btnEjemplo);
            grpOperacionesGrafo.Controls.Add(btnProfundidad);
            grpOperacionesGrafo.Controls.Add(btnAnchura);
            grpOperacionesGrafo.Controls.Add(btnDijkstra);
            grpOperacionesGrafo.Controls.Add(cmbHasta);
            grpOperacionesGrafo.Controls.Add(lblHasta);
            grpOperacionesGrafo.Controls.Add(cmbDesde);
            grpOperacionesGrafo.Controls.Add(lblDesde);
            grpOperacionesGrafo.Controls.Add(lblDijkstra);
            grpOperacionesGrafo.Controls.Add(btnAgregarArista);
            grpOperacionesGrafo.Controls.Add(chkBidireccional);
            grpOperacionesGrafo.Controls.Add(numPeso);
            grpOperacionesGrafo.Controls.Add(lblPeso);
            grpOperacionesGrafo.Controls.Add(cmbDestino);
            grpOperacionesGrafo.Controls.Add(lblDestino);
            grpOperacionesGrafo.Controls.Add(cmbOrigen);
            grpOperacionesGrafo.Controls.Add(lblOrigen);
            grpOperacionesGrafo.Controls.Add(lblArista);
            grpOperacionesGrafo.Controls.Add(btnAgregarVertice);
            grpOperacionesGrafo.Controls.Add(txtVertice);
            grpOperacionesGrafo.Controls.Add(lblVertice);
            grpOperacionesGrafo.Dock = DockStyle.Left;
            grpOperacionesGrafo.Location = new Point(3, 3);
            grpOperacionesGrafo.Name = "grpOperacionesGrafo";
            grpOperacionesGrafo.Size = new Size(340, 686);
            grpOperacionesGrafo.TabIndex = 0;
            grpOperacionesGrafo.TabStop = false;
            grpOperacionesGrafo.Text = "Construcción y algoritmos del grafo";
            // 
            // btnLimpiarGrafo
            // 
            btnLimpiarGrafo.Location = new Point(175, 456);
            btnLimpiarGrafo.Name = "btnLimpiarGrafo";
            btnLimpiarGrafo.Size = new Size(150, 34);
            btnLimpiarGrafo.TabIndex = 21;
            btnLimpiarGrafo.Text = "Vaciar grafo";
            btnLimpiarGrafo.UseVisualStyleBackColor = true;
            btnLimpiarGrafo.Click += btnLimpiarGrafo_Click;
            // 
            // btnEjemplo
            // 
            btnEjemplo.Location = new Point(15, 456);
            btnEjemplo.Name = "btnEjemplo";
            btnEjemplo.Size = new Size(150, 34);
            btnEjemplo.TabIndex = 20;
            btnEjemplo.Text = "Cargar red de ejemplo";
            btnEjemplo.UseVisualStyleBackColor = true;
            btnEjemplo.Click += btnEjemplo_Click;
            // 
            // btnProfundidad
            // 
            btnProfundidad.Location = new Point(175, 408);
            btnProfundidad.Name = "btnProfundidad";
            btnProfundidad.Size = new Size(150, 34);
            btnProfundidad.TabIndex = 19;
            btnProfundidad.Text = "Recorrido DFS";
            btnProfundidad.UseVisualStyleBackColor = true;
            btnProfundidad.Click += btnProfundidad_Click;
            // 
            // btnAnchura
            // 
            btnAnchura.Location = new Point(15, 408);
            btnAnchura.Name = "btnAnchura";
            btnAnchura.Size = new Size(150, 34);
            btnAnchura.TabIndex = 18;
            btnAnchura.Text = "Recorrido BFS";
            btnAnchura.UseVisualStyleBackColor = true;
            btnAnchura.Click += btnAnchura_Click;
            // 
            // btnDijkstra
            // 
            btnDijkstra.Location = new Point(15, 360);
            btnDijkstra.Name = "btnDijkstra";
            btnDijkstra.Size = new Size(310, 34);
            btnDijkstra.TabIndex = 17;
            btnDijkstra.Text = "Calcular ruta más corta (Dijkstra)";
            btnDijkstra.UseVisualStyleBackColor = true;
            btnDijkstra.Click += btnDijkstra_Click;
            // 
            // cmbHasta
            // 
            cmbHasta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHasta.FormattingEnabled = true;
            cmbHasta.Location = new Point(175, 320);
            cmbHasta.Name = "cmbHasta";
            cmbHasta.Size = new Size(150, 23);
            cmbHasta.TabIndex = 16;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(175, 300);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 15;
            lblHasta.Text = "Hasta:";
            // 
            // cmbDesde
            // 
            cmbDesde.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDesde.FormattingEnabled = true;
            cmbDesde.Location = new Point(15, 320);
            cmbDesde.Name = "cmbDesde";
            cmbDesde.Size = new Size(150, 23);
            cmbDesde.TabIndex = 14;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(15, 300);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 13;
            lblDesde.Text = "Desde:";
            // 
            // lblDijkstra
            // 
            lblDijkstra.AutoSize = true;
            lblDijkstra.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDijkstra.Location = new Point(15, 275);
            lblDijkstra.Name = "lblDijkstra";
            lblDijkstra.Size = new Size(178, 15);
            lblDijkstra.TabIndex = 12;
            lblDijkstra.Text = "Camino más corto y recorridos:";
            // 
            // btnAgregarArista
            // 
            btnAgregarArista.Location = new Point(15, 222);
            btnAgregarArista.Name = "btnAgregarArista";
            btnAgregarArista.Size = new Size(310, 34);
            btnAgregarArista.TabIndex = 11;
            btnAgregarArista.Text = "Agregar / actualizar arista";
            btnAgregarArista.UseVisualStyleBackColor = true;
            btnAgregarArista.Click += btnAgregarArista_Click;
            // 
            // chkBidireccional
            // 
            chkBidireccional.AutoSize = true;
            chkBidireccional.Checked = true;
            chkBidireccional.CheckState = CheckState.Checked;
            chkBidireccional.Location = new Point(150, 190);
            chkBidireccional.Name = "chkBidireccional";
            chkBidireccional.Size = new Size(162, 19);
            chkBidireccional.TabIndex = 10;
            chkBidireccional.Text = "Bidireccional (no dirigida)";
            chkBidireccional.UseVisualStyleBackColor = true;
            // 
            // numPeso
            // 
            numPeso.Location = new Point(15, 187);
            numPeso.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPeso.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPeso.Name = "numPeso";
            numPeso.Size = new Size(110, 23);
            numPeso.TabIndex = 9;
            numPeso.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(15, 167);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(63, 15);
            lblPeso.TabIndex = 8;
            lblPeso.Text = "Peso (km):";
            // 
            // cmbDestino
            // 
            cmbDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(175, 132);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(150, 23);
            cmbDestino.TabIndex = 7;
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Location = new Point(175, 112);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(50, 15);
            lblDestino.TabIndex = 6;
            lblDestino.Text = "Destino:";
            // 
            // cmbOrigen
            // 
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(15, 132);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(150, 23);
            cmbOrigen.TabIndex = 5;
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new Point(15, 112);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(46, 15);
            lblOrigen.TabIndex = 4;
            lblOrigen.Text = "Origen:";
            // 
            // lblArista
            // 
            lblArista.AutoSize = true;
            lblArista.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblArista.Location = new Point(15, 88);
            lblArista.Name = "lblArista";
            lblArista.Size = new Size(108, 15);
            lblArista.TabIndex = 3;
            lblArista.Text = "Conectar vértices:";
            // 
            // btnAgregarVertice
            // 
            btnAgregarVertice.Location = new Point(215, 46);
            btnAgregarVertice.Name = "btnAgregarVertice";
            btnAgregarVertice.Size = new Size(110, 27);
            btnAgregarVertice.TabIndex = 2;
            btnAgregarVertice.Text = "Agregar";
            btnAgregarVertice.UseVisualStyleBackColor = true;
            btnAgregarVertice.Click += btnAgregarVertice_Click;
            // 
            // txtVertice
            // 
            txtVertice.Location = new Point(15, 48);
            txtVertice.MaxLength = 30;
            txtVertice.Name = "txtVertice";
            txtVertice.Size = new Size(190, 23);
            txtVertice.TabIndex = 1;
            txtVertice.KeyDown += txtVertice_KeyDown;
            // 
            // lblVertice
            // 
            lblVertice.AutoSize = true;
            lblVertice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVertice.Location = new Point(15, 28);
            lblVertice.Name = "lblVertice";
            lblVertice.Size = new Size(178, 15);
            lblVertice.TabIndex = 0;
            lblVertice.Text = "Nuevo vértice (ciudad o nodo):";
            // 
            // saveFileDialogReporte
            // 
            saveFileDialogReporte.DefaultExt = "txt";
            saveFileDialogReporte.FileName = "reporte_pruebas_ABB.txt";
            saveFileDialogReporte.Filter = "Archivo de texto (*.txt)|*.txt";
            saveFileDialogReporte.Title = "Guardar reporte de pruebas";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 720);
            Controls.Add(tabPrincipal);
            MinimumSize = new Size(1000, 640);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form 1";
            Load += FormPrincipal_Load;
            tabPrincipal.ResumeLayout(false);
            tabABB.ResumeLayout(false);
            pnlCentroABB.ResumeLayout(false);
            pnlCentroABB.PerformLayout();
            grpOperacionesABB.ResumeLayout(false);
            grpOperacionesABB.PerformLayout();
            tabGrafos.ResumeLayout(false);
            pnlCentroGrafo.ResumeLayout(false);
            tlpInferior.ResumeLayout(false);
            tlpInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatriz).EndInit();
            grpOperacionesGrafo.ResumeLayout(false);
            grpOperacionesGrafo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPeso).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabABB;
        private System.Windows.Forms.TabPage tabGrafos;

        // --- Pestaña ABB
        private System.Windows.Forms.GroupBox grpOperacionesABB;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiarArbol;
        private System.Windows.Forms.Label lblRecorridos;
        private System.Windows.Forms.Button btnPreorden;
        private System.Windows.Forms.Button btnInorden;
        private System.Windows.Forms.Button btnPostorden;
        private System.Windows.Forms.Label lblPruebas;
        private System.Windows.Forms.Button btnCargarEjemplo;
        private System.Windows.Forms.Button btnPruebas;
        private System.Windows.Forms.Button btnGuardarReporte;
        private System.Windows.Forms.Label lblEstadisticas;
        private System.Windows.Forms.Panel pnlCentroABB;
        private Controles.PanelArbol panelArbol;
        private System.Windows.Forms.TextBox txtSalidaABB;
        private System.Windows.Forms.SaveFileDialog saveFileDialogReporte;

        // --- Pestaña Grafos
        private System.Windows.Forms.GroupBox grpOperacionesGrafo;
        private System.Windows.Forms.Label lblVertice;
        private System.Windows.Forms.TextBox txtVertice;
        private System.Windows.Forms.Button btnAgregarVertice;
        private System.Windows.Forms.Label lblArista;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.NumericUpDown numPeso;
        private System.Windows.Forms.CheckBox chkBidireccional;
        private System.Windows.Forms.Button btnAgregarArista;
        private System.Windows.Forms.Label lblDijkstra;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.ComboBox cmbDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.ComboBox cmbHasta;
        private System.Windows.Forms.Button btnDijkstra;
        private System.Windows.Forms.Button btnAnchura;
        private System.Windows.Forms.Button btnProfundidad;
        private System.Windows.Forms.Button btnEjemplo;
        private System.Windows.Forms.Button btnLimpiarGrafo;
        private System.Windows.Forms.Panel pnlCentroGrafo;
        private Controles.PanelGrafo panelGrafo;
        private System.Windows.Forms.TableLayoutPanel tlpInferior;
        private System.Windows.Forms.Label lblMatriz;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.Label lblTraza;
        private System.Windows.Forms.DataGridView dgvMatriz;
        private System.Windows.Forms.TextBox txtLista;
        private System.Windows.Forms.TextBox txtTraza;
    }
}
