using DevExpress.Charts.Native;
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
    public partial class AgregarEstudiante : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        int iID;

        public AgregarEstudiante(int id, int grade)
        {
            InitializeComponent();
            iID = id;
            tbGrade.Text = grade.ToString();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text != string.Empty && tbLastName.Text != string.Empty && tbGrade.Text != string.Empty)
            {
                if (Convert.ToInt16(tbGrade.Text) <= 6 && Convert.ToInt16(tbGrade.Text) > 0)
                {
                    if (teachClass.AddStudent(iID, tbName.Text, tbLastName.Text, Convert.ToInt16(tbGrade.Text)))
                    {
                        if (teachClass.UpdateGroup(Convert.ToInt16(tbGrade.Text)))
                        {
                            tbName.Text = string.Empty;
                            tbLastName.Text = string.Empty;
                            iID++;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
