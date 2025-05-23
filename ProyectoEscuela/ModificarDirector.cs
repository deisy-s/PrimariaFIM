using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.CodeParser;
using ReglasDeNegocio;

namespace ProyectoEscuela
{
    public partial class ModificarDirector : Form
    {
        MySQLDirector direClass = new MySQLDirector();
        MySQLMaestro teachClass = new MySQLMaestro();
        string sOgUser;

        public ModificarDirector()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            DataTable dt = new DataTable();
            direClass.GetPrincipal(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                tbName.Text = row[1].ToString();
                tbLastName.Text = row[2].ToString();
                tbUsername.Text = row[3].ToString();
                sOgUser = row[3].ToString();
                tbPassword.Text = row[4].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbPassword.Text))
            {
                if(teachClass.CheckLoginInfo(tbUsername.Text) && sOgUser != tbUsername.Text)
                {
                    MessageBox.Show("El nombre de usuario ingresado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    if (direClass.ModifyPrincipal(tbName.Text, tbLastName.Text, tbUsername.Text, tbPassword.Text))
                    {
                        MessageBox.Show("Información de director modificada exitosamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error: {direClass.sError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbName_Enter(object sender, EventArgs e)
        {
            if (tbName.Text == "Nombre")
            {
                tbName.Text = string.Empty;
            }
        }

        private void tbLastName_Enter(object sender, EventArgs e)
        {
            if (tbLastName.Text == "Apellido")
            {
                tbLastName.Text = string.Empty;
            }
        }

        private void cbMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            // Evaluar el estado del comboBox de 'Mostrar contraseña'
            if (cbMostrarContra.Checked)
            {
                // Si se encuentra seleccionada la casilla, no reemplazar la contraseña con un caracter especial
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*';
            }
        }
    }
}
