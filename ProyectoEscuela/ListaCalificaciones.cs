using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraGrid;
using DevExpress.XtraScheduler;
using DevExpress.XtraSpreadsheet.Forms;
using DevExpress.XtraGrid.Views.Base;
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
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Windows.Controls;
using DevExpress.XtraRichEdit.Model.History;
using DevExpress.XtraEditors;
using Google.Protobuf.WellKnownTypes;
using DevExpress.Drawing;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Windows;
using PdfSharp.Drawing.Layout;
using Aspose.Pdf.Drawing;

namespace ProyectoEscuela
{
    public partial class ListaCalificaciones : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        string Reporte = "", sCiclo = "";
        int iID, i = 1;
        bool update = false, cicloEscolar = false;
        List<string> sIDs = new List<string>();

        public ListaCalificaciones(string numReporte, int id)
        {
            Reporte = numReporte;
            iID = id;
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            pInicio.Visible = true;

            if (DateTime.Now.Month >= 8 && DateTime.Now.Day >= 1)
                sCiclo = $"{DateTime.Now.Year}-{DateTime.Now.Year + 1}";
            else
                sCiclo = $"{DateTime.Now.Year - 1}-{DateTime.Now.Year}";
        }

        private void ListaCalificaciones_Load(object sender, EventArgs e)
        {
            i = 1;
            dgv1.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 6, FontStyle.Bold);
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv1.Columns[2].Width = 100;
            dgv1.Columns[3].Width = 100;
            dgv1.Columns[4].Width = 100;
            dgv1.Columns[5].Width = 100;
            dgv1.Columns[6].Width = 100;
            dgv1.Columns[7].Width = 330;

            DataTable dt2 = new DataTable();
            bool check = false;
            float language = 0.0f, knowledge = 0.0f, ethics = 0.0f, humanity = 0.0f;
            teachClass.GetStudentsList(ref dt2, teachClass.GetGrade(iID));

