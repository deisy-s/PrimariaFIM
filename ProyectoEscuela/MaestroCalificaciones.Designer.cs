namespace ProyectoEscuela
{
    partial class MaestroCalificaciones
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
            pInicio = new Panel();
            guna2Button10 = new Guna.UI2.WinForms.Guna2Button();
            panel3 = new Panel();
            pIndex = new Panel();
            pInicio.SuspendLayout();
            SuspendLayout();
            // 
            // pInicio
            // 
            pInicio.Controls.Add(guna2Button10);
            pInicio.Controls.Add(panel3);
            pInicio.Location = new Point(0, 0);
            pInicio.Name = "pInicio";
            pInicio.Size = new Size(1189, 682);
            pInicio.TabIndex = 41;
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
            guna2Button10.Image = Properties.Resources.image_removebg_preview__5_;
            guna2Button10.Location = new Point(450, 18);
            guna2Button10.Name = "guna2Button10";
            guna2Button10.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button10.Size = new Size(286, 65);
            guna2Button10.TabIndex = 31;
            guna2Button10.Text = "Calificaciones";
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
            pIndex.TabIndex = 43;
            // 
            // MaestroCalificaciones
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 682);
            Controls.Add(pInicio);
            Controls.Add(pIndex);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MaestroCalificaciones";
            Text = "MaestroCalificaciones";
            Load += MaestroCalificaciones_Load;
            pInicio.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pInicio;
        private Guna.UI2.WinForms.Guna2Button guna2Button10;
        private Panel panel3;
        private Panel pIndex;
    }
}