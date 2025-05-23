using DevExpress.CodeParser;
using Guna.UI2.WinForms;
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
    public partial class MaestroGrupo : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        int iID, i = 1, grade = 0;
        string sGrade = "";

        public MaestroGrupo(int id)
        {
            InitializeComponent();
            iID = id;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            grade = teachClass.GetGrade(iID);
            switch (grade)
            {
                case 1:
                    sGrade = "Primero";
                    break;
                case 2:
                    sGrade = "Segundo";
                    break;
                case 3:
                    sGrade = "Tercero";
                    break;
                case 4:
                    sGrade = "Cuarto";
                    break;
                case 5:
                    sGrade = "Quinto";
                    break;
                case 6:
                    sGrade = "Sexto";
                    break;
            }
        }

        private void MaestroGrupo_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        private void LoadOptions()
        {
            pIndex.Visible = false;
            DataTable dt = new DataTable();
            int pnlY = 229, pnlX = 12;
            int btnY = 16, btnX = 935;
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
                lblGrade.Text = sGrade;
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

                Guna2Button BVer = new Guna2Button();

                BVer.Width = 122;
                BVer.Height = 36;
                BVer.Location = new Point(btnX, btnY);
                BVer.Name = "btnVer" + row[0].ToString();
                BVer.Text = "Ver";
                BVer.FillColor = Color.LightGreen;
                BVer.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                BVer.ForeColor = Color.Black;
                BVer.Image = Properties.Resources.image_removebg_preview__14_;
                BVer.BorderRadius = 5;
                BVer.BorderColor = Color.Green;
                BVer.BorderThickness = 1;

                BVer.Click += new EventHandler(handlerComun_Click);

                pInicio.Controls.Add(PAlumnos);
                PAlumnos.Controls.Add(iconAlumno);
                PAlumnos.Controls.Add(lblId);
                PAlumnos.Controls.Add(lblName);
                PAlumnos.Controls.Add(lblGrade);
                PAlumnos.Controls.Add(BVer);
                i++;
            }
        }

        private void handlerComun_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            string num = "";
            if (btn != null)
            {
                num = btn.Name.Replace("btnVer", "");
                pInicio.Visible = false;
                pnlSearch.Visible = false;
                pIndex.Visible = true;
                pIndex.Controls.Clear();
                DataTable dt = new DataTable();
                teachClass.GetStudentName(ref dt, Convert.ToInt16(num));
                string name = "";
                foreach(DataRow row in dt.Rows)
                {
                    name = row[1].ToString();
                }
                ListaAlumno newForm = new ListaAlumno(Convert.ToInt16(num), iID, name);
                newForm.TopLevel = false;
                newForm.FormBorderStyle = FormBorderStyle.None;
                newForm.Dock = DockStyle.Fill;
                pIndex.Controls.Add(newForm);
                newForm.Show();
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

                pInicio.Visible = true;
                pnlSearch.Visible = true;
                pIndex.Visible = false;
                pnlSearch.Controls.Clear();
                i = 1;

                DataTable dt = new DataTable();
                foreach (var id in lId)
                {
                    teachClass.GetStudent(ref dt, id);

                    int pnlY = 0, pnlX = 12;
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
                        lblId.Width = 50;
                        lblId.Name = "lblID" + row[0].ToString();

                        System.Windows.Forms.Label lblName = new System.Windows.Forms.Label();
                        lblName.Text = $"{row[2].ToString() + " " +row[1].ToString()}";
                        lblName.Location = new Point(225, 24);
                        lblName.Name = "lblName" + row[0].ToString();
                        lblName.Height = 83;
                        lblName.Width = 358;

                        System.Windows.Forms.Label lblGrade = new System.Windows.Forms.Label();
                        lblGrade.Text = sGrade;
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

                        Guna2Button BVer = new Guna2Button();

                        BVer.Width = 122;
                        BVer.Height = 36;
                        BVer.Location = new Point(btnX, btnY);
                        BVer.Name = "btnVer" + row[0].ToString();
                        BVer.Text = "Ver";
                        BVer.FillColor = Color.LightGreen;
                        BVer.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                        BVer.ForeColor = Color.Black;
                        BVer.Image = Properties.Resources.image_removebg_preview__14_;
                        BVer.BorderRadius = 5;
                        BVer.BorderColor = Color.Green;
                        BVer.BorderThickness = 1;

                        BVer.Click += new EventHandler(handlerComun_Click);

                        pnlSearch.Controls.Add(PAlumnos);
                        PAlumnos.Controls.Add(iconAlumno);
                        PAlumnos.Controls.Add(lblId);
                        PAlumnos.Controls.Add(lblName);
                        PAlumnos.Controls.Add(lblGrade);
                        PAlumnos.Controls.Add(BVer);
                    }
                    i++;
                }
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            pnlSearch.Visible = false;
            pInicio.Visible = true;
            LoadOptions();
        }
    }
}