            foreach (DataRow row2 in dt2.Rows)
            {
                if (check)
                    return;
                int studID = Convert.ToInt16(row2[0]);
                DataTable dt3 = new DataTable();
                teachClass.GetGrades(ref dt3, studID, Reporte, sCiclo);
                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow row3 in dt3.Rows)
                    {
                        DataTable dt4 = new DataTable();
                        teachClass.GetGrades2(ref dt4, studID, Reporte, sCiclo);
                        foreach (DataRow row4 in dt4.Rows)
                        {
                            switch (row4[0])
                            {
                                case "LENGUAJES":
                                    language = float.Parse(row4[1].ToString());
                                    break;
                                case "SABERES Y PENSAMIENTO CIENTIFICO":
                                    knowledge = float.Parse(row4[1].ToString());
                                    break;
                                case "ETICA, NATURALEZA Y SOCIECADES":
                                    ethics = float.Parse(row4[1].ToString());
                                    break;
                                case "DE LO HUMANO Y LO COMUNITARIO":
                                    humanity = float.Parse(row4[1].ToString());
                                    break;
                            }
                        }

                        dgv1.Rows.Add(i, row2[1].ToString(), language, knowledge, ethics, humanity, row3[1].ToString(), row3[3].ToString());
                        i++;
                        sIDs.Add(row3[0].ToString());
                    }
                    update = true;
                }
                else
                {
                    check = LoadEmpty(dt2);
                }
            }
        }

        private bool LoadEmpty(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                gridView3.AddNewRow();
                gridView3.SetRowCellValue(i, gridColumn1, row[1].ToString());

                dgv1.Rows.Add(i, row[1].ToString(), "", "", "", "", "", "");
                i++;
                sIDs.Add(row[0].ToString());
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int rows = 0; rows < dgv1.Rows.Count; rows++)
                {
                    string lenguaje = dgv1.Rows[rows].Cells[2].Value?.ToString();
                    string saberes = dgv1.Rows[rows].Cells[3].Value?.ToString();
                    string etica = dgv1.Rows[rows].Cells[4].Value?.ToString();
                    string humano = dgv1.Rows[rows].Cells[5].Value?.ToString();

                    // Obtener el nombre del maestro
                    string name = teachClass.GetName(iID);
                    // Obtener el grupo
                    int group = teachClass.GetGrade(iID);

                    if (string.IsNullOrEmpty(lenguaje) || string.IsNullOrEmpty(saberes) || string.IsNullOrEmpty(etica) || string.IsNullOrEmpty(humano))
                    {
                        MessageBox.Show("Favor de llenar todas las celdas de calificaciones", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        if (Convert.ToInt16(lenguaje) < 0 || Convert.ToInt16(lenguaje) > 10 || Convert.ToInt16(saberes) < 0 || Convert.ToInt16(saberes) > 10 || Convert.ToInt16(etica) < 0 || Convert.ToInt16(etica) > 10 || Convert.ToInt16(humano) < 0 || Convert.ToInt16(humano) > 10)
                        {
                            MessageBox.Show("El valor máximo de calificación es 10, no se puede pasar de este", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Las calificaciones ingresadas deben ser números enteros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (!update)
                {
                    for (int rows = 0; rows < dgv1.Rows.Count; rows++)
                    {
                        string id = sIDs[rows];
                        string lenguaje = dgv1.Rows[rows].Cells[2].Value?.ToString();
                        string saberes = dgv1.Rows[rows].Cells[3].Value?.ToString();
                        string etica = dgv1.Rows[rows].Cells[4].Value?.ToString();
                        string humano = dgv1.Rows[rows].Cells[5].Value?.ToString();
                        string prom = dgv1.Rows[rows].Cells[6].Value?.ToString();
                        string obs = dgv1.Rows[rows].Cells[7].Value?.ToString();

                        // Obtener el nombre del maestro
                        string name = teachClass.GetName(iID);
                        // Obtener el grupo
                        int group = teachClass.GetGrade(iID);

                        if (!teachClass.AddGrade(Convert.ToInt16(id), float.Parse(lenguaje), float.Parse(saberes), float.Parse(etica), float.Parse(humano), float.Parse(prom), obs, name, group, Reporte, sCiclo))
                        {
                            MessageBox.Show("Error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    for (int rows = 0; rows < dgv1.Rows.Count; rows++)
                    {
                        string id = sIDs[rows];
                        float lenguaje = float.Parse(dgv1.Rows[rows].Cells[2].Value?.ToString());
                        float saberes = float.Parse(dgv1.Rows[rows].Cells[3].Value?.ToString());
                        float etica = float.Parse(dgv1.Rows[rows].Cells[4].Value?.ToString());
                        float humano = float.Parse(dgv1.Rows[rows].Cells[5].Value?.ToString());
                        float prom = float.Parse(dgv1.Rows[rows].Cells[6].Value?.ToString());
                        string obs = dgv1.Rows[rows].Cells[7].Value?.ToString();

                        // Obtener el grupo
                        int group = teachClass.GetGrade(iID);

                        if (!teachClass.UpdateGrade(Convert.ToInt16(id), lenguaje, saberes, etica, humano, prom, obs, Reporte, group, sCiclo))
                        {
                            MessageBox.Show("Error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                MessageBox.Show("Calificaciones guardadas");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int rows = 0; rows < dgv1.Rows.Count; rows++)
                {
                    string lenguaje = dgv1.Rows[rows].Cells[2].Value?.ToString();
                    string saberes = dgv1.Rows[rows].Cells[3].Value?.ToString();
                    string etica = dgv1.Rows[rows].Cells[4].Value?.ToString();
                    string humano = dgv1.Rows[rows].Cells[5].Value?.ToString();

                    if (!string.IsNullOrEmpty(lenguaje) && !string.IsNullOrEmpty(saberes) && !string.IsNullOrEmpty(etica) && !string.IsNullOrEmpty(humano))
                    {
                        if (float.Parse(lenguaje) <= 10 && float.Parse(saberes) <= 10 && float.Parse(etica) <= 10 && float.Parse(humano) <= 10)
                        {
                            float l = float.Parse(lenguaje);
                            float s = float.Parse(saberes);
                            float et = float.Parse(etica);
                            float h = float.Parse(humano);

                            float prom = (l + s + et + h) / 4;
                            prom = (float)Math.Round(prom, 1);
                            dgv1.Rows[rows].Cells[6].Value = prom.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            MaestroCalificaciones newForm = new MaestroCalificaciones(iID);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }

        private void btnPrintDoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear documento
                PdfDocument document = new PdfDocument();

                // Agregar una página
                PdfPage page = document.AddPage();

                // Se necesita de XGraphics para dibujar sobre el documento
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Crear la fuente a utilizar
                XFont font = new XFont("Verdana", 10, XFontStyleEx.Bold);

                // Obtener el grado, nombre de maestro y declarar variables
                int grade = teachClass.GetGrade(iID);
                string grado = "", ciclo = "", name = teachClass.GetName(iID), periodo ="";

                // Convertir el grado numérico a string
                switch (grade)
                {
                    case 1:
                        grado = "Primer";
                        break;
                    case 2:
                        grado = "Segundo";
                        break;
                    case 3:
                        grado = "Tercer";
                        break;
                    case 4:
                        grado = "Cuarto";
                        break;
                    case 5:
                        grado = "Quinto";
                        break;
                    case 6:
                        grado = "Sexto";
                        break;
                }

                switch (Reporte)
                {
                    case "Agosto - Noviembre":
                        periodo = "Primer trimestre: Noviembre";
                        break;
                    case "Diciembre - Marzo":
                        periodo = "Segundo trimestre: Marzo";
                        break;
                    case "Abril - Junio":
                        periodo = "Tercer trimestre: Junio";
                        break;
                }

                // Establecer el ciclo escolar
                if (DateTime.Now.Month >= 8 && DateTime.Now.Day >= 1)
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y} - {y + 1}"; // solo para formatearlo más bonito para el documento
                }
                else
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 1} - {y}";
                }

                // Agregar la imagen del logo de la SEP
                gfx.DrawImage(XImage.FromFile(System.Windows.Forms.Application.StartupPath + @"logoSEP.png"), 30, -15, 100, 100);

                // Escribir sobre el documento
                gfx.DrawString("Calificaciones Finales", font, XBrushes.Black, 300, 10, XStringFormats.TopCenter);
                gfx.DrawString(periodo, font, XBrushes.Black, 300, 54, XStringFormats.TopCenter);
                gfx.DrawString("Escuela Primaria Francisco I. Madero", font, XBrushes.Black, 300, 21, XStringFormats.TopCenter);
                gfx.DrawString("Zona 077 | Sector III", font, XBrushes.Black, 298, 32, XStringFormats.TopCenter);
                gfx.DrawString($"{grado} Grado | Ciclo Escolar {ciclo}", font, XBrushes.Black, 298, 43, XStringFormats.TopCenter);
                gfx.DrawString($"Prof. {name}", font, XBrushes.Black, 298, 65, XStringFormats.TopCenter);

                // Información sobre el documento
                document.Info.Title = "Table Example";

                // Formato de texto en las columnas
                XStringFormat format = new XStringFormat();
                format.LineAlignment = XLineAlignment.Near;
                format.Alignment = XStringAlignment.Near;

                // Objeto de texto para escribir en la tabla
                var tf = new XTextFormatter(gfx);

                // Fuentes para las columnas y el resto de las celdas
                XFont fontHeader = new XFont("Verdana", 7, XFontStyleEx.Bold);
                XFont fontParagraph = new XFont("Verdana", 8, XFontStyleEx.Regular);

                // Margen de la hoja para usar como base para las coordenadas
                int marginLeft = 20;
                int marginTop = 80;

                // Altura del texto
                int el_height = 30;

                // Brochas para rellenar las celdas
                XSolidBrush rect_style1 = new XSolidBrush(XColors.AliceBlue);
                XSolidBrush rect_style2 = new XSolidBrush(XColors.DodgerBlue);

                // Pluma para dibujar líneas
                XPen line = new XPen(XColors.Black, 1);

                // Distancia desde la parte superior de la hoja
                double dist_Y = marginTop + 50;

                // Dibujar las celdas de las columnas
                gfx.DrawRectangle(rect_style2, marginLeft, marginTop, page.Width - 2 * marginLeft, 42);

                // Escribir el texto de las columnas
                tf.DrawString("No", fontHeader, XBrushes.White, new XRect(marginLeft + 10, marginTop, 20, el_height), format);
                tf.DrawString("NOMBRE DEL ALUMNO", fontHeader, XBrushes.White, new XRect(marginLeft + 40, marginTop, 120, el_height), format);
                tf.DrawString("LENGUAJES", fontHeader, XBrushes.White, new XRect(marginLeft + 220, marginTop, 50, el_height), format);
                tf.DrawString("SABERES Y PENSAMIENTO CIENTIFICO", fontHeader, XBrushes.White, new XRect(marginLeft + 290, marginTop, 50, el_height), format);
                tf.DrawString("ETICA, NATURALEZA Y SOCIEDADES", fontHeader, XBrushes.White, new XRect(marginLeft + 360, marginTop, 50, el_height + 20), format);
                tf.DrawString("DE LO HUMANO Y LO COMUNITARIO", fontHeader, XBrushes.White, new XRect(marginLeft + 430, marginTop, 50, el_height + 20), format);
                tf.DrawString("PROMEDIO", fontHeader, XBrushes.White, new XRect(marginLeft + 500, marginTop, 50, el_height), format);

                // Dibujar las líneas para delimitar las columnas
                gfx.DrawLine(line, marginLeft, marginTop, marginLeft + 555, marginTop);
                gfx.DrawLine(line, marginLeft, marginTop, marginLeft, marginTop + 42);
                gfx.DrawLine(line, marginLeft, marginTop + 42, marginLeft + 555, marginTop + 42);
                gfx.DrawLine(line, marginLeft + 555, marginTop, marginLeft + 555, marginTop + 42);
                gfx.DrawLine(line, marginLeft + 30, marginTop, marginLeft + 30, marginTop + 42);
                gfx.DrawLine(line, marginLeft + 215, marginTop, marginLeft + 215, marginTop + 42);
                gfx.DrawLine(line, marginLeft + 285, marginTop, marginLeft + 285, marginTop + 42);
                gfx.DrawLine(line, marginLeft + 355, marginTop, marginLeft + 355, marginTop + 42);
                gfx.DrawLine(line, marginLeft + 425, marginTop, marginLeft + 425, marginTop + 42);
                gfx.DrawLine(line, marginLeft + 495, marginTop, marginLeft + 495, marginTop + 42);

                // Variables necesarias para agregar la información de cada alumno
                DataTable dt = new DataTable();
                float language = 0, knowledge = 0, ethics = 0, humanity = 0, final = 0;
                string studName = "";
                int i = 1;

                // Obtener la lista de alumnos
                teachClass.GetStudentsList(ref dt, teachClass.GetGrade(iID));
                foreach (DataRow row in dt.Rows)
                {
                    int studID = Convert.ToInt16(row[0]);
                    DataTable dt2 = new DataTable();
                    teachClass.GetGrades(ref dt2, studID, Reporte, sCiclo); // Obtener calificaciones de un alumno

                    if (dt2.Rows.Count > 0)
                    {
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            DataTable dt3 = new DataTable();
                            teachClass.GetGrades2(ref dt3, studID, Reporte, sCiclo); // Obtener calificaciones por materia de un alumo
                            foreach (DataRow row3 in dt3.Rows)
                            {
                                // Guardar cada calificación en su respectiva variable
                                switch (row3[0])
                                {
                                    case "LENGUAJES":
                                        language = float.Parse(row3[1].ToString());
                                        break;
                                    case "SABERES Y PENSAMIENTO CIENTIFICO":
                                        knowledge = float.Parse(row3[1].ToString());
                                        break;
                                    case "ETICA, NATURALEZA Y SOCIECADES":
                                        ethics = float.Parse(row3[1].ToString());
                                        break;
                                    case "DE LO HUMANO Y LO COMUNITARIO":
                                        humanity = float.Parse(row3[1].ToString());
                                        break;
                                }
                            }

                            // Colorear el fondo de cada segunda fila
                            if (i % 2 == 0)
                            {
                                gfx.DrawRectangle(rect_style1, marginLeft, dist_Y - 5, page.Width - 2 * marginLeft, el_height / 2 + 5);
                            }

                            // Escribir la información y calificaciones del alumno
                            tf.DrawString($"{i}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 12, dist_Y, 20, el_height), format);
                            tf.DrawString($"{row[1].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 40, dist_Y, 200, el_height), format);
                            tf.DrawString($"{language}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 224, dist_Y, 50, el_height), format);
                            tf.DrawString($"{knowledge}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 295, dist_Y, 50, el_height), format);
                            tf.DrawString($"{ethics}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 366, dist_Y, 50, el_height), format);
                            tf.DrawString($"{humanity}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 437, dist_Y, 50, el_height), format);
                            tf.DrawString($"{row2[1].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 508, dist_Y, 50, el_height), format);
                            

                            // Dibujar las líneas que delimitan las celdas
                            gfx.DrawLine(line, marginLeft, dist_Y - 15, marginLeft, dist_Y + el_height - 15);
                            gfx.DrawLine(line, marginLeft + 30, dist_Y - 15, marginLeft + 30, dist_Y + el_height - 15);
                            gfx.DrawLine(line, marginLeft + 215, dist_Y - 15, marginLeft + 215, dist_Y + el_height - 15);
                            gfx.DrawLine(line, marginLeft + 285, dist_Y - 15, marginLeft + 285, dist_Y + el_height - 15);
                            gfx.DrawLine(line, marginLeft + 355, dist_Y - 15, marginLeft + 355, dist_Y + el_height - 15);
                            gfx.DrawLine(line, marginLeft + 425, dist_Y - 15, marginLeft + 425, dist_Y + el_height - 15);
                            gfx.DrawLine(line, marginLeft + 495, dist_Y - 15, marginLeft + 495, dist_Y + el_height - 15);
                            gfx.DrawLine(line, marginLeft + 555, dist_Y - 15, marginLeft + 555, dist_Y + el_height - 15);

                            if (row2[3].ToString().Length > 0)
                            {
                                dist_Y += 20;
                                if (i % 2 == 0)
                                {
                                    gfx.DrawRectangle(rect_style1, marginLeft, dist_Y - 5, page.Width - 2 * marginLeft, el_height / 2 + 5);
                                }
                                tf.DrawString($"Observaciones: {row2[3].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 40, dist_Y, marginLeft + 555, el_height), format);
                                gfx.DrawLine(line, marginLeft, dist_Y - 15, marginLeft, dist_Y + el_height - 15);
                                gfx.DrawLine(line, marginLeft + 30, dist_Y - 15, marginLeft + 30, dist_Y + el_height - 15);
                                gfx.DrawLine(line, marginLeft + 215, dist_Y - 15, marginLeft + 215, dist_Y + el_height - 15);
                                gfx.DrawLine(line, marginLeft + 285, dist_Y - 15, marginLeft + 285, dist_Y + el_height - 15);
                                gfx.DrawLine(line, marginLeft + 355, dist_Y - 15, marginLeft + 355, dist_Y + el_height - 15);
                                gfx.DrawLine(line, marginLeft + 425, dist_Y - 15, marginLeft + 425, dist_Y + el_height - 15);
                                gfx.DrawLine(line, marginLeft + 495, dist_Y - 15, marginLeft + 495, dist_Y + el_height - 15);
                                gfx.DrawLine(line, marginLeft + 555, dist_Y - 15, marginLeft + 555, dist_Y + el_height - 15);
                            }

                            // Incrementar la distancia donde se va a ubicar la siguiente fila
                            dist_Y += 20;

                            i++;
                        }
                    } else
                    {
                        MessageBox.Show("No existen datos para generar un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Dibujar la última línea de la tabla
                gfx.DrawLine(line, marginLeft, dist_Y - 5, marginLeft + 555, dist_Y - 5);

                // Obtener la dirección de Documentos de la máquina
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Establecer la dirección y nombre del archivo
                string filename = $"{dir}\\Calificaciones_{Reporte}_{sCiclo}.pdf";

                // Guardar el documento como pdf
                document.Save(filename);

                // Enviar un mensaje de confirmación con la dirección actual del documento
                MessageBox.Show($"Documento guardado en: {dir}\\Calificaciones_{Reporte}_{sCiclo}.pdf");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
