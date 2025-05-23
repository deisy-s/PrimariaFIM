using DevExpress.XtraSpreadsheet.Commands.Internal;
using ReglasDeNegocio;
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
    public partial class ListaGrupos : Form
    {
        MySQLDirector direClass = new MySQLDirector();
        int iGrupo, i;

        public ListaGrupos(int group)
        {
            InitializeComponent();
            iGrupo = group;
            switch (iGrupo)
            {
                case 1:
                    lblTitulo.Text = "Primer Grado";
                    break;
                case 2:
                    lblTitulo.Text = "Segundo Grado";
                    break;
                case 3:
                    lblTitulo.Text = "Tercer Grado";
                    break;
                case 4:
                    lblTitulo.Text = "Cuarto Grado";
                    break;
                case 5:
                    lblTitulo.Text = "Quinto Grado";
                    break;
                case 6:
                    lblTitulo.Text = "Sexto Grado";
                    break;
            }
        }

        private void ListaGrupos_Load(object sender, EventArgs e)
        {
            i = 1;
            dgv1.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 6, FontStyle.Bold);

            DataTable dt = new DataTable();
            direClass.GetGroup(ref dt, iGrupo);
            foreach (DataRow row in dt.Rows)
            {
                dgv1.Rows.Add(i, row[0].ToString(), iGrupo, row[1].ToString());
                i++;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            DirectorGrupos newForm = new DirectorGrupos();
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }
    }
}
