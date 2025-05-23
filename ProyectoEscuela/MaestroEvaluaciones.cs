using DevExpress.XtraReports;
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
    public partial class MaestroEvaluaciones : Form
    {
        DateTime dateAugust = new DateTime(2024, 8, 1);
        int xPanel = 12, yPanel = 162;
        string opcion;
        int iID;

        public MaestroEvaluaciones(int id)
        {
            iID = id;
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            pInicio.Visible = true;
            pIndex.Controls.Clear();
            if (DateTime.Now.Month >= dateAugust.Month && DateTime.Now.Day >= dateAugust.Day)
            {
                int y = DateTime.Now.Year;
            }
            else
            {
                int y = DateTime.Now.Year;
            }
        }

        private void MaestroEvaluaciones_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 4; i++)
            {
                Color color = new Color();
                color = Color.LimeGreen;

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
                    case 1:
                        lblPeriodo.Text = "Primer trimestre: Noviembre";
                        break;
                    case 2:
                        lblPeriodo.Text = "Segundo trimestre: Marzo";
                        break;
                    case 3:
                        lblPeriodo.Text = "Tercer trimestre: Junio";
                        break;
                }

                pPeriodo.Click += new EventHandler(handlerComun_Click);
                btnCircle.Click += new EventHandler(handlerComun_Click);
                lblPeriodo.Click += new EventHandler(handlerComun_Click);

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
                opcion = controlName.Replace("pPeriodo", "");
            }
            else if (controlName.Contains("Circle"))
            {
                opcion = controlName.Replace("Circle", "");
            }
            else if (controlName.Contains("lblPeriodo"))
            {
                opcion = controlName.Replace("lblPeriodo", "");
            }

            if (!string.IsNullOrEmpty(opcion))
            {
                switch (opcion)
                {
                    case "1":
                        opcion = "Periodo Agosto - Noviembre";
                        break;
                    case "2":
                        opcion = "Periodo Diciembre - Marzo";
                        break;
                    case "3":
                        opcion = "Periodo Abril - Junio";
                        break;
                    default:
                        break;
                }
                AbrirFormulario(opcion);
            }
        }

        public void AbrirFormulario(string periodo)
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            OpcionesSisat newForm = new OpcionesSisat(iID, periodo);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }
    }
}
