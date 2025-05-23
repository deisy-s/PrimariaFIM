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
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace ProyectoEscuela
{
    public partial class DirectorEvaluaciones : Form
    {
        MySQLDirector direClass = new MySQLDirector();
        string sCiclo = "", y1 = "", y2 = "";

        public DirectorEvaluaciones()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new System.Drawing.Font("Century Gothic", 12, FontStyle.Bold);

            DateTime date1 = new DateTime(2024, 8, 1);
            if (DateTime.Now.Month >= date1.Month && DateTime.Now.Day >= date1.Day)
            {
                sCiclo = $"{DateTime.Now.Year}-{DateTime.Now.Year + 1}";
                y1 = $"{DateTime.Now.Year}";
                y2 = $"{DateTime.Now.Year + 1}";
            }
            else
            {
                sCiclo = $"{DateTime.Now.Year - 1}-{DateTime.Now.Year}";
                y1 = $"{DateTime.Now.Year - 1}";
                y2 = $"{DateTime.Now.Year}";
            }
        }

        private void DirectorEvaluaciones_Load(object sender, EventArgs e)
        {
            int xPanel = 12, yPanel = 180;
            int btnY = 12, btnX = 630;

            for (int i = 0; i < 5; i++)
            {
                System.Drawing.Color color = new System.Drawing.Color();
                color = System.Drawing.Color.DeepSkyBlue;
                Guna2Panel pPeriodo = new Guna2Panel();
                pPeriodo.Location = new System.Drawing.Point(xPanel, yPanel);
                pPeriodo.Height = 66;
                pPeriodo.Width = 1145;
                pPeriodo.BackColor = System.Drawing.Color.White;
                pPeriodo.BorderThickness = 1;
                pPeriodo.BorderColor = color;
                pPeriodo.Name = "pPeriodo" + i;

                Guna2CircleButton btnCircle = new Guna2CircleButton();
                btnCircle.Location = new System.Drawing.Point(19, 20-2);
                btnCircle.Height = 35;
                btnCircle.Width = 35;
                btnCircle.FillColor = color;
                btnCircle.Name = "Circle" + i;

                Label lblPeriodo = new Label();
                lblPeriodo.Location = new System.Drawing.Point(86, 20);
                lblPeriodo.Font = new System.Drawing.Font("Century Gothic", 12, FontStyle.Bold);
                lblPeriodo.ForeColor = System.Drawing.Color.Black;
                lblPeriodo.Height = 28;
                lblPeriodo.Width = 450;
                lblPeriodo.Name = "lblPeriodo" + i;
                switch (i)
                {
                    case 0:
                        lblPeriodo.Text = "Tercer trimestre: Junio " + y1;
                        break;
                    case 1:
                        lblPeriodo.Text = "Diagnóstico " + y1;
                        break;
                    case 2:
                        lblPeriodo.Text = "Primer trimestre: Noviembre " + y1;
                        break;
                    case 3:
                        lblPeriodo.Text = "Segundo trimestre: Marzo " + y2;
                        break;
                    case 4:
                        lblPeriodo.Text = "Tercer trimestre: Junio " + y2;
                        break;
                }

                Guna2Button bCM = new Guna2Button();
                bCM.Width = 150;
                bCM.Height = 45;
                bCM.Location = new System.Drawing.Point(btnX, btnY);
                bCM.Name = "btnCM" + i;
                bCM.Text = "Cálculo Mental";
                bCM.FillColor = System.Drawing.Color.IndianRed;
                bCM.Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold);
                bCM.ForeColor = System.Drawing.Color.White;
                bCM.BorderRadius = 5;
                bCM.BorderColor = System.Drawing.Color.LightCoral;
                bCM.BorderThickness = 1;

                Guna2Button bPT = new Guna2Button();
                bPT.Width = 150;
                bPT.Height = 45;
                bPT.Location = new System.Drawing.Point(btnX+160, btnY);
                bPT.Name = "btnPT" + i;
                bPT.Text = "Producción de textos";
                bPT.FillColor = System.Drawing.Color.FromArgb(94, 148,255);
                bPT.Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold);
                bPT.ForeColor = System.Drawing.Color.White;
                bPT.BorderRadius = 5;
                bPT.BorderColor = System.Drawing.Color.LightBlue;
                bPT.BorderThickness = 1;

                Guna2Button bTL = new Guna2Button();
                bTL.Width = 150;
                bTL.Height = 45;
                bTL.Location = new System.Drawing.Point(btnX + 320, btnY);
                bTL.Name = "btnTL" + i;
                bTL.Text = "Toma de lectura";
                bTL.FillColor = System.Drawing.Color.DarkSeaGreen;
                bTL.Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold);
                bTL.ForeColor = System.Drawing.Color.White;
                bTL.BorderRadius = 5;
                bTL.BorderColor = System.Drawing.Color.Green;
                bTL.BorderThickness = 1;

                bCM.Click += new EventHandler(btnCM_Click);
                bPT.Click += new EventHandler(btnPT_Click);
                bTL.Click += new EventHandler(btnTL_Click);

                pInicio.Controls.Add(pPeriodo);
                pPeriodo.Controls.Add(btnCircle);
                pPeriodo.Controls.Add(lblPeriodo);
                pPeriodo.Controls.Add(bCM);
                pPeriodo.Controls.Add(bPT);
                pPeriodo.Controls.Add(bTL);

                yPanel += 69;
            }
        }

        private void btnCM_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)
            {
                if (btn.Name.Contains("0"))
                {
                    int y = Convert.ToInt16(y1);
                    pdfGraph(1, "Periodo Abril - Junio", $"{y-1}-{y}");
                } else if (btn.Name.Contains("1"))
                {
                    pdfGraph(1, "Diagnóstico", sCiclo);
                } else if (btn.Name.Contains("2"))
                {
                    pdfGraph(1, "Periodo Agosto - Noviembre", sCiclo);
                } else if (btn.Name.Contains("3"))
                {
                    pdfGraph(1, "Periodo Diciembre - Marzo", sCiclo);
                } else if (btn.Name.Contains("4"))
                {
                    pdfGraph(1, "Periodo Abril - Junio", sCiclo);
                }
            }
        }

        private void btnPT_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)
            {
                if (btn.Name.Contains("0"))
                {
                    int y = Convert.ToInt16(y1);
                    pdfGraph(2, "Periodo Abril - Junio", $"{y - 1}-{y}");
                }
                else if (btn.Name.Contains("1"))
                {
                    pdfGraph(2, "Diagnóstico", sCiclo);
                }
                else if (btn.Name.Contains("2"))
                {
                    pdfGraph(2, "Periodo Agosto - Noviembre", sCiclo);
                }
                else if (btn.Name.Contains("3"))
                {
                    pdfGraph(2, "Periodo Diciembre - Marzo", sCiclo);
                }
                else if (btn.Name.Contains("4"))
                {
                    pdfGraph(2, "Periodo Abril - Junio", sCiclo);
                }
            }
        }

        private void btnTL_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)
            {
                if (btn.Name.Contains("0"))
                {
                    int y = Convert.ToInt16(y1);
                    pdfGraph(3, "Periodo Abril - Junio", $"{y - 1}-{y}");
                }
                else if (btn.Name.Contains("1"))
                {
                    pdfGraph(3, "Diagnóstico", sCiclo);
                }
                else if (btn.Name.Contains("2"))
                {
                    pdfGraph(3, "Periodo Agosto - Noviembre", sCiclo);
                }
                else if (btn.Name.Contains("3"))
                {
                    pdfGraph(3, "Periodo Diciembre - Marzo", sCiclo);
                }
                else if (btn.Name.Contains("4"))
                {
                    pdfGraph(3, "Periodo Abril - Junio", sCiclo);
                }
            }
        }

        private void pdfGraph(int iOpcion, string sPeriodo, string year)
        {
            try
            {
                DataTable dt = new DataTable();
                int ne = 0, ed = 0, ra = 0;
                string eval = "", ciclo = "", periodo = "";
                DateTime dateAugust = new DateTime(2024, 8, 1);

                // Obtener la cantidad de alumnos por cada nivel de aprendizaje para la evaluación solicitada
                switch (iOpcion)
                {
                    case 1:
                        ne = direClass.GetCountCMNE(sPeriodo, year);
                        ed = direClass.GetCountCMED(sPeriodo, year);
                        ra = direClass.GetCountCMRA(sPeriodo, year);
                        eval = "Cálculo Mental";
                        break;
                    case 2:
                        ne = direClass.GetCountPTNE(sPeriodo, year);
                        ed = direClass.GetCountPTED(sPeriodo, year);
                        ra = direClass.GetCountPTRA(sPeriodo, year);
                        eval = "Producción de Textos";
                        break;
                    case 3:
                        ne = direClass.GetCountTLNE(sPeriodo, year);
                        ed = direClass.GetCountTLED(sPeriodo, year);
                        ra = direClass.GetCountTLRA(sPeriodo, year);
                        eval = "Toma de Lectura";
                        break;
                }

                // Confirmar que no se encuentren vacías todas las variables
                if (ne == 0 && ed == 0 && ra == 0)
                {
                    MessageBox.Show("No se ha capturado ningún dato para generar una gráfica", "Error", MessageBoxButtons.OK);
                    return;
                }

                // Formatear el ciclo escolar de manera más bonita para el documento
                if (DateTime.Now.Month >= dateAugust.Month && DateTime.Now.Day >= dateAugust.Day)
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y} - {y + 1}"; 
                }
                else
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 1} - {y}";
                }

                switch (sPeriodo)
                {
                    case "Diagnóstico":
                        periodo = "Diagnóstico";
                        break;
                    case "Periodo Abril - Junio":
                        periodo = "Tercer trimestre: Junio";
                        break;
                    case "Periodo Agosto - Noviembre":
                        periodo = "Primer trimestre: Noviembre";
                        break;
                    case "Periodo Diciembre - Marzo":
                        periodo = "Segundo trimestre: Marzo";
                        break;
                }

                // Crear un documento pdf
                PdfDocument document = new PdfDocument();

                // Agregar una página
                PdfPage page = document.AddPage();

                // Agregar un objeto de XGraphics para dibujar sobre el documento
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Agregar la imagen de logo
                gfx.DrawImage(XImage.FromFile(System.Windows.Forms.Application.StartupPath + @"logoSEP.png"), 30, -15, 100, 100);

                // Definir las fuentes que se van a utilizar
                XFont font = new XFont("Verdana", 10, XFontStyleEx.Bold);
                XFont font2 = new XFont("Verdana", 10, XFontStyleEx.Regular);

                // Dibujar texto sobre el documento
                gfx.DrawString("Gráfica de Concentrado Escolar de Evaluación SisAT", font, XBrushes.Black, 300, 10, XStringFormats.TopCenter);
                gfx.DrawString(eval, font, XBrushes.Black, 300, 21, XStringFormats.TopCenter);
                gfx.DrawString(periodo, font, XBrushes.Black, 300, 65, XStringFormats.TopCenter);
                gfx.DrawString("Escuela Primaria Francisco I. Madero", font, XBrushes.Black, 300, 32, XStringFormats.TopCenter);
                gfx.DrawString("Zona 077 | Sector III", font, XBrushes.Black, 298, 43, XStringFormats.TopCenter);
                gfx.DrawString($"Ciclo Escolar {ciclo}", font, XBrushes.Black, 298, 54, XStringFormats.TopCenter);

                // Crear brochas para dibujar la gráfica
                XSolidBrush rect_style1 = new XSolidBrush(XColors.ForestGreen);
                XSolidBrush rect_style2 = new XSolidBrush(XColors.Gold);
                XSolidBrush rect_style3 = new XSolidBrush(XColors.Red);

                // Definir plumas para dibujar líneas
                XPen line = new XPen(XColors.Black, 2);
                XPen line2 = new XPen(XColors.Black, 1);

                // Dibujar los 3 rectángulos que se requieren para la gráfica
                gfx.DrawRectangle(rect_style1, 90, 600, 80, -(ne * 2));
                gfx.DrawRectangle(rect_style2, 255, 600, 80, -(ed * 2));
                gfx.DrawRectangle(rect_style3, 425, 600, 80, -(ra * 2));

                // Dibujar la línea sobre la cual se encuentran las barras de la gráfica
                gfx.DrawLine(line, 50, 600, 540, 600);

                // Dibujar un borde alrededor de la barra de Nivel esperado
                gfx.DrawLine(line2, 90, 600, 90, 600 - (ne * 2));
                gfx.DrawLine(line2, 90, 600 - (ne * 2), 170, 600 - (ne * 2));
                gfx.DrawLine(line2, 170, 600, 170, 600 - (ne * 2));

                // Dibujar un borde alrededor de la barra de En desarrollo
                gfx.DrawLine(line2, 255, 600, 255, 600 - (ed * 2));
                gfx.DrawLine(line2, 255, 600 - (ed * 2), 335, 600 - (ed * 2));
                gfx.DrawLine(line2, 335, 600, 335, 600 - (ed * 2));

                // Dibujar un borde alrededor de la barra de Requiere apoyo
                gfx.DrawLine(line2, 425, 600, 425, 600 - (ra * 2));
                gfx.DrawLine(line2, 425, 600 - (ra * 2), 505, 600 - (ra * 2));
                gfx.DrawLine(line2, 505, 600, 505, 600 - (ra * 2));

                // Escribir el nivel de aprendizaje y la cantidad de alumnos que se encuentran en ese nivel
                gfx.DrawString("Nivel esperado", font2, XBrushes.Black, 130, 610, XStringFormats.TopCenter);
                gfx.DrawString($"{ne}", font2, XBrushes.DarkGreen, 127, 580 - (ne * 2), XStringFormats.TopCenter);
                gfx.DrawString("En desarrollo", font2, XBrushes.Black, 298, 610, XStringFormats.TopCenter);
                gfx.DrawString($"{ed}", font2, XBrushes.DarkGoldenrod, 292, 580 - (ed * 2), XStringFormats.TopCenter);
                gfx.DrawString("Requiere apoyo", font2, XBrushes.Black, 464, 610, XStringFormats.TopCenter);
                gfx.DrawString($"{ra}", font2, XBrushes.DarkRed, 462, 580 - (ra * 2), XStringFormats.TopCenter);

                // Obtener la dirección de Documentos en la máquina que se está ejecutando el programa
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Establecer la ruta y nombre del documento a generar
                string filename = $"{dir}\\GraficaEscolar_{eval}_{sPeriodo}_{sCiclo}.pdf";
                
                // Guardar el documento
                document.Save(filename);

                // Enviar un mensaje de confirmación con la ruta del documento
                MessageBox.Show($"Gráfica guardada en: {dir}\\GraficaEscolar_{eval}_{sPeriodo}_{sCiclo}.pdf");
            }
            catch (Exception ex)
            {
                // Mandar un mensaje de error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
