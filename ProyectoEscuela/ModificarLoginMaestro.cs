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
    public partial class ModificarLoginMaestro : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        int iID;

        public ModificarLoginMaestro(int id)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            iID = id;
            DataTable dt = new DataTable();
            teachClass.TeacherLogin(ref dt, id);
            foreach (DataRow row in dt.Rows)
            {
                tbUsername.Text = row[0].ToString();
                tbPassword.Text = row[1].ToString();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbPassword.Text))
            {
                if (!teachClass.CheckLoginInfo(tbUsername.Text))
                {
                    if (teachClass.ModifyTeacher(iID, tbUsername.Text, tbPassword.Text))
                    {
                        MessageBox.Show("Información de login modificada exitosamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error: {teachClass.sError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("El nombre de usuario ingresado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
