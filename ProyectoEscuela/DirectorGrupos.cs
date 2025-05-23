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
    public partial class DirectorGrupos : Form
    {
        public DirectorGrupos()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
        }

        private void OpenList(int group)
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            ListaGrupos newForm = new ListaGrupos(group);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            OpenList(1);
        }
        private void lblPrimero_Click(object sender, EventArgs e)
        {
            OpenList(1);
        }

        private void pPrimero_Click(object sender, EventArgs e)
        {
            OpenList(1);
        }
        private void btnSegundo_Click(object sender, EventArgs e)
        {
            OpenList(2);
        }
        private void lblSegundo_Click(object sender, EventArgs e)
        {
            OpenList(2);
        }
        private void pSegundo_Click(object sender, EventArgs e)
        {
            OpenList(2);
        }

        private void btnTercero_Click(object sender, EventArgs e)
        {
            OpenList(3);
        }
        private void lblTercero_Click(object sender, EventArgs e)
        {
            OpenList(3);
        }

        private void pTercero_Click(object sender, EventArgs e)
        {
            OpenList(3);
        }
        private void btnCuarto_Click(object sender, EventArgs e)
        {
            OpenList(4);
        }
        private void lblCuarto_Click(object sender, EventArgs e)
        {
            OpenList(4);
        }
        private void pCuarto_Click(object sender, EventArgs e)
        {
            OpenList(4);
        }

        private void btnQuinto_Click(object sender, EventArgs e)
        {
            OpenList(5);
        }
        private void lblQuinto_Click(object sender, EventArgs e)
        {
            OpenList(5);
        }

        private void pQuinto_Click(object sender, EventArgs e)
        {
            OpenList(5);
        }
        private void btnSexto_Click(object sender, EventArgs e)
        {
            OpenList(6);
        }
        private void lblSexto_Click(object sender, EventArgs e)
        {
            OpenList(6);
        }
        private void pSexto_Click(object sender, EventArgs e)
        {
            OpenList(6);
        }
    }
}
