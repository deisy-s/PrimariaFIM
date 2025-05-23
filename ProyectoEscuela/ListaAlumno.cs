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
using DevExpress.Utils.MVVM.Services;

namespace ProyectoEscuela
{
    public partial class ListaAlumno : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        int iID = 0, sID = 0;

        public ListaAlumno(int id, int tID, string name)
        {
            iID = tID;
            sID = id;
            InitializeComponent();
            lblTitulo.Text = $"{name}";
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            DataTable dtFG = new DataTable();
            DataTable dtCM = new DataTable();
            DataTable dtPT = new DataTable();
            DataTable dtTL = new DataTable();
            string fgAN = "", fgDM = "", fgAJ = "", cmD = "", cmAN = "", cmDM = "", cmAJ = "", ptD = "", ptAN = "", ptDM = "", ptAJ = "", tlD = "", tlAN = "", tlDM = "", tlAJ = "";
            string sCiclo = "";
            if (DateTime.Now.Month >= 8 && DateTime.Now.Day >= 1)
                sCiclo = $"{DateTime.Now.Year}-{DateTime.Now.Year + 1}";
            else
                sCiclo = $"{DateTime.Now.Year - 1}-{DateTime.Now.Year}";

            teachClass.GetFinalGrade(ref dtFG, sCiclo, id);
            teachClass.GetFinalCM(ref dtCM, sCiclo, id);
            teachClass.GetFinalPT(ref dtPT, sCiclo, id);
            teachClass.GetFinalTL(ref dtTL, sCiclo, id);

            foreach (DataRow row in dtFG.Rows)
            {
                if (row[1].ToString() == "Agosto - Noviembre")
                    fgAN = row[0].ToString();
                else if (row[1].ToString() == "Diciembre - Marzo")
                    fgDM = row[0].ToString();
                else if (row[1].ToString() == "Abril - Junio")
                    fgAJ = row[0].ToString();
            }
            foreach (DataRow row in dtCM.Rows)
            {
                if (row[1].ToString() == "Periodo Agosto - Noviembre")
                    cmAN = row[0].ToString();
                else if (row[1].ToString() == "Periodo Diciembre - Marzo")
                    cmDM = row[0].ToString();
                else if (row[1].ToString() == "Periodo Abril - Junio")
                    cmAJ = row[0].ToString();
                else if (row[1].ToString() == "Diagnóstico")
                    cmD = row[0].ToString();
            }
            foreach (DataRow row in dtPT.Rows)
            {
                if (row[1].ToString() == "Periodo Agosto - Noviembre")
                    ptAN = row[0].ToString();
                else if (row[1].ToString() == "Periodo Diciembre - Marzo")
                    ptDM = row[0].ToString();
                else if (row[1].ToString() == "Periodo Abril - Junio")
                    ptAJ = row[0].ToString();
                else if (row[1].ToString() == "Diagnóstico")
                    ptD = row[0].ToString();
            }
            foreach (DataRow row in dtTL.Rows)
            {
                if (row[1].ToString() == "Periodo Agosto - Noviembre")
                    tlAN = row[0].ToString();
                else if (row[1].ToString() == "Periodo Diciembre - Marzo")
                    tlDM = row[0].ToString();
                else if (row[1].ToString() == "Periodo Abril - Junio")
                    tlAJ = row[0].ToString();
                else if (row[1].ToString() == "Diagnóstico")
                    tlD = row[0].ToString();
            }

            dgv1.Rows.Add("No aplicado", cmD, ptD, tlD, "Diagnóstico");
            dgv1.Rows.Add(fgAN, cmAN, ptAN, tlAN, "Agosto - Noviembre");
            dgv1.Rows.Add(fgDM, cmDM, ptDM, tlDM, "Diciembre - Marzo");
            dgv1.Rows.Add(fgAJ, cmAJ, ptAJ, tlAJ, "Abril - Junio");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pInicio.Visible = false;
            pIndex.Visible = true;
            pIndex.Controls.Clear();
            MaestroGrupo newForm = new MaestroGrupo(iID);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }

