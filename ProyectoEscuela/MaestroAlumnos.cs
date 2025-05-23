using DevExpress.XtraGrid;
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
using System.Windows.Controls;
using DevExpress.Utils.Extensions;
using Guna.UI2.WinForms;
using DevExpress.XtraSpreadsheet.Layout;
using DevExpress.XtraMap.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid.Handler;
using Org.BouncyCastle.Asn1.Cmp;
using DevExpress.Mvvm.Native;

namespace ProyectoEscuela
{
    public partial class MaestroAlumnos : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        int iID, i = 1, grade;

        public MaestroAlumnos(int id)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            iID = id;
            pnlSearch.Visible = false;
        }

        private void MaestroAlumnos_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        private void LoadOptions()
        {
            i = 1;
            panel1.Controls.Clear();
            DataTable dt = new DataTable();
            int pnlY = 229, pnlX = 12;
            int btnY = 16, btnX = 848;
            grade = teachClass.GetGrade(iID);
            teachClass.GetStudentsList(ref dt, grade);
            foreach (DataRow row in dt.Rows)
            {
                Guna2Panel PAlumnos = new Guna2Panel();
                PAlumnos.Height = 66;
                PAlumnos.Width = 1165;
                PAlumnos.Location = new Point(pnlX, pnlY);
                pnlY += 68;
                PAlumnos.Name = "pnlAlumno" + row[0].ToString();
                PAlumnos.BackColor = Color.White;

                System.Windows.Forms.Label lblId = new System.Windows.Forms.Label();
                lblId.Text = $"{i}";
                lblId.Location = new Point(125, 24);
                lblId.Height = 83;
                lblId.Width = 50;
                lblId.Name = "lblID" + row[0].ToString();

                System.Windows.Forms.Label lblName = new System.Windows.Forms.Label();
                lblName.Text = $"{row[1].ToString()}";
                lblName.Location = new Point(225, 24);
                lblName.Name = "lblName" + row[0].ToString();
                lblName.Height = 83;
                lblName.Width = 358;

                System.Windows.Forms.Label lblGrade = new System.Windows.Forms.Label();
                lblGrade.Text = CheckGroup(grade.ToString());
                lblGrade.Location = new Point(626, 24);
                lblGrade.Name = "lblGrade" + row[0].ToString();
                lblGrade.Height = 83;
                lblGrade.Width = 150;

                Guna2Button iconAlumno = new Guna2Button();
                iconAlumno.Location = new Point(12, 7);
                iconAlumno.Height = 50;
                iconAlumno.Width = 50;
                iconAlumno.FillColor = Color.LightGreen;
                iconAlumno.Image = Properties.Resources.image_removebg_preview__6_;
                iconAlumno.Name = "icoAlumno" + row[0].ToString();
                iconAlumno.BorderRadius = 5;
                iconAlumno.BorderColor = Color.Green;
                iconAlumno.BorderThickness = 1;


                Guna2Button BEditar = new Guna2Button();

                BEditar.Width = 122;
                BEditar.Height = 36;
                BEditar.Location = new Point(830, btnY);
                BEditar.Name = "btnEditar" + row[0].ToString();
                BEditar.FillColor = Color.LightGreen;
                BEditar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                BEditar.ForeColor = Color.Black;
                BEditar.Image = Properties.Resources.image_removebg_preview__12_;
                BEditar.BorderRadius = 5;
                BEditar.BorderColor = Color.Green;
                BEditar.BorderThickness = 1;
                BEditar.Click += new EventHandler(handlerComun_Click);

                Guna2Button bEliminar = new Guna2Button();

                bEliminar.Width = 122;
                bEliminar.Height = 36;
                bEliminar.Location = new Point(1000, btnY);
                bEliminar.Name = "btnDelete" + row[0].ToString();
                bEliminar.FillColor = Color.Salmon;
                bEliminar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                bEliminar.ForeColor = Color.Black;
                bEliminar.Image = Properties.Resources.image_removebg_preview__13_;
                bEliminar.BorderRadius = 5;
                bEliminar.BorderColor = Color.Red;
                bEliminar.BorderThickness = 1;
                bEliminar.Click += new EventHandler(handlerComun_Click);

                panel1.Controls.Add(PAlumnos);
                PAlumnos.Controls.Add(iconAlumno);
                PAlumnos.Controls.Add(lblId);
                PAlumnos.Controls.Add(lblName);
                PAlumnos.Controls.Add(lblGrade);
                PAlumnos.Controls.Add(BEditar);
                PAlumnos.Controls.Add(bEliminar);
                i++;
            }

            Guna2Panel pAgregar = new Guna2Panel();
            pAgregar.Height = 70;
            pAgregar.Width = 1165;
            pAgregar.Location = new Point(pnlX, pnlY);
            pnlY += 68;
            pAgregar.Name = "pnlAdd";
            pAgregar.BackColor = Color.White;

            Guna2Button iconAgregar = new Guna2Button();
            iconAgregar.Location = new Point(12, 7);
            iconAgregar.Height = 50;
            iconAgregar.Width = 50;
            iconAgregar.FillColor = Color.LightSkyBlue;
            iconAgregar.Image = Properties.Resources.image_removebg_preview__11_;
            iconAgregar.Name = "icoAdd";
            iconAgregar.BorderRadius = 5;
            iconAgregar.BorderColor = Color.SteelBlue;
            iconAgregar.BorderThickness = 1;

            System.Windows.Forms.Label lblAdd = new System.Windows.Forms.Label();
            lblAdd.Text = "Agregar nuevo alumno";
            lblAdd.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            lblAdd.Location = new Point(100, 24);
            lblAdd.Name = "lblAdd";
            lblAdd.Width = 358;
            lblAdd.Height = 30;

            pAgregar.Click += new EventHandler(Add_Click);
            iconAgregar.Click += new EventHandler(Add_Click);
            lblAdd.Click += new EventHandler(Add_Click);

            panel1.Controls.Add(pAgregar);
            pAgregar.Controls.Add(iconAgregar);
            pAgregar.Controls.Add(lblAdd);
        }

        private string CheckGroup(string num)
        {
            switch (num)
            {
                case "1":
                    num = "Primero";
                    break;
                case "2":
                    num = "Segundo";
                    break;
                case "3":
                    num = "Tercero";
                    break;
                case "4":
                    num = "Cuarto";
                    break;
                case "5":
                    num = "Quinto";
                    break;
                case "6":
                    num = "Sexto";
                    break;
                default:
                    break;
            }
            return num;
        }

        private void handlerComun_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            string num = "";
            if (btn != null)
            {
                if (btn.Name.Contains("btnEditar"))
                {
                    num = btn.Name.Replace("btnEditar", "");
                    Modify(Convert.ToInt16(num));
                }
                else if (btn.Name.Contains("btnDelete"))
                {
                    num = btn.Name.Replace("btnDelete", "");
                    DataTable dt = new DataTable();
                    teachClass.GetStudent(ref dt, Convert.ToInt16(num));
                    string name = "", lname = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        name = row[1].ToString();
                        lname = row[2].ToString();
                    }
                    DialogResult result = MessageBox.Show($"¿Esta seguro que desea eliminar a {name} {lname}?", "Advertencia", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Delete(Convert.ToInt16(num));
                    }
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            int id = teachClass.LastID() + 1;
            int grade = teachClass.GetGrade(iID);
            AgregarEstudiante add = new AgregarEstudiante(id, grade);
            var check = add.ShowDialog();
            if (check == DialogResult.OK || check == DialogResult.Cancel)
            {
                LoadOptions();
            }
        }

        private void Modify(int id)
        {
            string name = string.Empty, lname = string.Empty, grade = string.Empty;
            DataTable dt = new DataTable();
            teachClass.GetStudent(ref dt, id);
            foreach (DataRow row in dt.Rows)
            {
                name = row[1].ToString();
                lname = row[2].ToString();
                grade = row[4].ToString();
            }
            ModificarEstudiante modify = new ModificarEstudiante(id, name, lname, grade);
            var check = modify.ShowDialog();
            if (check == DialogResult.OK || check == DialogResult.Cancel)
            {
                LoadOptions();
            }
        }

        private void Delete(int id)
        {
            string name = string.Empty, lname = string.Empty;
            DataTable dt = new DataTable();
            teachClass.GetStudent(ref dt, id);
            foreach (DataRow row in dt.Rows)
            {
                name = row[1].ToString();
                lname = row[2].ToString();
            }

            if (teachClass.DeleteStudent(id))
            {
                if (teachClass.UpdateGroup(teachClass.GetStudentGrade(id)))
                {
                    MessageBox.Show("Se eliminó " + name + " " + lname + " de manera exitosa");
                    LoadOptions();
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
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != string.Empty)
            {
                List<int> lId = teachClass.GetIDName(tbSearch.Text, teachClass.GetGrade(iID));
                if (lId.Count == 0)
                {
                    lId = teachClass.GetIDLastName(tbSearch.Text, teachClass.GetGrade(iID));
                    if (lId.Count == 0)
                    {
                        MessageBox.Show("No se ha podido encontrar una coincidencia", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                panel1.Visible = false;
                pnlSearch.Visible = true;
                pnlSearch.Controls.Clear();
                i = 1;

                DataTable dt = new DataTable();
                foreach (var id in lId)
                {
                    teachClass.GetStudent(ref dt, id);

                    int pnlY = 229, pnlX = 12;
                    int btnY = 16, btnX = 848;
                    foreach (DataRow row in dt.Rows)
                    {
                        Guna2Panel PAlumnos = new Guna2Panel();
                        PAlumnos.Height = 66;
                        PAlumnos.Width = 1165;
                        PAlumnos.Location = new Point(pnlX, pnlY);
                        pnlY += 68;
                        PAlumnos.Name = "pnlAlumno" + row[0].ToString();
                        PAlumnos.BackColor = Color.White;

                        System.Windows.Forms.Label lblId = new System.Windows.Forms.Label();
                        lblId.Text = $"{i}";
                        lblId.Location = new Point(125, 24);
                        lblId.Height = 83;
                        lblId.Width = 24;
                        lblId.Name = "lblID" + row[0].ToString();

                        System.Windows.Forms.Label lblName = new System.Windows.Forms.Label();
                        lblName.Text = $"{row[2].ToString() + " " + row[1].ToString()}";
                        lblName.Location = new Point(225, 24);
                        lblName.Name = "lblName" + row[0].ToString();
                        lblName.Width = 358;
                        lblName.Height = 83;

                        System.Windows.Forms.Label lblGrade = new System.Windows.Forms.Label();
                        lblGrade.Text = CheckGroup(grade.ToString());
                        lblGrade.Location = new Point(626, 24);
                        lblGrade.Name = "lblGrade" + row[0].ToString();
                        lblGrade.Height = 83;
                        lblGrade.Width = 150;

                        Guna2Button iconAlumno = new Guna2Button();
                        iconAlumno.Location = new Point(12, 7);
                        iconAlumno.Height = 50;
                        iconAlumno.Width = 50;
                        iconAlumno.FillColor = Color.LightGreen;
                        iconAlumno.Image = Properties.Resources.image_removebg_preview__6_;
                        iconAlumno.Name = "icoAlumno" + row[0].ToString();
                        iconAlumno.BorderRadius = 5;
                        iconAlumno.BorderColor = Color.Green;
                        iconAlumno.BorderThickness = 1;


                        Guna2Button BEditar = new Guna2Button();

                        BEditar.Width = 122;
                        BEditar.Height = 36;
                        BEditar.Location = new Point(830, btnY);
                        BEditar.Name = "btnEditar" + row[0].ToString();
                        BEditar.FillColor = Color.LightGreen;
                        BEditar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                        BEditar.ForeColor = Color.Black;
                        BEditar.Image = Properties.Resources.image_removebg_preview__12_;
                        BEditar.BorderRadius = 5;
                        BEditar.BorderColor = Color.Green;
                        BEditar.BorderThickness = 1;
                        BEditar.Click += new EventHandler(handlerComun_Click);

                        Guna2Button bEliminar = new Guna2Button();

                        bEliminar.Width = 122;
                        bEliminar.Height = 36;
                        bEliminar.Location = new Point(1000, btnY);
                        bEliminar.Name = "btnDelete" + row[0].ToString();
                        bEliminar.FillColor = Color.Salmon;
                        bEliminar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                        bEliminar.ForeColor = Color.Black;
                        bEliminar.Image = Properties.Resources.image_removebg_preview__13_;
                        bEliminar.BorderRadius = 5;
                        bEliminar.BorderColor = Color.Red;
                        bEliminar.BorderThickness = 1;
                        bEliminar.Click += new EventHandler(handlerComun_Click);

                        pnlSearch.Controls.Add(PAlumnos);
                        PAlumnos.Controls.Add(iconAlumno);
                        PAlumnos.Controls.Add(lblId);
                        PAlumnos.Controls.Add(lblName);
                        PAlumnos.Controls.Add(lblGrade);
                        PAlumnos.Controls.Add(BEditar);
                        PAlumnos.Controls.Add(bEliminar);
                    }
                    i++;
                }
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            pnlSearch.Visible = false;
            panel1.Visible = true;
            LoadOptions();
        }
    }
}
