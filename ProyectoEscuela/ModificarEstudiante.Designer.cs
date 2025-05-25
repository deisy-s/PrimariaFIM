namespace ProyectoEscuela
{
    partial class ModificarEstudiante
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
            label3 = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            tbLastName = new Guna.UI2.WinForms.Guna2TextBox();
            tbName = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            lblName1 = new Label();
            tbGrupo = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Agency FB", 24F, FontStyle.Bold);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(164, 9);
            label3.Name = "label3";
            label3.Size = new Size(173, 118);
            label3.TabIndex = 72;
            label3.Text = "Modificar\r\nAlumno";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 9;
            btnSave.CustomizableEdges = customizableEdges1;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.RoyalBlue;
            btnSave.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(203, 513);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSave.Size = new Size(141, 47);
            btnSave.TabIndex = 68;
            btnSave.Text = "GUARDAR";
            btnSave.Click += btnSave_Click;
            // 
            // tbLastName
            // 
            tbLastName.BorderColor = Color.RoyalBlue;
            tbLastName.BorderRadius = 10;
            tbLastName.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tbLastName.CustomizableEdges = customizableEdges3;
            tbLastName.DefaultText = "";
            tbLastName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbLastName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbLastName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbLastName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbLastName.FillColor = SystemColors.ControlLightLight;
            tbLastName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbLastName.Font = new Font("Segoe UI", 9F);
            tbLastName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbLastName.Location = new Point(141, 282);
            tbLastName.Margin = new Padding(6, 8, 6, 8);
            tbLastName.Name = "tbLastName";
            tbLastName.PasswordChar = '\0';
            tbLastName.PlaceholderText = "";
            tbLastName.SelectedText = "";
            tbLastName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbLastName.Size = new Size(273, 53);
            tbLastName.TabIndex = 65;
            // 
            // tbName
            // 
            tbName.BorderColor = Color.RoyalBlue;
            tbName.BorderRadius = 10;
            tbName.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tbName.CustomizableEdges = customizableEdges5;
            tbName.DefaultText = "";
            tbName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbName.FillColor = SystemColors.ControlLightLight;
            tbName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbName.Font = new Font("Segoe UI", 9F);
            tbName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbName.Location = new Point(141, 158);
            tbName.Margin = new Padding(6, 8, 6, 8);
            tbName.Name = "tbName";
            tbName.PasswordChar = '\0';
            tbName.PlaceholderText = "";
            tbName.SelectedText = "";
            tbName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbName.Size = new Size(273, 53);
            tbName.TabIndex = 64;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(141, 248);
            label1.Name = "label1";
            label1.Size = new Size(117, 28);
            label1.TabIndex = 70;
            label1.Text = "Apellido:";
            // 
            // lblName1
            // 
            lblName1.AutoSize = true;
            lblName1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName1.Location = new Point(141, 127);
            lblName1.Name = "lblName1";
            lblName1.Size = new Size(114, 28);
            lblName1.TabIndex = 69;
            lblName1.Text = "Nombre:";
            // 
            // tbGrupo
            // 
            tbGrupo.BorderColor = Color.RoyalBlue;
            tbGrupo.BorderRadius = 10;
            tbGrupo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tbGrupo.CustomizableEdges = customizableEdges7;
            tbGrupo.DefaultText = "";
            tbGrupo.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbGrupo.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbGrupo.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbGrupo.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbGrupo.FillColor = SystemColors.ControlLightLight;
            tbGrupo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbGrupo.Font = new Font("Segoe UI", 9F);
            tbGrupo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbGrupo.Location = new Point(141, 413);
            tbGrupo.Margin = new Padding(6, 8, 6, 8);
            tbGrupo.Name = "tbGrupo";
            tbGrupo.PasswordChar = '\0';
            tbGrupo.PlaceholderText = "";
            tbGrupo.SelectedText = "";
            tbGrupo.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbGrupo.Size = new Size(273, 53);
            tbGrupo.TabIndex = 73;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(141, 377);
            label2.Name = "label2";
            label2.Size = new Size(92, 28);
            label2.TabIndex = 74;
            label2.Text = "Grupo:";
            // 
            // ModificarEstudiante
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(544, 602);
            Controls.Add(tbGrupo);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(btnSave);
            Controls.Add(tbLastName);
            Controls.Add(tbName);
            Controls.Add(label1);
            Controls.Add(lblName1);
            Name = "ModificarEstudiante";
            StartPosition = FormStartPosition.CenterScreen;
            Load += ModificarEstudiante_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox tbLastName;
        private Guna.UI2.WinForms.Guna2TextBox tbName;
        private Label label1;
        private Label lblName1;
        private Guna.UI2.WinForms.Guna2TextBox tbGrupo;
        private Label label2;
    }
}