namespace ProyectoEscuela
{
    partial class ModificarLoginMaestro
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
            cbMostrarContra = new CheckBox();
            tbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            tbUsername = new Guna.UI2.WinForms.Guna2TextBox();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // cbMostrarContra
            // 
            cbMostrarContra.AutoSize = true;
            cbMostrarContra.Font = new Font("Century Gothic", 6F);
            cbMostrarContra.Location = new Point(250, 316);
            cbMostrarContra.Name = "cbMostrarContra";
            cbMostrarContra.Size = new Size(150, 21);
            cbMostrarContra.TabIndex = 78;
            cbMostrarContra.Text = "Mostrar contraseña";
            cbMostrarContra.UseVisualStyleBackColor = true;
            cbMostrarContra.CheckedChanged += cbMostrarContra_CheckedChanged;
            // 
            // tbPassword
            // 
            tbPassword.BorderColor = Color.RoyalBlue;
            tbPassword.BorderRadius = 10;
            tbPassword.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tbPassword.CustomizableEdges = customizableEdges1;
            tbPassword.DefaultText = "";
            tbPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPassword.FillColor = SystemColors.ControlLightLight;
            tbPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPassword.Font = new Font("Segoe UI", 9F);
            tbPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPassword.Location = new Point(127, 252);
            tbPassword.Margin = new Padding(6, 8, 6, 8);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.PlaceholderText = "";
            tbPassword.SelectedText = "";
            tbPassword.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbPassword.Size = new Size(273, 53);
            tbPassword.TabIndex = 70;
            // 
            // tbUsername
            // 
            tbUsername.BorderColor = Color.RoyalBlue;
            tbUsername.BorderRadius = 10;
            tbUsername.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tbUsername.CustomizableEdges = customizableEdges3;
            tbUsername.DefaultText = "";
            tbUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbUsername.FillColor = SystemColors.ControlLightLight;
            tbUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername.Font = new Font("Segoe UI", 9F);
            tbUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername.Location = new Point(127, 153);
            tbUsername.Margin = new Padding(6, 8, 6, 8);
            tbUsername.Name = "tbUsername";
            tbUsername.PasswordChar = '\0';
            tbUsername.PlaceholderText = "";
            tbUsername.SelectedText = "";
            tbUsername.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbUsername.Size = new Size(273, 53);
            tbUsername.TabIndex = 69;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(127, 220);
            label4.Name = "label4";
            label4.Size = new Size(154, 28);
            label4.TabIndex = 77;
            label4.Text = "Contraseña:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(127, 122);
            label5.Name = "label5";
            label5.Size = new Size(104, 28);
            label5.TabIndex = 76;
            label5.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Agency FB", 24F, FontStyle.Bold);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(94, 4);
            label3.Name = "label3";
            label3.Size = new Size(267, 118);
            label3.TabIndex = 75;
            label3.Text = "Modificar Inicio\r\nde Sesión";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 9;
            btnSave.CustomizableEdges = customizableEdges5;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.RoyalBlue;
            btnSave.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(186, 368);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSave.Size = new Size(141, 47);
            btnSave.TabIndex = 74;
            btnSave.Text = "GUARDAR";
            btnSave.Click += btnSave_Click;
            // 
            // ModificarLoginMaestro
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(526, 458);
            Controls.Add(cbMostrarContra);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(btnSave);
            Name = "ModificarLoginMaestro";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbMostrarContra;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private Guna.UI2.WinForms.Guna2TextBox tbUsername;
        private Label label4;
        private Label label5;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}