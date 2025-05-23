using DevExpress.XtraScheduler.Drawing;
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
    public partial class ModificarEstudiante : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        int iID;

        public ModificarEstudiante(int id, string name, string lname, string group)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            iID = id;
            tbName.Text = name;
            tbLastName.Text = lname;
            tbGrupo.Text = group;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbGrupo.Text))
            {
                if(Convert.ToInt16(tbGrupo.Text) <= 6 && Convert.ToInt16(tbGrupo.Text) > 0)
                {
                    if (teachClass.ModifyStudent(iID, tbName.Text, tbLastName.Text, Convert.ToInt16(tbGrupo.Text)))
                    {
                        MessageBox.Show("Información de alumno modificada exitosamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error: {teachClass.sError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Solamente se permiten grados entre 1-6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarEstudiante_Load(object sender, EventArgs e)
        {

        }
    }
}
