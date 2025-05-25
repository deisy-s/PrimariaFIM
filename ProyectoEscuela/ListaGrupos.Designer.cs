namespace ProyectoEscuela
{
    partial class ListaGrupos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pInicio = new Panel();
            btnRegresar = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            dgv1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            lblTitulo = new Label();
            pIndex = new Panel();
            pInicio.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            SuspendLayout();
            // 
            // pInicio
            // 
            pInicio.Controls.Add(btnRegresar);
            pInicio.Controls.Add(panel1);
            pInicio.Location = new Point(-1, 0);
            pInicio.Name = "pInicio";
            pInicio.Size = new Size(1191, 684);
            pInicio.TabIndex = 13;
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
            btnRegresar.TabIndex = 11;
            btnRegresar.Text = "Regresar";
            btnRegresar.TextAlign = HorizontalAlignment.Right;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dgv1);
            panel1.Controls.Add(lblTitulo);
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
            dgv1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dgv1.Location = new Point(24, 95);
            dgv1.Name = "dgv1";
            dgv1.RowHeadersWidth = 62;
            dgv1.Size = new Size(1108, 478);
            dgv1.TabIndex = 12;
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
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Column3.HeaderText = "GRUPO";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 107;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column4.HeaderText = "MAESTRO";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 129;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(0, 114, 198);
            lblTitulo.Location = new Point(326, 20);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(147, 47);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Grado";
            // 
            // pIndex
            // 
            pIndex.Location = new Point(-1, 0);
            pIndex.Name = "pIndex";
            pIndex.Size = new Size(1191, 684);
            pIndex.TabIndex = 14;
            // 
            // ListaGrupos
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1189, 682);
            Controls.Add(pInicio);
            Controls.Add(pIndex);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ListaGrupos";
            Text = "ListaGrupos";
            Load += ListaGrupos_Load;
            pInicio.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pInicio;
        private Guna.UI2.WinForms.Guna2Button btnRegresar;
        private Panel panel1;
        private DataGridView dgv1;
        private Label lblTitulo;
        private Panel pIndex;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}