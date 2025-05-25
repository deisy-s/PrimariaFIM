namespace ProyectoEscuela
{
    partial class ListaAlumno
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pInicio = new Panel();
            btnRegresar = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            btnTL = new Guna.UI2.WinForms.Guna2Button();
            btnCM = new Guna.UI2.WinForms.Guna2Button();
            btnPT = new Guna.UI2.WinForms.Guna2Button();
            dgv1 = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            lblTitulo = new Label();
            pIndex = new Panel();
            pInicio.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            SuspendLayout();
            // 
            // pInicio
            // 
            pInicio.Controls.Add(btnRegresar);
            pInicio.Controls.Add(panel1);
            pInicio.Location = new Point(1, 0);
            pInicio.Name = "pInicio";
            pInicio.Size = new Size(1189, 684);
            pInicio.TabIndex = 0;
            // 
            // btnRegresar
            // 
            btnRegresar.BorderRadius = 10;
            btnRegresar.CustomizableEdges = customizableEdges1;
            btnRegresar.DisabledState.BorderColor = Color.DarkGray;
            btnRegresar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegresar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegresar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegresar.FillColor = Color.SteelBlue;
            btnRegresar.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(-19, 39);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRegresar.Size = new Size(171, 65);
            btnRegresar.TabIndex = 13;
            btnRegresar.Text = "Regresar";
            btnRegresar.TextAlign = HorizontalAlignment.Right;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(dgv1);
            panel1.Controls.Add(lblTitulo);
            panel1.Location = new Point(18, 49);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1154, 607);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnTL);
            panel2.Controls.Add(btnCM);
            panel2.Controls.Add(btnPT);
            panel2.Location = new Point(861, 95);
            panel2.Name = "panel2";
            panel2.Size = new Size(274, 478);
            panel2.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(33, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(201, 46);
            label1.TabIndex = 13;
            label1.Text = "Ver resultados SisAT\r\ndel ciclo pasado:";
            // 
            // btnTL
            // 
            btnTL.BorderRadius = 5;
            btnTL.CustomizableEdges = customizableEdges3;
            btnTL.DisabledState.BorderColor = Color.DarkGray;
            btnTL.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTL.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTL.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTL.FillColor = Color.DarkSeaGreen;
            btnTL.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTL.ForeColor = Color.White;
            btnTL.Location = new Point(11, 221);
            btnTL.Name = "btnTL";
            btnTL.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnTL.Size = new Size(250, 53);
            btnTL.TabIndex = 16;
            btnTL.Text = "Toma de Lectura";
            btnTL.Click += btnTL_Click;
            // 
            // btnCM
            // 
            btnCM.BorderRadius = 5;
            btnCM.CustomizableEdges = customizableEdges5;
            btnCM.DisabledState.BorderColor = Color.DarkGray;
            btnCM.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCM.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCM.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCM.FillColor = Color.IndianRed;
            btnCM.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCM.ForeColor = Color.White;
            btnCM.Location = new Point(11, 75);
            btnCM.Name = "btnCM";
            btnCM.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCM.Size = new Size(250, 53);
            btnCM.TabIndex = 14;
            btnCM.Text = "Cálculo mental";
            btnCM.Click += btnCM_Click;
            // 
            // btnPT
            // 
            btnPT.BorderRadius = 5;
            btnPT.CustomizableEdges = customizableEdges7;
            btnPT.DisabledState.BorderColor = Color.DarkGray;
            btnPT.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPT.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPT.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPT.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPT.ForeColor = Color.White;
            btnPT.Location = new Point(11, 150);
            btnPT.Name = "btnPT";
            btnPT.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnPT.Size = new Size(250, 53);
            btnPT.TabIndex = 15;
            btnPT.Text = "Producción de Textos";
            btnPT.Click += btnPT_Click;
            // 
            // dgv1
            // 
            dgv1.AllowUserToAddRows = false;
            dgv1.AllowUserToDeleteRows = false;
            dgv1.BackgroundColor = Color.White;
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv1.Columns.AddRange(new DataGridViewColumn[] { Column6, Column1, Column3, Column4, Column5 });
            dgv1.Location = new Point(18, 95);
            dgv1.Name = "dgv1";
            dgv1.RowHeadersWidth = 62;
            dgv1.Size = new Size(832, 478);
            dgv1.TabIndex = 12;
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Column6.HeaderText = "Calificación final";
            Column6.MinimumWidth = 8;
            Column6.Name = "Column6";
            Column6.Width = 160;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Column1.HeaderText = "Cálculo mental";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 151;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Column3.HeaderText = "Producción de textos";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 153;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Column4.HeaderText = "Toma de lectura";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 159;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column5.HeaderText = "Periodo";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.Width = 109;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(0, 114, 198);
            lblTitulo.Location = new Point(257, 17);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(137, 47);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "name";
            // 
            // pIndex
            // 
            pIndex.Location = new Point(0, 0);
            pIndex.Name = "pIndex";
            pIndex.Size = new Size(1189, 684);
            pIndex.TabIndex = 1;
            pIndex.Visible = false;
            // 
            // ListaAlumno
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1189, 682);
            Controls.Add(pInicio);
            Controls.Add(pIndex);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ListaAlumno";
            Text = "ListaAlumno";
            pInicio.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pInicio;
        private Panel pIndex;
        private Guna.UI2.WinForms.Guna2Button btnRegresar;
        private Panel panel1;
        private DataGridView dgv1;
        private Label lblTitulo;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnCM;
        private Guna.UI2.WinForms.Guna2Button btnPT;
        private Guna.UI2.WinForms.Guna2Button btnTL;
        private Panel panel2;
    }
}