namespace ProyectoEscuela
{
    partial class AgregarEstudiante
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
            label2 = new Label();
            tbGrade = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Agency FB", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(170, 5);
            label3.Name = "label3";
            label3.Size = new Size(161, 118);
            label3.TabIndex = 65;
            label3.Text = "Registar\r\nAlumno";
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
            btnSave.Location = new Point(203, 502);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSave.Size = new Size(142, 46);
            btnSave.TabIndex = 61;
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
            tbLastName.Location = new Point(141, 276);
            tbLastName.Margin = new Padding(4, 5, 4, 5);
            tbLastName.Name = "tbLastName";
            tbLastName.PasswordChar = '\0';
            tbLastName.PlaceholderText = "";
            tbLastName.SelectedText = "";
            tbLastName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbLastName.Size = new Size(273, 53);
            tbLastName.TabIndex = 57;
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
            tbName.Location = new Point(141, 156);
            tbName.Margin = new Padding(4, 5, 4, 5);
            tbName.Name = "tbName";
            tbName.PasswordChar = '\0';
            tbName.PlaceholderText = "";
            tbName.SelectedText = "";
            tbName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbName.Size = new Size(273, 53);
            tbName.TabIndex = 56;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(141, 243);
            label1.Name = "label1";
            label1.Size = new Size(128, 28);
            label1.TabIndex = 63;
            label1.Text = "Apellidos:";
            // 
            // lblName1
            // 
            lblName1.AutoSize = true;
            lblName1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName1.Location = new Point(141, 123);
            lblName1.Name = "lblName1";
            lblName1.Size = new Size(114, 28);
            lblName1.TabIndex = 62;
            lblName1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(141, 363);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 64;
            label2.Text = "Grado:";
            // 
            // tbGrade
            // 
            tbGrade.BorderColor = Color.RoyalBlue;
            tbGrade.BorderRadius = 10;
            tbGrade.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tbGrade.CustomizableEdges = customizableEdges7;
            tbGrade.DefaultText = "";
            tbGrade.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbGrade.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbGrade.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbGrade.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbGrade.FillColor = SystemColors.ControlLightLight;
            tbGrade.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbGrade.Font = new Font("Segoe UI", 9F);
            tbGrade.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbGrade.Location = new Point(141, 396);
            tbGrade.Margin = new Padding(4, 5, 4, 5);
            tbGrade.Name = "tbGrade";
            tbGrade.PasswordChar = '\0';
            tbGrade.PlaceholderText = "";
            tbGrade.ReadOnly = true;
            tbGrade.SelectedText = "";
            tbGrade.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbGrade.Size = new Size(273, 53);
            tbGrade.TabIndex = 58;
            // 
            // AgregarEstudiante
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(544, 602);
            Controls.Add(label3);
            Controls.Add(btnSave);
            Controls.Add(tbGrade);
            Controls.Add(tbLastName);
            Controls.Add(tbName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblName1);
            Name = "AgregarEstudiante";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbGrade;
    }
}