        private void btnCM_Click(object sender, EventArgs e)
        {
            try
            {
                // Declarar variables necesarias y obtener grado y la lista de alumnos
                DataTable dtList = new DataTable();
                DataTable dtName = new DataTable();
                teachClass.GetStudentName(ref dtName, sID);
                int grade = teachClass.GetGrade(iID) - 1, i = 1;
                string eval = "Cálculo Mental", ciclo = "", ciclodb = "", name = "", grado = "", sname = "";

                foreach (DataRow row in dtName.Rows)
                {
                    sname = row[1].ToString();
                }

                // Obtener los años del ciclo escolar
                if (DateTime.Now.Month >= 8 && DateTime.Now.Day >= 1)
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 1} - {y}";
                    ciclodb = $"{y - 1}-{y}";
                }
                else
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 2} - {y - 1}";
                    ciclodb = $"{y - 2}-{y - 1}";
                }

                // Convertir el grado numérico a string
                switch (grade)
                {
                    case 0:
                        MessageBox.Show("No existen datos para generar un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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

                // Crear un documento
                PdfDocument document = new PdfDocument();

                // Agregar una hoja al documento
                PdfPage page = document.AddPage();

                // Crear un objeto de XGraphics para dibujar sobre el documeto
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Declarar la fuente a utilizar
                XFont font = new XFont("Verdana", 10, XFontStyleEx.Bold);

                // Dibujar la imagen del logo de la SEP
                gfx.DrawImage(XImage.FromFile(System.Windows.Forms.Application.StartupPath + @"logoSEP.png"), 30, -15, 100, 100);

                // Escribir el título
                gfx.DrawString("Concentrado de Salón de Evaluación SisAT", font, XBrushes.Black, 300, 10, XStringFormats.TopCenter);
                gfx.DrawString(eval, font, XBrushes.Black, 300, 21, XStringFormats.TopCenter);
                gfx.DrawString("Tercer trimestre: Junio", font, XBrushes.Black, 300, 65, XStringFormats.TopCenter);
                gfx.DrawString("Escuela Primaria Francisco I. Madero", font, XBrushes.Black, 300, 32, XStringFormats.TopCenter);
                gfx.DrawString("Zona 077 | Sector III", font, XBrushes.Black, 298, 43, XStringFormats.TopCenter);
                gfx.DrawString($"{grado} Grado | Ciclo Escolar {ciclo}", font, XBrushes.Black, 298, 54, XStringFormats.TopCenter);

                // Formato del texto dentro de la tabla
                XStringFormat format = new XStringFormat();
                format.LineAlignment = XLineAlignment.Near;
                format.Alignment = XStringAlignment.Near;

                // Variable para escribir el texto de la tabla
                var tf = new XTextFormatter(gfx);

                // Declarar fuentes que se utilizarán en la tabla
                XFont fontHeader = new XFont("Verdana", 7, XFontStyleEx.Bold);
                XFont fontHeader2 = new XFont("Verdana", 7, XFontStyleEx.Regular);
                XFont fontParagraph = new XFont("Verdana", 8, XFontStyleEx.Regular);

                // Margen de la hoja
                int marginLeft = 20;
                int marginTop = 95;

                // Altura del texto
                int el_height = 30;

                // Declarar brochas, con las cuales se rellenarán las celdas
                XSolidBrush rect_style1 = new XSolidBrush(XColors.AliceBlue);
                XSolidBrush rect_style2 = new XSolidBrush(XColors.DodgerBlue);

                // Declarar una pluma para dibujar líneas
                XPen line = new XPen(XColors.Black, 1);

                // Distancia desde la parte superior de la hoja
                double dist_Y = marginTop + 50;
                double dist_Y2 = dist_Y - 2;

                teachClass.GetCM(ref dtList, sID, "Periodo Abril - Junio", ciclodb);
                i = 1; // Contador
                if (dtList.Rows.Count > 0)
                {

                    foreach (DataRow rowP in dtList.Rows)
                    {
                        string na = "";
                        // En caso de ser la primera iteración, generar el header
                        if (i == 1)
                        {
                            // Relleno de las celdas
                            gfx.DrawRectangle(rect_style2, marginLeft, marginTop, page.Width - 2 * marginLeft, 20);

                            // Nombres de las columnas
                            tf.DrawString("No", fontHeader, XBrushes.White, new XRect(marginLeft + 10, marginTop, 20, el_height), format);
                            tf.DrawString("NOMBRE DEL ALUMNO", fontHeader, XBrushes.White, new XRect(marginLeft + 40, marginTop, 120, el_height), format);
                            tf.DrawString("P1", fontHeader, XBrushes.White, new XRect(marginLeft + 220, marginTop, 10, el_height), format);
                            tf.DrawString("P2", fontHeader, XBrushes.White, new XRect(marginLeft + 240, marginTop, 10, el_height), format);
                            tf.DrawString("P3", fontHeader, XBrushes.White, new XRect(marginLeft + 260, marginTop, 10, el_height + 20), format);
                            tf.DrawString("P4", fontHeader, XBrushes.White, new XRect(marginLeft + 280, marginTop, 10, el_height + 20), format);
                            tf.DrawString("P5", fontHeader, XBrushes.White, new XRect(marginLeft + 300, marginTop, 10, el_height), format);
                            tf.DrawString("P6", fontHeader, XBrushes.White, new XRect(marginLeft + 320, marginTop, 10, el_height), format);
                            tf.DrawString("P7", fontHeader, XBrushes.White, new XRect(marginLeft + 340, marginTop, 10, el_height), format);
                            tf.DrawString("P8", fontHeader, XBrushes.White, new XRect(marginLeft + 360, marginTop, 10, el_height), format);
                            tf.DrawString("P9", fontHeader, XBrushes.White, new XRect(marginLeft + 380, marginTop, 10, el_height), format);
                            tf.DrawString("P10", fontHeader, XBrushes.White, new XRect(marginLeft + 398, marginTop, 10, el_height), format);
                            tf.DrawString("PUNTAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 422, marginTop, 50, el_height), format);
                            tf.DrawString("NIVEL DE APRENDIZAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 470, marginTop, 50, el_height), format);

                            // Líneas para delimitar las celdas
                            gfx.DrawLine(line, marginLeft, marginTop, marginLeft + 555, marginTop);
                            gfx.DrawLine(line, marginLeft, marginTop, marginLeft, marginTop + 42);
                            gfx.DrawLine(line, marginLeft, marginTop + 20, marginLeft + 555, marginTop + 20);
                            gfx.DrawLine(line, marginLeft + 555, marginTop, marginLeft + 555, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 30, marginTop, marginLeft + 30, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 215, marginTop, marginLeft + 215, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 235, marginTop, marginLeft + 235, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 255, marginTop, marginLeft + 255, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 275, marginTop, marginLeft + 275, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 295, marginTop, marginLeft + 295, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 315, marginTop, marginLeft + 315, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 335, marginTop, marginLeft + 335, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 355, marginTop, marginLeft + 355, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 375, marginTop, marginLeft + 375, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 395, marginTop, marginLeft + 395, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 415, marginTop, marginLeft + 415, marginTop + 42);
                            gfx.DrawLine(line, marginLeft + 465, marginTop, marginLeft + 465, marginTop + 42);

                            // Agregar a la distancia para dibujar el siguiente objeto
                            dist_Y = marginTop + 25;
                        }

                        // Obtener el nivel de aprendizaje
                        if (rowP[15].ToString().Contains("Nivel esperado"))
                            na = "Nivel esperado";
                        else if (rowP[15].ToString().Contains("En desarrollo"))
                            na = "En desarrollo";
                        else if (rowP[15].ToString().Contains("Requiere apoyo"))
                            na = "Requiere apoyo";

                        // Escribir la información del alumno
                        tf.DrawString($"{i}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 12, dist_Y, 20, el_height), format);
                        tf.DrawString($"{sname}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 40, dist_Y, 200, el_height), format);
                        tf.DrawString($"{rowP[3].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 223, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[4].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 243, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[5].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 263, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[6].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 283, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[7].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 303, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[8].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 323, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[9].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 343, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[10].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 363, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[11].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 383, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[12].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 403, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[13].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 436, dist_Y, 50, el_height), format);
                        tf.DrawString($"{na}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 470, dist_Y, 80, el_height), format);

                        // Dibujar las líneas que delimitan las columnas
                        gfx.DrawLine(line, marginLeft, dist_Y - 15, marginLeft, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 30, dist_Y - 15, marginLeft + 30, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 215, dist_Y - 15, marginLeft + 215, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 235, dist_Y - 15, marginLeft + 235, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 255, dist_Y - 15, marginLeft + 255, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 275, dist_Y - 15, marginLeft + 275, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 295, dist_Y - 15, marginLeft + 295, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 315, dist_Y - 15, marginLeft + 315, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 335, dist_Y - 15, marginLeft + 335, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 355, dist_Y - 15, marginLeft + 355, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 375, dist_Y - 15, marginLeft + 375, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 395, dist_Y - 15, marginLeft + 395, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 415, dist_Y - 15, marginLeft + 415, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 465, dist_Y - 15, marginLeft + 465, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 555, dist_Y - 15, marginLeft + 555, dist_Y + el_height - 15);

                        // Guardar nombre del profesor del ciclo pasado
                        name = rowP[16].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No existen datos para generar un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Agregar nombre del profesor del ciclo pasado
                gfx.DrawString($"Prof. {name}", font, XBrushes.Black, 298, 76, XStringFormats.TopCenter);

                // Dibujar la última línea para cerrar la tabla
                gfx.DrawLine(line, marginLeft, dist_Y - 5, marginLeft + 555, dist_Y - 5);

                // Obtener la dirección de Documentos de la máquina
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Especificar la dirección y el nombre del archivo
                string filename = $"{dir}\\EvalSisAT_{eval}_Periodo Abril - Junio_{ciclo}.pdf";

                // Guardar el documento
                document.Save(filename);

                // Enviar un mensaje de confirmación con la dirección del documento
                MessageBox.Show($"Documento guardado en: {dir}\\EvalSisAT_{eval}_Periodo Abril - Junio_{ciclo}.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPT_Click(object sender, EventArgs e)
        {
            try
            {
                // Declarar variables necesarias y obtener grado y la lista de alumnos
                DataTable dtList = new DataTable();
                DataTable dtName = new DataTable();
                teachClass.GetStudentName(ref dtName, sID);
                int grade = teachClass.GetGrade(iID) - 1, i = 1;
                string eval = "Producción de Textos", ciclo = "", ciclodb = "", name = "", grado = "", sname = "";

                foreach (DataRow row in dtName.Rows)
                {
                    sname = row[1].ToString();
                }

                // Obtener los años del ciclo escolar
                if (DateTime.Now.Month >= 8 && DateTime.Now.Day >= 1)
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 1} - {y}";
                    ciclodb = $"{y - 1}-{y}";
                }
                else
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 2} - {y - 1}";
                    ciclodb = $"{y - 2}-{y - 1}";
                }

                // Convertir el grado numérico a string
                switch (grade)
                {
                    case 0:
                        MessageBox.Show("No existen datos para generar un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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

                // Crear un documento
                PdfDocument document = new PdfDocument();

                // Agregar una hoja al documento
                PdfPage page = document.AddPage();

                // Crear un objeto de XGraphics para dibujar sobre el documeto
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Declarar la fuente a utilizar
                XFont font = new XFont("Verdana", 10, XFontStyleEx.Bold);

                // Dibujar la imagen del logo de la SEP
                gfx.DrawImage(XImage.FromFile(System.Windows.Forms.Application.StartupPath + @"logoSEP.png"), 30, -15, 100, 100);

                // Escribir el título
                gfx.DrawString("Concentrado de Salón de Evaluación SisAT", font, XBrushes.Black, 300, 10, XStringFormats.TopCenter);
                gfx.DrawString(eval, font, XBrushes.Black, 300, 21, XStringFormats.TopCenter);
                gfx.DrawString("Tercer trimestre: Junio", font, XBrushes.Black, 300, 65, XStringFormats.TopCenter);
                gfx.DrawString("Escuela Primaria Francisco I. Madero", font, XBrushes.Black, 300, 32, XStringFormats.TopCenter);
                gfx.DrawString("Zona 077 | Sector III", font, XBrushes.Black, 298, 43, XStringFormats.TopCenter);
                gfx.DrawString($"{grado} Grado | Ciclo Escolar {ciclo}", font, XBrushes.Black, 298, 54, XStringFormats.TopCenter);

                // Formato del texto dentro de la tabla
                XStringFormat format = new XStringFormat();
                format.LineAlignment = XLineAlignment.Near;
                format.Alignment = XStringAlignment.Near;

                // Variable para escribir el texto de la tabla
                var tf = new XTextFormatter(gfx);

                // Declarar fuentes que se utilizarán en la tabla
                XFont fontHeader = new XFont("Verdana", 7, XFontStyleEx.Bold);
                XFont fontHeader2 = new XFont("Verdana", 7, XFontStyleEx.Regular);
                XFont fontParagraph = new XFont("Verdana", 8, XFontStyleEx.Regular);

                // Margen de la hoja
                int marginLeft = 20;
                int marginTop = 95;

                // Altura del texto
                int el_height = 30;

                // Declarar brochas, con las cuales se rellenarán las celdas
                XSolidBrush rect_style1 = new XSolidBrush(XColors.AliceBlue);
                XSolidBrush rect_style2 = new XSolidBrush(XColors.DodgerBlue);

                // Declarar una pluma para dibujar líneas
                XPen line = new XPen(XColors.Black, 1);

                // Distancia desde la parte superior de la hoja
                double dist_Y = marginTop + 50;
                double dist_Y2 = dist_Y - 2;

                teachClass.GetCM(ref dtList, sID, "Periodo Abril - Junio", ciclodb);
                i = 1; // Contador
                if (dtList.Rows.Count > 0)
                {

                    foreach (DataRow rowP in dtList.Rows)
                    {
                        string na = "";
                        // Si es la primera iteración, dibujar el header
                        if (i == 1)
                        {
                            // Relleno de las celdas de título
                            gfx.DrawRectangle(rect_style2, marginLeft, marginTop, page.Width - 2 * marginLeft, 52);

                            // Nombres de las columnas
                            tf.DrawString("No", fontHeader, XBrushes.White, new XRect(marginLeft + 3, marginTop, 20, el_height), format);
                            tf.DrawString("NOMBRE DEL ALUMNO", fontHeader, XBrushes.White, new XRect(marginLeft + 25, marginTop, 120, el_height), format);
                            tf.DrawString("ESCRITURA LEGIBLE", fontHeader2, XBrushes.White, new XRect(marginLeft + 169, marginTop, 40, el_height), format);
                            tf.DrawString("CUMPLE CON EL PROPOSITO COMUNICADO DEL TEXTO", fontHeader2, XBrushes.White, new XRect(marginLeft + 213, marginTop, 40, el_height + 20), format);
                            tf.DrawString("RELACION ADECUADA ENTRE PALABRAS Y ENTRE ENUNCIADOS", fontHeader2, XBrushes.White, new XRect(marginLeft + 266, marginTop, 40, el_height + 30), format);
                            tf.DrawString("DIVERSIDAD DE VOCABULARIO", fontHeader2, XBrushes.White, new XRect(marginLeft + 317, marginTop, 40, el_height + 20), format);
                            tf.DrawString("USOS DE LOS SIGNOS DE PUNTUACION", fontHeader2, XBrushes.White, new XRect(marginLeft + 372, marginTop, 40, el_height), format);
                            tf.DrawString("ORTOGRAFIA", fontHeader2, XBrushes.White, new XRect(marginLeft + 408, marginTop, 570, el_height), format);
                            tf.DrawString("PUNTAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 458, marginTop, 60, el_height), format);
                            tf.DrawString("NIVEL DE APRENDIZAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 496, marginTop, 50, el_height), format);

                            // Líneas para delimitar las celdas
                            gfx.DrawLine(line, marginLeft, marginTop, marginLeft + 555, marginTop);
                            gfx.DrawLine(line, marginLeft, marginTop, marginLeft, marginTop + 52);
                            gfx.DrawLine(line, marginLeft, marginTop + 52, marginLeft + 555, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 555, marginTop, marginLeft + 555, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 18, marginTop, marginLeft + 18, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 167, marginTop, marginLeft + 167, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 211, marginTop, marginLeft + 211, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 264, marginTop, marginLeft + 264, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 315, marginTop, marginLeft + 315, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 370, marginTop, marginLeft + 370, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 406, marginTop, marginLeft + 406, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 457, marginTop, marginLeft + 457, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 495, marginTop, marginLeft + 495, marginTop + 52);

                            // Agregar a la distancia en Y
                            dist_Y = marginTop + 60;
                        }

                        // Establecer el nivel de aprendizaje
                        if (rowP[11].ToString().Contains("Nivel esperado"))
                            na = "Nivel esperado";
                        else if (rowP[11].ToString().Contains("En desarrollo"))
                            na = "En desarrollo";
                        else if (rowP[11].ToString().Contains("Requiere apoyo"))
                            na = "Requiere apoyo";

                        // Escribir la información del alumno
                        tf.DrawString($"{i}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 5, dist_Y, 20, el_height), format);
                        tf.DrawString($"{sname}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 25, dist_Y, 200, el_height), format);
                        tf.DrawString($"{rowP[3].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 185, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[4].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 233, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[5].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 285, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[6].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 339, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[7].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 385, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[8].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 428, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[9].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 470, dist_Y, 50, el_height), format);
                        tf.DrawString($"{na}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 496, dist_Y, 80, el_height + 10), format);

                        // Dibujar las líneas que delimitan las columnas
                        gfx.DrawLine(line, marginLeft, dist_Y - 15, marginLeft, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 18, dist_Y - 15, marginLeft + 18, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 167, dist_Y - 15, marginLeft + 167, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 211, dist_Y - 15, marginLeft + 211, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 264, dist_Y - 15, marginLeft + 264, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 315, dist_Y - 15, marginLeft + 315, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 370, dist_Y - 15, marginLeft + 370, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 406, dist_Y - 15, marginLeft + 406, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 457, dist_Y - 15, marginLeft + 457, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 495, dist_Y - 15, marginLeft + 495, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 555, dist_Y - 15, marginLeft + 555, dist_Y + el_height - 15);

                        // Guardar nombre del profesor del ciclo pasado
                        name = rowP[16].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No existen datos para generar un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Agregar nombre del profesor del ciclo pasado
                gfx.DrawString($"Prof. {name}", font, XBrushes.Black, 298, 76, XStringFormats.TopCenter);

                // Dibujar la última línea para cerrar la tabla
                gfx.DrawLine(line, marginLeft, dist_Y - 5, marginLeft + 555, dist_Y - 5);

                // Obtener la dirección de Documentos de la máquina
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Especificar la dirección y el nombre del archivo
                string filename = $"{dir}\\EvalSisAT_{eval}_Periodo Abril - Junio_{ciclo}.pdf";

                // Guardar el documento
                document.Save(filename);

                // Enviar un mensaje de confirmación con la dirección del documento
                MessageBox.Show($"Documento guardado en: {dir}\\EvalSisAT_{eval}_Periodo Abril - Junio_{ciclo}.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTL_Click(object sender, EventArgs e)
        {
            try
            {
                // Declarar variables necesarias y obtener grado y la lista de alumnos
                DataTable dtList = new DataTable();
                DataTable dtName = new DataTable();
                teachClass.GetStudentName(ref dtName, sID);
                int grade = teachClass.GetGrade(iID) - 1, i = 1;
                string eval = "Toma de Lectura", ciclo = "", ciclodb = "", name = "", grado = "", sname = "";

                foreach (DataRow row in dtName.Rows)
                {
                    sname = row[1].ToString();
                }

                // Obtener los años del ciclo escolar
                if (DateTime.Now.Month >= 8 && DateTime.Now.Day >= 1)
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 1} - {y}";
                    ciclodb = $"{y - 1}-{y}";
                }
                else
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 2} - {y - 1}";
                    ciclodb = $"{y - 2}-{y - 1}";
                }

                // Convertir el grado numérico a string
                switch (grade)
                {
                    case 0:
                        MessageBox.Show("No existen datos para generar un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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

                // Crear un documento
                PdfDocument document = new PdfDocument();

                // Agregar una hoja al documento
                PdfPage page = document.AddPage();

                // Crear un objeto de XGraphics para dibujar sobre el documeto
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Declarar la fuente a utilizar
                XFont font = new XFont("Verdana", 10, XFontStyleEx.Bold);

                // Dibujar la imagen del logo de la SEP
                gfx.DrawImage(XImage.FromFile(System.Windows.Forms.Application.StartupPath + @"logoSEP.png"), 30, -15, 100, 100);

                // Escribir el título
                gfx.DrawString("Concentrado de Salón de Evaluación SisAT", font, XBrushes.Black, 300, 10, XStringFormats.TopCenter);
                gfx.DrawString(eval, font, XBrushes.Black, 300, 21, XStringFormats.TopCenter);
                gfx.DrawString("Tercer trimestre: Junio", font, XBrushes.Black, 300, 65, XStringFormats.TopCenter);
                gfx.DrawString("Escuela Primaria Francisco I. Madero", font, XBrushes.Black, 300, 32, XStringFormats.TopCenter);
                gfx.DrawString("Zona 077 | Sector III", font, XBrushes.Black, 298, 43, XStringFormats.TopCenter);
                gfx.DrawString($"{grado} Grado | Ciclo Escolar {ciclo}", font, XBrushes.Black, 298, 54, XStringFormats.TopCenter);

                // Formato del texto dentro de la tabla
                XStringFormat format = new XStringFormat();
                format.LineAlignment = XLineAlignment.Near;
                format.Alignment = XStringAlignment.Near;

                // Variable para escribir el texto de la tabla
                var tf = new XTextFormatter(gfx);

                // Declarar fuentes que se utilizarán en la tabla
                XFont fontHeader = new XFont("Verdana", 7, XFontStyleEx.Bold);
                XFont fontHeader2 = new XFont("Verdana", 7, XFontStyleEx.Regular);
                XFont fontParagraph = new XFont("Verdana", 8, XFontStyleEx.Regular);

                // Margen de la hoja
                int marginLeft = 20;
                int marginTop = 95;

                // Altura del texto
                int el_height = 30;

                // Declarar brochas, con las cuales se rellenarán las celdas
                XSolidBrush rect_style1 = new XSolidBrush(XColors.AliceBlue);
                XSolidBrush rect_style2 = new XSolidBrush(XColors.DodgerBlue);

                // Declarar una pluma para dibujar líneas
                XPen line = new XPen(XColors.Black, 1);

                // Distancia desde la parte superior de la hoja
                double dist_Y = marginTop + 50;
                double dist_Y2 = dist_Y - 2;

                teachClass.GetCM(ref dtList, sID, "Periodo Abril - Junio", ciclodb);
                i = 1; // Contador
                if (dtList.Rows.Count > 0)
                {

                    foreach (DataRow rowP in dtList.Rows)
                    {
                        string na = "";
                        // Si es la primera iteración, dibujar el header
                        if (i == 1)
                        {
                            // Relleno de las celdas de título
                            gfx.DrawRectangle(rect_style2, marginLeft, marginTop, page.Width - 2 * marginLeft, 52);

                            // Nombres de las columnas
                            tf.DrawString("No", fontHeader, XBrushes.White, new XRect(marginLeft + 3, marginTop, 20, el_height), format);
                            tf.DrawString("NOMBRE DEL ALUMNO", fontHeader, XBrushes.White, new XRect(marginLeft + 25, marginTop, 120, el_height), format);
                            tf.DrawString("ESCRITURA LEGIBLE", fontHeader2, XBrushes.White, new XRect(marginLeft + 169, marginTop, 40, el_height), format);
                            tf.DrawString("CUMPLE CON EL PROPOSITO COMUNICADO DEL TEXTO", fontHeader2, XBrushes.White, new XRect(marginLeft + 213, marginTop, 40, el_height + 20), format);
                            tf.DrawString("RELACION ADECUADA ENTRE PALABRAS Y ENTRE ENUNCIADOS", fontHeader2, XBrushes.White, new XRect(marginLeft + 266, marginTop, 40, el_height + 30), format);
                            tf.DrawString("DIVERSIDAD DE VOCABULARIO", fontHeader2, XBrushes.White, new XRect(marginLeft + 317, marginTop, 40, el_height + 20), format);
                            tf.DrawString("USOS DE LOS SIGNOS DE PUNTUACION", fontHeader2, XBrushes.White, new XRect(marginLeft + 372, marginTop, 40, el_height), format);
                            tf.DrawString("ORTOGRAFIA", fontHeader2, XBrushes.White, new XRect(marginLeft + 408, marginTop, 570, el_height), format);
                            tf.DrawString("PUNTAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 458, marginTop, 60, el_height), format);
                            tf.DrawString("NIVEL DE APRENDIZAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 496, marginTop, 50, el_height), format);

                            // Líneas para delimitar las celdas
                            gfx.DrawLine(line, marginLeft, marginTop, marginLeft + 555, marginTop);
                            gfx.DrawLine(line, marginLeft, marginTop, marginLeft, marginTop + 52);
                            gfx.DrawLine(line, marginLeft, marginTop + 52, marginLeft + 555, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 555, marginTop, marginLeft + 555, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 18, marginTop, marginLeft + 18, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 167, marginTop, marginLeft + 167, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 211, marginTop, marginLeft + 211, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 264, marginTop, marginLeft + 264, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 315, marginTop, marginLeft + 315, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 370, marginTop, marginLeft + 370, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 406, marginTop, marginLeft + 406, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 457, marginTop, marginLeft + 457, marginTop + 52);
                            gfx.DrawLine(line, marginLeft + 495, marginTop, marginLeft + 495, marginTop + 52);

                            // Agregar a la distancia en Y
                            dist_Y = marginTop + 60;
                        }

                        // Establecer el nivel de aprendizaje
                        if (rowP[11].ToString().Contains("Nivel esperado"))
                            na = "Nivel esperado";
                        else if (rowP[11].ToString().Contains("En desarrollo"))
                            na = "En desarrollo";
                        else if (rowP[11].ToString().Contains("Requiere apoyo"))
                            na = "Requiere apoyo";

                        // Escribir la información del alumno
                        tf.DrawString($"{i}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 5, dist_Y, 20, el_height), format);
                        tf.DrawString($"{sname}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 25, dist_Y, 200, el_height), format);
                        tf.DrawString($"{rowP[3].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 185, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[4].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 233, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[5].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 285, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[6].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 339, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[7].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 385, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[8].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 428, dist_Y, 50, el_height), format);
                        tf.DrawString($"{rowP[9].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 470, dist_Y, 50, el_height), format);
                        tf.DrawString($"{na}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 496, dist_Y, 80, el_height + 10), format);

                        // Dibujar las líneas que delimitan las columnas
                        gfx.DrawLine(line, marginLeft, dist_Y - 15, marginLeft, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 18, dist_Y - 15, marginLeft + 18, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 167, dist_Y - 15, marginLeft + 167, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 211, dist_Y - 15, marginLeft + 211, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 264, dist_Y - 15, marginLeft + 264, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 315, dist_Y - 15, marginLeft + 315, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 370, dist_Y - 15, marginLeft + 370, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 406, dist_Y - 15, marginLeft + 406, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 457, dist_Y - 15, marginLeft + 457, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 495, dist_Y - 15, marginLeft + 495, dist_Y + el_height - 15);
                        gfx.DrawLine(line, marginLeft + 555, dist_Y - 15, marginLeft + 555, dist_Y + el_height - 15);

                        // Guardar nombre del profesor del ciclo pasado
                        name = rowP[16].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No existen datos para generar un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Agregar nombre del profesor del ciclo pasado
                gfx.DrawString($"Prof. {name}", font, XBrushes.Black, 298, 76, XStringFormats.TopCenter);

                // Dibujar la última línea para cerrar la tabla
                gfx.DrawLine(line, marginLeft, dist_Y - 5, marginLeft + 555, dist_Y - 5);

                // Obtener la dirección de Documentos de la máquina
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Especificar la dirección y el nombre del archivo
                string filename = $"{dir}\\EvalSisAT_{eval}_Periodo Abril - Junio_{ciclo}.pdf";

                // Guardar el documento
                document.Save(filename);

                // Enviar un mensaje de confirmación con la dirección del documento
                MessageBox.Show($"Documento guardado en: {dir}\\EvalSisAT_{eval}_Periodo Abril - Junio_{ciclo}.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
