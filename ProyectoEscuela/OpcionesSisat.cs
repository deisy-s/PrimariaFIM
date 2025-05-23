using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEscuela
{
    public partial class OpcionesSisat : Form
    {
        string NumBoton = "", sPeriodo;
        int iID;

        public OpcionesSisat(int id, string periodo)
        {
            iID = id;
            sPeriodo = periodo;
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            pInicio.Visible = true;
        }

        private void Opcion1_Click(object sender, EventArgs e)
        {
            NumBoton = Opcion1.Name.Replace("Opcion", "");
            AbrirFormulario(NumBoton);
        }

        private void opcion2_Click(object sender, EventArgs e)
        {
            NumBoton = opcion2.Name.Replace("opcion", "");
            AbrirFormulario(NumBoton);
        }

        private void opcion3_Click(object sender, EventArgs e)
        {
            NumBoton = opcion3.Name.Replace("opcion", "");
            AbrirFormulario(NumBoton);
        }

        public void AbrirFormulario(string num)
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            ListaSisat newForm = new ListaSisat(Convert.ToInt32(num), iID, sPeriodo);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }

        private void OtraOpcion1_Click(object sender, EventArgs e)
        {
            NumBoton = OtraOpcion1.Name.Replace("OtraOpcion", "");
            AbrirFormulario(NumBoton);
        }

        private void OtraOpcion2_Click(object sender, EventArgs e)
        {
            NumBoton = OtraOpcion2.Name.Replace("OtraOpcion", "");
            AbrirFormulario(NumBoton);
        }

        private void OtraOpcion3_Click(object sender, EventArgs e)
        {
            NumBoton = OtraOpcion3.Name.Replace("OtraOpcion", "");
            AbrirFormulario(NumBoton);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
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
    }
}
