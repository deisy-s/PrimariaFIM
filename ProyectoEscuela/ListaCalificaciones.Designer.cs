namespace ProyectoEscuela
{
    partial class ListaCalificaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            dgv1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            lblTitulo = new Label();
            btnPrintDoc = new Guna.UI2.WinForms.Guna2Button();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            grid1 = new DevExpress.XtraGrid.GridControl();
            gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            btnRegresar = new Guna.UI2.WinForms.Guna2Button();
            pInicio = new Panel();
            pIndex = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            pInicio.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dgv1);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(btnPrintDoc);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(grid1);
            panel1.Location = new Point(18, 49);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1154, 607);
            panel1.TabIndex = 2;
            // 
            // dgv1
            // 
            dgv1.AllowUserToAddRows = false;
            dgv1.AllowUserToDeleteRows = false;
            dgv1.BackgroundColor = Color.White;
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8 });
            dgv1.Location = new Point(24, 95);
            dgv1.Name = "dgv1";
            dgv1.RowHeadersWidth = 62;
            dgv1.Size = new Size(1108, 478);
            dgv1.TabIndex = 12;
            dgv1.CellLeave += dgv1_CellLeave;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Column1.DefaultCellStyle = dataGridViewCellStyle1;
            Column1.HeaderText = "No";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 72;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column2.HeaderText = "NOMBRE";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 121;
            // 
            // Column3
            // 
            Column3.HeaderText = "LENGUAJES";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "SABERES Y PENSAMIENTO CIENTIFICO";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // Column5
            // 
            Column5.HeaderText = "ETICA, NATURALEZA Y SOCIEDADES";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.Width = 150;
            // 
            // Column6
            // 
            Column6.HeaderText = "DE LO HUMANO Y LO COMUNITARIO";
            Column6.MinimumWidth = 8;
            Column6.Name = "Column6";
            Column6.Width = 150;
            // 
            // Column7
            // 
            Column7.HeaderText = "PROMEDIO";
            Column7.MinimumWidth = 8;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 150;
            // 
            // Column8
            // 
            Column8.HeaderText = "OBSERVACIONES";
            Column8.MinimumWidth = 8;
            Column8.Name = "Column8";
            Column8.Width = 200;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(0, 114, 198);
            lblTitulo.Location = new Point(326, 20);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(304, 47);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Calificaciones";
            // 
            // btnPrintDoc
            // 
            btnPrintDoc.BorderColor = Color.Blue;
            btnPrintDoc.BorderRadius = 5;
            btnPrintDoc.BorderThickness = 1;
            btnPrintDoc.CustomizableEdges = customizableEdges1;
            btnPrintDoc.DisabledState.BorderColor = Color.DarkGray;
            btnPrintDoc.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrintDoc.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrintDoc.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrintDoc.Font = new Font("Century Gothic", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrintDoc.ForeColor = Color.White;
            btnPrintDoc.Location = new Point(864, 15);
            btnPrintDoc.Margin = new Padding(4, 5, 4, 5);
            btnPrintDoc.Name = "btnPrintDoc";
            btnPrintDoc.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrintDoc.Size = new Size(121, 68);
            btnPrintDoc.TabIndex = 5;
            btnPrintDoc.Text = "Generar documento";
            btnPrintDoc.Click += btnPrintDoc_Click;
            // 
            // btnSave
            // 
            btnSave.BorderColor = Color.Blue;
            btnSave.BorderRadius = 5;
            btnSave.BorderThickness = 1;
            btnSave.CustomizableEdges = customizableEdges3;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1010, 13);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSave.Size = new Size(121, 68);
            btnSave.TabIndex = 4;
            btnSave.Text = "Guardar";
            btnSave.Click += btnSave_Click;
            // 
            // grid1
            // 
            grid1.EmbeddedNavigator.Margin = new Padding(4, 5, 4, 5);
            grid1.Location = new Point(23, 95);
            grid1.MainView = gridView3;
            grid1.Margin = new Padding(4, 5, 4, 5);
            grid1.Name = "grid1";
            grid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemTextEdit1 });
            grid1.Size = new Size(1109, 478);
            grid1.TabIndex = 9;
            grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView3 });
            // 
            // gridView3
            // 
            gridView3.Appearance.EvenRow.BackColor = Color.White;
            gridView3.Appearance.EvenRow.Options.UseBackColor = true;
            gridView3.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView3.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView3.Appearance.OddRow.BackColor = Color.WhiteSmoke;
            gridView3.Appearance.OddRow.Options.UseBackColor = true;
            gridView3.ColumnPanelRowHeight = 83;
            gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1, gridColumn2, gridColumn3, gridColumn11, gridColumn12, gridColumn13, gridColumn17, gridColumn4 });
            gridView3.DetailHeight = 583;
            gridView3.GridControl = grid1;
            gridView3.Name = "gridView3";
            gridView3.OptionsFilter.ShowInHeaderSearchResults = DevExpress.XtraGrid.Views.Grid.ShowInHeaderSearchResultsMode.None;
            gridView3.OptionsFind.ShowClearButton = false;
            gridView3.OptionsFind.ShowCloseButton = false;
            gridView3.OptionsFind.ShowFindButton = false;
            gridView3.OptionsFind.ShowSearchNavButtons = false;
            gridView3.OptionsView.AllowHtmlDrawHeaders = true;
            gridView3.OptionsView.ColumnAutoWidth = false;
            gridView3.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView3.OptionsView.EnableAppearanceEvenRow = true;
            gridView3.OptionsView.EnableAppearanceOddRow = true;
            gridView3.OptionsView.RowAutoHeight = true;
            gridView3.OptionsView.ShowGroupPanel = false;
            gridView3.OptionsView.ShowIndicator = false;
            gridView3.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            gridView3.RowHeight = 33;
            // 
            // gridColumn1
            // 
            gridColumn1.AppearanceCell.Font = new Font("Century Gothic", 8.25F);
            gridColumn1.AppearanceCell.Options.UseFont = true;
            gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.AppearanceHeader.BackColor = Color.FromArgb(0, 114, 198);
            gridColumn1.AppearanceHeader.Font = new Font("Century Gothic", 6F, FontStyle.Bold);
            gridColumn1.AppearanceHeader.ForeColor = Color.White;
            gridColumn1.AppearanceHeader.Options.UseBackColor = true;
            gridColumn1.AppearanceHeader.Options.UseFont = true;
            gridColumn1.AppearanceHeader.Options.UseForeColor = true;
            gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "No";
            gridColumn1.FieldName = "idAlumno";
            gridColumn1.MinWidth = 29;
            gridColumn1.Name = "gridColumn1";
            gridColumn1.OptionsColumn.AllowEdit = false;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            gridColumn1.Width = 49;
            // 
            // gridColumn2
            // 
            gridColumn2.AppearanceCell.BackColor = Color.White;
            gridColumn2.AppearanceCell.Font = new Font("Century Gothic", 8.25F);
            gridColumn2.AppearanceCell.Options.UseBackColor = true;
            gridColumn2.AppearanceCell.Options.UseFont = true;
            gridColumn2.AppearanceHeader.BackColor = Color.FromArgb(0, 114, 198);
            gridColumn2.AppearanceHeader.Font = new Font("Century Gothic", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridColumn2.AppearanceHeader.ForeColor = Color.White;
            gridColumn2.AppearanceHeader.Options.UseBackColor = true;
            gridColumn2.AppearanceHeader.Options.UseFont = true;
            gridColumn2.AppearanceHeader.Options.UseForeColor = true;
            gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Caption = "NOMBRE DEL ALUMNO";
            gridColumn2.FieldName = "Nombre";
            gridColumn2.MinWidth = 29;
            gridColumn2.Name = "gridColumn2";
            gridColumn2.OptionsColumn.AllowEdit = false;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            gridColumn2.Width = 250;
            // 
            // gridColumn3
            // 
            gridColumn3.AppearanceCell.Font = new Font("Century Gothic", 8.25F);
            gridColumn3.AppearanceCell.Options.UseFont = true;
            gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.AppearanceHeader.BackColor = Color.FromArgb(0, 114, 198);
            gridColumn3.AppearanceHeader.Font = new Font("Century Gothic", 6F, FontStyle.Bold);
            gridColumn3.AppearanceHeader.ForeColor = Color.White;
            gridColumn3.AppearanceHeader.Options.UseBackColor = true;
            gridColumn3.AppearanceHeader.Options.UseFont = true;
            gridColumn3.AppearanceHeader.Options.UseForeColor = true;
            gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.Caption = "LENGUAJES";
            gridColumn3.ColumnEdit = repositoryItemTextEdit1;
            gridColumn3.FieldName = "gridColumn3";
            gridColumn3.MinWidth = 43;
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            gridColumn3.Width = 110;
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn11
            // 
            gridColumn11.AppearanceCell.Font = new Font("Century Gothic", 8.25F);
            gridColumn11.AppearanceCell.Options.UseFont = true;
            gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn11.AppearanceHeader.BackColor = Color.FromArgb(0, 114, 198);
            gridColumn11.AppearanceHeader.Font = new Font("Century Gothic", 6F, FontStyle.Bold);
            gridColumn11.AppearanceHeader.ForeColor = Color.White;
            gridColumn11.AppearanceHeader.Options.UseBackColor = true;
            gridColumn11.AppearanceHeader.Options.UseFont = true;
            gridColumn11.AppearanceHeader.Options.UseForeColor = true;
            gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn11.Caption = "SABERES Y CONOCIMIENTO";
            gridColumn11.ColumnEdit = repositoryItemTextEdit1;
            gridColumn11.MinWidth = 29;
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 3;
            gridColumn11.Width = 110;
            // 
            // gridColumn12
            // 
            gridColumn12.AppearanceCell.Font = new Font("Century Gothic", 8.25F);
            gridColumn12.AppearanceCell.Options.UseFont = true;
            gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn12.AppearanceHeader.BackColor = Color.FromArgb(0, 114, 198);
            gridColumn12.AppearanceHeader.Font = new Font("Century Gothic", 6F, FontStyle.Bold);
            gridColumn12.AppearanceHeader.ForeColor = Color.White;
            gridColumn12.AppearanceHeader.Options.UseBackColor = true;
            gridColumn12.AppearanceHeader.Options.UseFont = true;
            gridColumn12.AppearanceHeader.Options.UseForeColor = true;
            gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn12.Caption = "ETICA, NATURALEZA Y SOCIEDADES";
            gridColumn12.MinWidth = 43;
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 4;
            gridColumn12.Width = 110;
            // 
            // gridColumn13
            // 
            gridColumn13.AppearanceCell.Font = new Font("Century Gothic", 8.25F);
            gridColumn13.AppearanceCell.Options.UseFont = true;
            gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn13.AppearanceHeader.BackColor = Color.FromArgb(0, 114, 198);
            gridColumn13.AppearanceHeader.Font = new Font("Century Gothic", 6F, FontStyle.Bold);
            gridColumn13.AppearanceHeader.ForeColor = Color.White;
            gridColumn13.AppearanceHeader.Options.UseBackColor = true;
            gridColumn13.AppearanceHeader.Options.UseFont = true;
            gridColumn13.AppearanceHeader.Options.UseForeColor = true;
            gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn13.Caption = "DE LO HUMANO Y LO COMUNITARIO";
            gridColumn13.MinWidth = 43;
            gridColumn13.Name = "gridColumn13";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 5;
            gridColumn13.Width = 110;
            // 
            // gridColumn17
            // 
            gridColumn17.AppearanceCell.Font = new Font("Century Gothic", 8.25F);
            gridColumn17.AppearanceCell.Options.UseFont = true;
            gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn17.AppearanceHeader.BackColor = Color.FromArgb(0, 114, 198);
            gridColumn17.AppearanceHeader.Font = new Font("Century Gothic", 6F, FontStyle.Bold);
            gridColumn17.AppearanceHeader.ForeColor = Color.White;
            gridColumn17.AppearanceHeader.Options.UseBackColor = true;
            gridColumn17.AppearanceHeader.Options.UseFont = true;
            gridColumn17.AppearanceHeader.Options.UseForeColor = true;
            gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn17.Caption = "PROMEDIO";
            gridColumn17.MinWidth = 43;
            gridColumn17.Name = "gridColumn17";
            gridColumn17.OptionsColumn.AllowEdit = false;
            gridColumn17.Visible = true;
            gridColumn17.VisibleIndex = 6;
            gridColumn17.Width = 103;
            // 
            // gridColumn4
            // 
            gridColumn4.AppearanceCell.Font = new Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gridColumn4.AppearanceCell.Options.UseFont = true;
            gridColumn4.AppearanceHeader.BackColor = Color.FromArgb(0, 114, 198);
            gridColumn4.AppearanceHeader.Font = new Font("Century Gothic", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridColumn4.AppearanceHeader.ForeColor = Color.White;
            gridColumn4.AppearanceHeader.Options.UseBackColor = true;
            gridColumn4.AppearanceHeader.Options.UseFont = true;
            gridColumn4.AppearanceHeader.Options.UseForeColor = true;
            gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn4.Caption = "OBSERVACIONES";
            gridColumn4.MinWidth = 30;
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 7;
            gridColumn4.Width = 270;
            // 
            // btnRegresar
            // 
            btnRegresar.BorderRadius = 10;
            btnRegresar.CustomizableEdges = customizableEdges5;
            btnRegresar.DisabledState.BorderColor = Color.DarkGray;
            btnRegresar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegresar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegresar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegresar.FillColor = Color.SteelBlue;
            btnRegresar.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(-19, 39);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnRegresar.Size = new Size(171, 65);
            btnRegresar.TabIndex = 11;
            btnRegresar.Text = "Regresar";
            btnRegresar.TextAlign = HorizontalAlignment.Right;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // pInicio
            // 
            pInicio.Controls.Add(btnRegresar);
            pInicio.Controls.Add(panel1);
            pInicio.Location = new Point(-1, -1);
            pInicio.Name = "pInicio";
            pInicio.Size = new Size(1191, 683);
            pInicio.TabIndex = 12;
            // 
            // pIndex
            // 
            pIndex.Location = new Point(-1, 2);
            pIndex.Name = "pIndex";
            pIndex.Size = new Size(1191, 680);
            pIndex.TabIndex = 12;
            // 
            // ListaCalificaciones
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1189, 682);
            Controls.Add(pInicio);
            Controls.Add(pIndex);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ListaCalificaciones";
            Text = "ListaCalificaciones";
            Load += ListaCalificaciones_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            pInicio.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTitulo;
        private Guna.UI2.WinForms.Guna2Button btnPrintDoc;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnRegresar;
        private DevExpress.XtraGrid.GridControl grid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DataGridView dgv1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private Panel pInicio;
        private Panel pIndex;
    }
}