namespace ProyectoEscuela
{
    partial class MaestroEvaluaciones
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
            panel1 = new Panel();
            pInicio = new Panel();
            guna2Button10 = new Guna.UI2.WinForms.Guna2Button();
            panel3 = new Panel();
            pIndex = new Panel();
            panel1.SuspendLayout();
            pInicio.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(pInicio);
            panel1.Controls.Add(pIndex);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1189, 682);
            panel1.TabIndex = 10;
            // 
            // pInicio
            // 
            pInicio.AutoScroll = true;
            pInicio.Controls.Add(guna2Button10);
            pInicio.Controls.Add(panel3);
            pInicio.Location = new Point(0, 0);
            pInicio.Name = "pInicio";
            pInicio.Size = new Size(1189, 682);
            pInicio.TabIndex = 38;
            // 
            // guna2Button10
            // 
            guna2Button10.BackColor = Color.Transparent;
            guna2Button10.BorderColor = Color.Transparent;
            guna2Button10.BorderRadius = 10;
            guna2Button10.BorderThickness = 1;
            guna2Button10.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button10.CheckedState.BorderColor = Color.White;
            guna2Button10.CheckedState.FillColor = Color.White;
            guna2Button10.CustomizableEdges = customizableEdges1;
            guna2Button10.DisabledState.BorderColor = Color.DarkGray;
            guna2Button10.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button10.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button10.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button10.FillColor = SystemColors.Control;
            guna2Button10.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button10.ForeColor = Color.Black;
            guna2Button10.Image = Properties.Resources.image_removebg_preview__4_1;
            guna2Button10.Location = new Point(450, 19);
            guna2Button10.Name = "guna2Button10";
            guna2Button10.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button10.Size = new Size(285, 65);
            guna2Button10.TabIndex = 31;
            guna2Button10.Text = "Evaluaciones SisAT";
            guna2Button10.UseTransparentBackground = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Location = new Point(0, 90);
            panel3.Name = "panel3";
            panel3.Size = new Size(1189, 60);
            panel3.TabIndex = 32;
            // 
            // pIndex
            // 
            pIndex.Location = new Point(0, 0);
            pIndex.Name = "pIndex";
            pIndex.Size = new Size(1189, 682);
            pIndex.TabIndex = 39;
            // 
            // MaestroEvaluaciones
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1189, 685);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MaestroEvaluaciones";
            Text = "MaestroEvaluaciones";
            Load += MaestroEvaluaciones_Load;
            panel1.ResumeLayout(false);
            pInicio.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pInicio;
        private Guna.UI2.WinForms.Guna2Button guna2Button10;
        private Panel panel3;
        private Panel pIndex;
    }
}