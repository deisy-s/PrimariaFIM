using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReglasDeNegocio;

namespace ProyectoEscuela
{
    public partial class Maestro : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        int iID;
        bool arrastre = false;
        Point startPoint = new Point(0, 0);

        public Maestro(int id)
        {
            InitializeComponent();
            iID = id;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
        }

        private void Maestro_Load(object sender, EventArgs e)
        {
            pIndex.Controls.Clear();
            pInicio.Visible = true;
            lblNombre.Text = teachClass.GetName(iID);
            btnAlumnos2.Checked = false;
            btnGrupo2.Checked = false;
            btnCalificaciones2.Checked = false;
            btnSisat.Checked = false;
        }
        private void btnGrupo2_Click(object sender, EventArgs e)
        {
            abrirGrupos();
        }

        public void abrirSiSat()
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            MaestroEvaluaciones newForm = new MaestroEvaluaciones(iID);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }

        public void abrirCalificaciones()
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            MaestroCalificaciones newForm = new MaestroCalificaciones(iID);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }

        public void abrirGrupos()
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            MaestroGrupo newForm = new MaestroGrupo(iID);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }

        public void abrirAlumnos()
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            MaestroAlumnos newForm = new MaestroAlumnos(iID);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }


        private void btnAlumnos2_Click(object sender, EventArgs e)
        {
            abrirAlumnos();
        }

        private void btnCalificaciones2_Click(object sender, EventArgs e)
        {
            abrirCalificaciones();
        }

        private void btnSisAT2_Click(object sender, EventArgs e)
        {
            abrirSiSat();
        }

        private void btnGrupo3_Click(object sender, EventArgs e)
        {
            abrirGrupos();
        }

        private void btnAlumnos3_Click(object sender, EventArgs e)
        {
            abrirAlumnos();
        }

        private void btnCalificaciones3_Click(object sender, EventArgs e)
        {
            abrirCalificaciones();
        }

        private void btnSisAT3_Click(object sender, EventArgs e)
        {
            abrirSiSat();
        }

        private void btnCalificaciones_Click_1(object sender, EventArgs e)
        {
            abrirCalificaciones();
        }

        private void btnAlumnos_Click_1(object sender, EventArgs e)
        {
            abrirAlumnos();
        }

        private void btnGrupo_Click_1(object sender, EventArgs e)
        {
            abrirGrupos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                login.ShowDialog();
            }
        }

        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            pIndex.Controls.Clear();
            pInicio.Visible = true;
            btnAlumnos2.Checked = false;
            btnGrupo2.Checked = false;
            btnCalificaciones2.Checked = false;
            btnSisAT2.Checked = false;
        }

        private void btnSisat_Click(object sender, EventArgs e)
        {
            abrirSiSat();
        }

        private void btnModificarMaestro_Click(object sender, EventArgs e)
        {
            ModificarLoginMaestro modify = new ModificarLoginMaestro(iID);
            modify.ShowDialog();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            arrastre = false;
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            arrastre = true;
            startPoint = e.Location;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastre)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
