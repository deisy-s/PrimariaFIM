using DevExpress.XtraRichEdit;
using DevExpress.XtraSpreadsheet.Model;
using Guna.UI2.WinForms;
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
    public partial class MaestroCalificaciones : Form
    {
        DateTime dateAugust = new DateTime(2024, 8, 1);
        DateTime dateNovember;
        DateTime dateMarch;
        DateTime dateJune;
        int xPanel = 12, yPanel = 162;
        String Reporte = "";
        int iID;

        public MaestroCalificaciones(int id)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            iID = id;
            if (DateTime.Now.Month >= dateAugust.Month && DateTime.Now.Day >= dateAugust.Day)
            {
                int y = DateTime.Now.Year;
                dateAugust = new DateTime(y, 8, 1);
                dateNovember = new DateTime(y, 11, 1);
                dateMarch = new DateTime(y + 1, 3, 1);
                dateJune = new DateTime(y + 1, 6, 1);
            } else {
                int y = DateTime.Now.Year;
                dateAugust = new DateTime(y - 1, 8, 1);
                dateNovember = new DateTime(y - 1, 11, 1);
                dateMarch = new DateTime(y, 3, 1);
                dateJune = new DateTime(y, 6, 1);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void MaestroCalificaciones_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                Color color = new Color();
                color = Color.DeepSkyBlue;
                switch (i)
                {
                    case 0:
                        if (DateTime.Now >= dateNovember)
                            color = Color.LimeGreen;
                        break;
                    case 1:
                        if (DateTime.Now >= dateMarch)
                            color = Color.LimeGreen;
                        break;
                    case 2:
                        if (DateTime.Now >= dateJune)
                            color = Color.LimeGreen;
                        break;
                }
                Guna2Panel pPeriodo = new Guna2Panel();
                pPeriodo.Location = new Point(xPanel, yPanel);
                pPeriodo.Height = 66;
                pPeriodo.Width = 1139;
                pPeriodo.BackColor = Color.White;
                pPeriodo.BorderRadius = 10;
                pPeriodo.BorderThickness = 1;
                pPeriodo.BorderColor = color;
                pPeriodo.Name = "pPeriodo" + i;

                Guna2CircleButton btnCircle = new Guna2CircleButton();
                btnCircle.Location = new Point(19, 20);
                btnCircle.Height = 35;
                btnCircle.Width = 35;
                btnCircle.FillColor = color;
                btnCircle.Name = "Circle" + i;

                Label lblPeriodo = new Label();
                lblPeriodo.Location = new Point(86, 20);
                lblPeriodo.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                lblPeriodo.ForeColor = Color.Black;
                lblPeriodo.Height = 28;
                lblPeriodo.Width = 400;
                lblPeriodo.Name = "lblPeriodo" + i;
                switch (i)
                {
                    case 0:
                        lblPeriodo.Text = "Primer trimestre: Noviembre";
                        break;
                    case 1:
                        lblPeriodo.Text = "Segundo trimestre: Marzo";
                        break;
                    case 2:
                        lblPeriodo.Text = "Tercer trimestre: Junio";
                        break;
                }

                if(color == Color.LimeGreen)
                {
                    pPeriodo.Click += new EventHandler(handlerComun_Click);
                    btnCircle.Click += new EventHandler(handlerComun_Click);
                    lblPeriodo.Click += new EventHandler(handlerComun_Click);
                }

                pInicio.Controls.Add(pPeriodo);
                pPeriodo.Controls.Add(btnCircle);
                pPeriodo.Controls.Add(lblPeriodo);

                yPanel += 69;
            }
        }

        private void handlerComun_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            string controlName = control.Name;

            if (controlName.Contains("pPeriodo"))
            {
                Reporte = controlName.Replace("pPeriodo", "");
            }
            else if (controlName.Contains("Circle"))
            {
                Reporte = controlName.Replace("Circle", "");
            }
            else if (controlName.Contains("lblPeriodo"))
            {
                Reporte = controlName.Replace("lblPeriodo", "");
            }
            if (!string.IsNullOrEmpty(Reporte))
            {
                switch (Reporte)
                {
                    case "0":
                        Reporte = "Agosto - Noviembre";
                        break;
                    case "1":
                        Reporte = "Diciembre - Marzo";
                        break;
                    case "2":
                        Reporte = "Abril - Junio";
                        break;
                    default:
                        break;
                }
                AbrirFormulario(Reporte);
            }
        }
        public void AbrirFormulario(string numReporte)
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            ListaCalificaciones newForm = new ListaCalificaciones(Reporte, iID);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }
    }
}
