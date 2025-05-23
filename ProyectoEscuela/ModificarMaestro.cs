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
    public partial class ModificarMaestro : Form
    {
        MySQLDirector direClass = new MySQLDirector();
        MySQLMaestro teachClass = new MySQLMaestro();
        int iId;
        string sOgUser = "";

        public ModificarMaestro(int id, string name, string lname, string grade)
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            InitializeComponent();
            tbName.Text = name;
            tbLastName.Text = lname;
            tbGrade.Text = grade;
            iId = id;
            DataTable dt = new DataTable();
            teachClass.TeacherLogin(ref dt, iId);
            foreach (DataRow row in dt.Rows)
            {
                tbUsername.Text = row[0].ToString();
                sOgUser = row[0].ToString();
                tbPassword.Text = row[1].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text != string.Empty && tbLastName.Text != string.Empty && tbGrade.Text != string.Empty && tbUsername.Text != string.Empty && tbPassword.Text != string.Empty)
            {
                int grade = Convert.ToInt16(tbGrade.Text);
                if (grade <= 6 && grade > 0)
                {
                    if (teachClass.CheckLoginInfo(tbUsername.Text) && sOgUser != tbUsername.Text)
                    {
                        MessageBox.Show("El nombre de usuario ingresado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (direClass.ModifyTeacher(iId, tbName.Text, tbLastName.Text, Convert.ToInt16(tbGrade.Text), tbUsername.Text, tbPassword.Text))
                        {
                            MessageBox.Show("Información de maestro modificada exitosamente");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error: " + direClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Solamente se permiten grados entre 1-6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 13 && e.KeyChar != 11)
            {
                // Si no es un número ni la tecla de retroceso, cancela el evento de pulsación de tecla
                e.Handled = true;
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
