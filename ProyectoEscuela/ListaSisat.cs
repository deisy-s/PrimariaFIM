using DevExpress.Charts.Native;
using DevExpress.Diagram.Core.Layout;
using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports;
using DevExpress.XtraSpreadsheet.Model;
using Mysqlx.Crud;
using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Frames.FrameHelper;
using DevExpress.XtraReports.Native.Printing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Windows.UI.Xaml;
using DevExpress.Emf;

namespace ProyectoEscuela
{
    public partial class ListaSisat : Form
    {
        MySQLMaestro teachClass = new MySQLMaestro();
        bool update = false, cicloEscolar = false;
        int iOpcion, iID, i = 1;
        string sPeriodo, sCiclo = "";
        List<string> sIDs = new List<string>();

        public ListaSisat(int num, int id, string periodo)
        {
            iOpcion = num;
            iID = id;
            sPeriodo = periodo;
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new System.Drawing.Font("Century Gothic", 12, FontStyle.Bold);
            pInicio.Visible = true;

            if (DateTime.Now.Month >= 8 && DateTime.Now.Day >= 1)
                sCiclo = $"{DateTime.Now.Year}-{DateTime.Now.Year + 1}";
            else
                sCiclo = $"{DateTime.Now.Year - 1}-{DateTime.Now.Year}";
        }

        private void ListaSisat_Load(object sender, EventArgs e)
        {
            i = 1;
            switch (iOpcion)
            {
                case 1:
                    lblTitulo.Text = "Cálculo Mental";
                    dgvCalcMental.Visible = true;
                    dgvTomaLectura.Visible = false;
                    dgvProdTextos.Visible = false;
                    btnRubric.Visible = false;

                    dgvCalcMental.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 8);
                    dgvCalcMental.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 6, FontStyle.Bold);
                    dgvCalcMental.Columns[2].Width = 60;
                    dgvCalcMental.Columns[3].Width = 60;
                    dgvCalcMental.Columns[4].Width = 60;
                    dgvCalcMental.Columns[5].Width = 60;
                    dgvCalcMental.Columns[6].Width = 60;
                    dgvCalcMental.Columns[7].Width = 60;
                    dgvCalcMental.Columns[8].Width = 60;
                    dgvCalcMental.Columns[9].Width = 60;
                    dgvCalcMental.Columns[10].Width = 60;
                    dgvCalcMental.Columns[11].Width = 60;
                    dgvCalcMental.Columns[12].Width = 70;
                    dgvCalcMental.Columns[13].Width = 100;
                    dgvCalcMental.Columns[14].Width = 270;

                    LoadExisting();
                    break;
                case 2:
                    lblTitulo.Text = "Producción de Textos";
                    dgvCalcMental.Visible = false;
                    dgvProdTextos.Visible = true;
                    dgvTomaLectura.Visible = false;

                    dgvProdTextos.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 8);
                    dgvProdTextos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 6, FontStyle.Bold);
                    dgvProdTextos.Columns[2].Width = 100;
                    dgvProdTextos.Columns[3].Width = 100;
                    dgvProdTextos.Columns[4].Width = 100;
                    dgvProdTextos.Columns[5].Width = 100;
                    dgvProdTextos.Columns[6].Width = 100;
                    dgvProdTextos.Columns[7].Width = 100;
                    dgvProdTextos.Columns[8].Width = 70;
                    dgvProdTextos.Columns[9].Width = 100;
                    dgvProdTextos.Columns[10].Width = 270;

                    LoadExisting();
                    break;
                case 3:
                    lblTitulo.Text = "Toma de Lectura";
                    dgvCalcMental.Visible = false;
                    dgvProdTextos.Visible = false;
                    dgvTomaLectura.Visible = true;

                    dgvTomaLectura.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 8);
                    dgvTomaLectura.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 6, FontStyle.Bold);
                    dgvTomaLectura.Columns[2].Width = 100;
                    dgvTomaLectura.Columns[3].Width = 100;
                    dgvTomaLectura.Columns[4].Width = 100;
                    dgvTomaLectura.Columns[5].Width = 100;
                    dgvTomaLectura.Columns[6].Width = 100;
                    dgvTomaLectura.Columns[7].Width = 100;
                    dgvTomaLectura.Columns[8].Width = 70;
                    dgvTomaLectura.Columns[9].Width = 100;
                    dgvTomaLectura.Columns[10].Width = 270;

                    LoadExisting();

                    break;
                default:
                    break;
            }
        }

        private void LoadExisting()
        {
            DataTable dt2 = new DataTable();
            bool check = false;
            int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, p9 = 0, p10 = 0;
            teachClass.GetStudentsList(ref dt2, teachClass.GetGrade(iID));

            foreach (DataRow row2 in dt2.Rows)
            {
                if (check)
                    return;
                int studID = Convert.ToInt16(row2[0]);
                DataTable dt3 = new DataTable();
                switch (iOpcion)
                {
                    case 1:
                        teachClass.GetCM(ref dt3, studID, sPeriodo, sCiclo);
                        break;
                    case 2:
                        teachClass.GetPT(ref dt3, studID, sPeriodo, sCiclo);
                        break;
                    case 3:
                        teachClass.GetTL(ref dt3, studID, sPeriodo, sCiclo);
                        break;
                }
                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow row3 in dt3.Rows)
                    {
                        switch (iOpcion)
                        {
                            case 1:
                                dgvCalcMental.Rows.Add(i, row2[1].ToString(), row3[3].ToString(), row3[4].ToString(), row3[5].ToString(), row3[6].ToString(), row3[7].ToString(), row3[8].ToString(), row3[9].ToString(), row3[10].ToString(), row3[11].ToString(), row3[12].ToString(), row3[13].ToString(), row3[15].ToString(), row3[14].ToString());
                                sIDs.Add(row3[2].ToString());
                                if (row3[15].ToString().Contains("Nivel esperado"))
                                {
                                    dgvCalcMental.Rows[i - 1].Cells[13].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.ForestGreen, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                else if (row3[15].ToString().Contains("En desarrollo"))
                                {
                                    dgvCalcMental.Rows[i - 1].Cells[13].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Gold, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                else if (row3[15].ToString().Contains("Requiere apoyo"))
                                {
                                    dgvCalcMental.Rows[i - 1].Cells[13].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Firebrick, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                i++;
                                break;
                            case 2:
                                dgvProdTextos.Rows.Add(i, row2[1].ToString(), row3[3].ToString(), row3[4].ToString(), row3[5].ToString(), row3[6].ToString(), row3[7].ToString(), row3[8].ToString(), row3[9].ToString(), row3[11].ToString(), row3[10].ToString());
                                if (row3[11].ToString().Contains("Nivel esperado"))
                                {
                                    dgvProdTextos.Rows[i - 1].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.ForestGreen, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                else if (row3[11].ToString().Contains("En desarrollo"))
                                {
                                    dgvProdTextos.Rows[i - 1].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Gold, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                else if (row3[11].ToString().Contains("Requiere apoyo"))
                                {
                                    dgvProdTextos.Rows[i - 1].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Firebrick, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                i++;
                                sIDs.Add(row3[2].ToString());
                                break;
                            case 3:
                                dgvTomaLectura.Rows.Add(i, row2[1].ToString(), row3[3].ToString(), row3[4].ToString(), row3[5].ToString(), row3[6].ToString(), row3[7].ToString(), row3[8].ToString(), row3[9].ToString(), row3[11].ToString(), row3[10].ToString());
                                if (row3[11].ToString().Contains("Nivel esperado"))
                                {
                                    dgvTomaLectura.Rows[i - 1].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.ForestGreen, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                else if (row3[11].ToString().Contains("En desarrollo"))
                                {
                                    dgvTomaLectura.Rows[i - 1].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Gold, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                else if (row3[11].ToString().Contains("Requiere apoyo"))
                                {
                                    dgvTomaLectura.Rows[i - 1].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Firebrick, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                                }
                                i++;
                                sIDs.Add(row3[2].ToString());
                                break;
                        }
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
                switch (iOpcion)
                {
                    case 1:
                        dgvCalcMental.Rows.Add(i, row[1].ToString(), "", "", "", "", "", "", "", "", "", "", "", "");
                        i++;
                        sIDs.Add(row[0].ToString());
                        break;
                    case 2:
                        dgvProdTextos.Rows.Add(i, row[1].ToString(), "", "", "", "", "", "", "", "", "");
                        i++;
                        sIDs.Add(row[0].ToString());
                        break;
                    case 3:
                        dgvTomaLectura.Rows.Add(i, row[1].ToString(), "", "", "", "", "", "", "", "");
                        i++;
                        sIDs.Add(row[0].ToString());
                        break;
                }
            }
            return true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pInicio.Visible = false;
            pIndex.Controls.Clear();
            OpcionesSisat newForm = new OpcionesSisat(iID, sPeriodo);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pIndex.Controls.Add(newForm);
            newForm.Show();
        }

        private void btnRubric_Click(object sender, EventArgs e)
        {
            Process open = new Process();
            switch (iOpcion)
            {
                case 2:
                    open.StartInfo = new ProcessStartInfo(System.Windows.Forms.Application.StartupPath + @"\RubricaProduccionTextos.pdf")
                    {
                        UseShellExecute = true
                    };
                    open.Start();
                    break;
                case 3:
                    open.StartInfo = new ProcessStartInfo(System.Windows.Forms.Application.StartupPath + @"\RubricaTomaLectura.pdf")
                    {
                        UseShellExecute = true
                    };
                    open.Start();
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (iOpcion)
                {
                    case 1:
                        SaveCalcM();
                        break;
                    case 2:
                        SaveProdT();
                        break;
                    case 3:
                        SaveTomaL();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCalcM()
        {
            for (int rows = 0; rows < dgvCalcMental.Rows.Count; rows++)
            {
                string p1 = dgvCalcMental.Rows[rows].Cells[2].Value?.ToString();
                string p2 = dgvCalcMental.Rows[rows].Cells[3].Value?.ToString();
                string p3 = dgvCalcMental.Rows[rows].Cells[4].Value?.ToString();
                string p4 = dgvCalcMental.Rows[rows].Cells[5].Value?.ToString();
                string p5 = dgvCalcMental.Rows[rows].Cells[6].Value?.ToString();
                string p6 = dgvCalcMental.Rows[rows].Cells[7].Value?.ToString();
                string p7 = dgvCalcMental.Rows[rows].Cells[8].Value?.ToString();
                string p8 = dgvCalcMental.Rows[rows].Cells[9].Value?.ToString();
                string p9 = dgvCalcMental.Rows[rows].Cells[10].Value?.ToString();
                string p10 = dgvCalcMental.Rows[rows].Cells[11].Value?.ToString();

                if (p1.Contains("v"))
                    p1 = p1.Replace("v", "");
                if (p2.Contains("v"))
                    p2 = p2.Replace("v", "");
                if (p3.Contains("v"))
                    p3 = p3.Replace("v", "");
                if (p4.Contains("v"))
                    p4 = p4.Replace("v", "");
                if (p5.Contains("v"))
                    p5 = p5.Replace("v", "");
                if (p6.Contains("v"))
                    p6 = p6.Replace("v", "");
                if (p7.Contains("v"))
                    p7 = p7.Replace("v", "");
                if (p8.Contains("v"))
                    p8 = p8.Replace("v", "");
                if (p9.Contains("v"))
                    p9 = p9.Replace("v", "");
                if (p10.Contains("v"))
                    p10 = p10.Replace("v", "");

                if (string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) || string.IsNullOrEmpty(p3) || string.IsNullOrEmpty(p4) || string.IsNullOrEmpty(p5) || string.IsNullOrEmpty(p6) || string.IsNullOrEmpty(p7) || string.IsNullOrEmpty(p8) || string.IsNullOrEmpty(p9) || string.IsNullOrEmpty(p10))
                {
                    MessageBox.Show("Favor de llenar todas las celdas de puntajes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt16(p1) < 0 || Convert.ToInt16(p1) > 1 || Convert.ToInt16(p2) < 0 || Convert.ToInt16(p2) > 1 || Convert.ToInt16(p3) < 0 || Convert.ToInt16(p3) > 1 || Convert.ToInt16(p4) > 1 || Convert.ToInt16(p4) < 0 || Convert.ToInt16(p5) > 1 || Convert.ToInt16(p5) < 0 || Convert.ToInt16(p6) > 1 || Convert.ToInt16(p6) < 0 || Convert.ToInt16(p7) > 1 || Convert.ToInt16(p7) < 0 || Convert.ToInt16(p8) > 1 || Convert.ToInt16(p8) < 0 || Convert.ToInt16(p9) > 1 || Convert.ToInt16(p9) < 0 || Convert.ToInt16(p10) > 1 || Convert.ToInt16(p10) < 0)
                {
                    MessageBox.Show("Los puntos en esta evaluación deben ser 0, 1 o 1v");
                    return;
                }
            }

            if (!update)
            {
                for (int rows = 0; rows < dgvCalcMental.Rows.Count; rows++)
                {
                    string id = sIDs[rows];
                    string p1 = dgvCalcMental.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvCalcMental.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvCalcMental.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvCalcMental.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvCalcMental.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvCalcMental.Rows[rows].Cells[7].Value?.ToString();
                    string p7 = dgvCalcMental.Rows[rows].Cells[8].Value?.ToString();
                    string p8 = dgvCalcMental.Rows[rows].Cells[9].Value?.ToString();
                    string p9 = dgvCalcMental.Rows[rows].Cells[10].Value?.ToString();
                    string p10 = dgvCalcMental.Rows[rows].Cells[11].Value?.ToString();
                    string pFinal = dgvCalcMental.Rows[rows].Cells[12].Value?.ToString();
                    string na = dgvCalcMental.Rows[rows].Cells[13].Value?.ToString();
                    string obs = dgvCalcMental.Rows[rows].Cells[14].Value?.ToString();

                    // Obtener el nombre del maestro
                    string name = teachClass.GetName(iID);
                    // Obtener el grupo
                    int group = teachClass.GetGrade(iID);

                    if (!teachClass.AddCM(Convert.ToInt16(id), p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Convert.ToInt16(pFinal), na, obs, name, sPeriodo, group, sCiclo))
                    {
                        MessageBox.Show("Error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                for (int rows = 0; rows < dgvCalcMental.Rows.Count; rows++)
                {
                    string id = sIDs[rows];
                    string p1 = dgvCalcMental.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvCalcMental.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvCalcMental.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvCalcMental.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvCalcMental.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvCalcMental.Rows[rows].Cells[7].Value?.ToString();
                    string p7 = dgvCalcMental.Rows[rows].Cells[8].Value?.ToString();
                    string p8 = dgvCalcMental.Rows[rows].Cells[9].Value?.ToString();
                    string p9 = dgvCalcMental.Rows[rows].Cells[10].Value?.ToString();
                    string p10 = dgvCalcMental.Rows[rows].Cells[11].Value?.ToString();
                    string pFinal = dgvCalcMental.Rows[rows].Cells[12].Value?.ToString();
                    string na = dgvCalcMental.Rows[rows].Cells[13].Value?.ToString();
                    string obs = dgvCalcMental.Rows[rows].Cells[14].Value?.ToString();

                    // Obtener grupo
                    int group = teachClass.GetGrade(iID);

                    if (!teachClass.UpdateCM(Convert.ToInt16(id), p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Convert.ToInt16(pFinal), na, obs, sPeriodo, group, sCiclo))
                    {
                        MessageBox.Show("Error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            MessageBox.Show("Calificaciones guardadas");
        }

        private void SaveProdT()
        {
            for (int rows = 0; rows < dgvProdTextos.Rows.Count; rows++)
            {
                string p1 = dgvProdTextos.Rows[rows].Cells[2].Value?.ToString();
                string p2 = dgvProdTextos.Rows[rows].Cells[3].Value?.ToString();
                string p3 = dgvProdTextos.Rows[rows].Cells[4].Value?.ToString();
                string p4 = dgvProdTextos.Rows[rows].Cells[5].Value?.ToString();
                string p5 = dgvProdTextos.Rows[rows].Cells[6].Value?.ToString();
                string p6 = dgvProdTextos.Rows[rows].Cells[7].Value?.ToString();

                if (string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) || string.IsNullOrEmpty(p3) || string.IsNullOrEmpty(p4) || string.IsNullOrEmpty(p5) || string.IsNullOrEmpty(p6))
                {
                    MessageBox.Show("Favor de llenar todas las celdas de puntajes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt16(p1) < 1 || Convert.ToInt16(p1) > 3 || Convert.ToInt16(p2) < 1 || Convert.ToInt16(p2) > 3 || Convert.ToInt16(p3) < 1 || Convert.ToInt16(p3) > 3 || 
                    Convert.ToInt16(p4) > 3 || Convert.ToInt16(p4) < 1 || Convert.ToInt16(p5) > 3 || Convert.ToInt16(p5) < 1 || Convert.ToInt16(p6) > 3 || Convert.ToInt16(p6) < 1)
                {
                    MessageBox.Show("Los puntos en esta evaluación cuentan con un rango de 1-3", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!update)
            {
                for (int rows = 0; rows < dgvProdTextos.Rows.Count; rows++)
                {
                    string id = sIDs[rows];
                    string p1 = dgvProdTextos.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvProdTextos.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvProdTextos.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvProdTextos.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvProdTextos.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvProdTextos.Rows[rows].Cells[7].Value?.ToString();
                    string pFinal = dgvProdTextos.Rows[rows].Cells[8].Value?.ToString();
                    string na = dgvProdTextos.Rows[rows].Cells[9].Value?.ToString();
                    string obs = dgvProdTextos.Rows[rows].Cells[10].Value?.ToString();

                    // Nombre de maestro
                    string name = teachClass.GetName(iID);
                    // Grupo
                    int group = teachClass.GetGrade(iID);

                    if (!teachClass.AddPT(Convert.ToInt16(id), Convert.ToInt16(p1), Convert.ToInt16(p2), Convert.ToInt16(p3), Convert.ToInt16(p4), Convert.ToInt16(p5), Convert.ToInt16(p6), Convert.ToInt16(pFinal), na, obs, name, sPeriodo, group, sCiclo))
                    {
                        MessageBox.Show("Error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                for (int rows = 0; rows < dgvProdTextos.Rows.Count; rows++)
                {
                    string id = sIDs[rows];
                    string p1 = dgvProdTextos.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvProdTextos.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvProdTextos.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvProdTextos.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvProdTextos.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvProdTextos.Rows[rows].Cells[7].Value?.ToString();
                    string pFinal = dgvProdTextos.Rows[rows].Cells[8].Value?.ToString();
                    string na = dgvProdTextos.Rows[rows].Cells[9].Value?.ToString();
                    string obs = dgvProdTextos.Rows[rows].Cells[10].Value?.ToString();

                    // Grupo
                    int group = teachClass.GetGrade(iID);

                    if (!teachClass.UpdatePT(Convert.ToInt16(id), Convert.ToInt16(p1), Convert.ToInt16(p2), Convert.ToInt16(p3), Convert.ToInt16(p4), Convert.ToInt16(p5), Convert.ToInt16(p6), 
                        Convert.ToInt16(pFinal), na, obs, sPeriodo, group, sCiclo))
                    {
                        MessageBox.Show("Error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            MessageBox.Show("Calificaciones guardadas");
        }

        private void SaveTomaL()
        {
            for (int rows = 0; rows < dgvTomaLectura.Rows.Count; rows++)
            {
                string p1 = dgvTomaLectura.Rows[rows].Cells[2].Value?.ToString();
                string p2 = dgvTomaLectura.Rows[rows].Cells[3].Value?.ToString();
                string p3 = dgvTomaLectura.Rows[rows].Cells[4].Value?.ToString();
                string p4 = dgvTomaLectura.Rows[rows].Cells[5].Value?.ToString();
                string p5 = dgvTomaLectura.Rows[rows].Cells[6].Value?.ToString();
                string p6 = dgvTomaLectura.Rows[rows].Cells[7].Value?.ToString();

                if (string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) || string.IsNullOrEmpty(p3) || string.IsNullOrEmpty(p4) || string.IsNullOrEmpty(p5) || string.IsNullOrEmpty(p6))
                {
                    MessageBox.Show("Favor de llenar todas las celdas de puntajes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(Convert.ToInt16(p1) < 1 || Convert.ToInt16(p1) > 3 || Convert.ToInt16(p2) < 1 || Convert.ToInt16(p2) > 3 || Convert.ToInt16(p3) < 1 || Convert.ToInt16(p3) > 3 || Convert.ToInt16(p4) > 3 || Convert.ToInt16(p4) < 1 || Convert.ToInt16(p5) > 3 || Convert.ToInt16(p5) < 1 || Convert.ToInt16(p6) > 3 || Convert.ToInt16(p6) < 1)
                {
                    MessageBox.Show("Los puntos en esta evaluación cuentan con un rango de 1-3");
                    return;
                }
            }

            if (!update)
            {
                for (int rows = 0; rows < dgvTomaLectura.Rows.Count; rows++)
                {
                    string id = sIDs[rows];
                    string p1 = dgvTomaLectura.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvTomaLectura.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvTomaLectura.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvTomaLectura.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvTomaLectura.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvTomaLectura.Rows[rows].Cells[7].Value?.ToString();
                    string pFinal = dgvTomaLectura.Rows[rows].Cells[8].Value?.ToString();
                    string na = dgvTomaLectura.Rows[rows].Cells[9].Value?.ToString();
                    string obs = dgvTomaLectura.Rows[rows].Cells[10].Value?.ToString();

                    // Nombre de maestro
                    string name = teachClass.GetName(iID);
                    // Grupo
                    int group = teachClass.GetGrade(iID);

                    if (!teachClass.AddTL(Convert.ToInt16(id), Convert.ToInt16(p1), Convert.ToInt16(p2), Convert.ToInt16(p3), Convert.ToInt16(p4), Convert.ToInt16(p5), Convert.ToInt16(p6), Convert.ToInt16(pFinal), na, obs, name, sPeriodo, group, sCiclo))
                    {
                        MessageBox.Show("Error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                for (int rows = 0; rows < dgvTomaLectura.Rows.Count; rows++)
                {
                    string id = sIDs[rows];
                    string p1 = dgvTomaLectura.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvTomaLectura.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvTomaLectura.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvTomaLectura.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvTomaLectura.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvTomaLectura.Rows[rows].Cells[7].Value?.ToString();
                    string pFinal = dgvTomaLectura.Rows[rows].Cells[8].Value?.ToString();
                    string na = dgvTomaLectura.Rows[rows].Cells[9].Value?.ToString();
                    string obs = dgvTomaLectura.Rows[rows].Cells[10].Value?.ToString();

                    // Grupo
                    int group = teachClass.GetGrade(iID);

                    if (!teachClass.UpdateTL(Convert.ToInt16(id), Convert.ToInt16(p1), Convert.ToInt16(p2), Convert.ToInt16(p3), Convert.ToInt16(p4), Convert.ToInt16(p5), Convert.ToInt16(p6), Convert.ToInt16(pFinal), na, obs, sPeriodo, group, sCiclo))
                    {
                        MessageBox.Show("Error: " + teachClass.sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            MessageBox.Show("Calificaciones guardadas");
        }

        private void dgvCalcMental_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int rows = 0; rows < dgvCalcMental.Rows.Count; rows++)
                {
                    string p1 = dgvCalcMental.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvCalcMental.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvCalcMental.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvCalcMental.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvCalcMental.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvCalcMental.Rows[rows].Cells[7].Value?.ToString();
                    string p7 = dgvCalcMental.Rows[rows].Cells[8].Value?.ToString();
                    string p8 = dgvCalcMental.Rows[rows].Cells[9].Value?.ToString();
                    string p9 = dgvCalcMental.Rows[rows].Cells[10].Value?.ToString();
                    string p10 = dgvCalcMental.Rows[rows].Cells[11].Value?.ToString();

                    if (p1.Contains("v"))
                        p1 = p1.Replace("v", "");
                    if (p2.Contains("v"))
                        p2 = p2.Replace("v", "");
                    if (p3.Contains("v"))
                        p3 = p3.Replace("v", "");
                    if (p4.Contains("v"))
                        p4 = p4.Replace("v", "");
                    if (p5.Contains("v"))
                        p5 = p5.Replace("v", "");
                    if (p6.Contains("v"))
                        p6 = p6.Replace("v", "");
                    if (p7.Contains("v"))
                        p7 = p7.Replace("v", "");
                    if (p8.Contains("v"))
                        p8 = p8.Replace("v", "");
                    if (p9.Contains("v"))
                        p9 = p9.Replace("v", "");
                    if (p10.Contains("v"))
                        p10 = p10.Replace("v", "");

                    if (!string.IsNullOrEmpty(p1) && !string.IsNullOrEmpty(p2) && !string.IsNullOrEmpty(p3) && !string.IsNullOrEmpty(p4) && !string.IsNullOrEmpty(p5) && !string.IsNullOrEmpty(p6) && !string.IsNullOrEmpty(p7) && !string.IsNullOrEmpty(p8) && !string.IsNullOrEmpty(p9) && !string.IsNullOrEmpty(p10))
                    {
                        if (int.Parse(p1) <= 1 && int.Parse(p2) <= 1 && int.Parse(p3) <= 1 && int.Parse(p4) <= 1 && int.Parse(p5) <= 1 && int.Parse(p6) <= 1 && int.Parse(p7) <= 1 && int.Parse(p8) <= 1 && int.Parse(p9) <= 1 && int.Parse(p10) <= 1)
                        {
                            int pFinal = int.Parse(p1) + int.Parse(p2) + int.Parse(p3) + int.Parse(p4) + int.Parse(p5) + int.Parse(p6) + int.Parse(p7) + int.Parse(p8) + int.Parse(p9) + int.Parse(p10);
                            dgvCalcMental.Rows[rows].Cells[12].Value = pFinal.ToString();

                            string na;
                            if (pFinal >= 8)
                            {
                                na = $"{pFinal} - Nivel esperado";
                                dgvCalcMental.Rows[rows].Cells[13].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.ForestGreen, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }
                            else if (pFinal >= 5)
                            {
                                na = $"{pFinal} - En desarrollo";
                                dgvCalcMental.Rows[rows].Cells[13].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Gold, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }
                            else
                            {
                                na = $"{pFinal} - Requiere apoyo";
                                dgvCalcMental.Rows[rows].Cells[13].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Firebrick, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }

                            dgvCalcMental.Rows[rows].Cells[13].Value = na;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProdTextos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int rows = 0; rows < dgvProdTextos.Rows.Count; rows++)
                {
                    string p1 = dgvProdTextos.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvProdTextos.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvProdTextos.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvProdTextos.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvProdTextos.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvProdTextos.Rows[rows].Cells[7].Value?.ToString();

                    if (!string.IsNullOrEmpty(p1) && !string.IsNullOrEmpty(p2) && !string.IsNullOrEmpty(p3) && !string.IsNullOrEmpty(p4) && !string.IsNullOrEmpty(p5) && !string.IsNullOrEmpty(p6))
                    {
                        if (int.Parse(p1) <= 3 && int.Parse(p2) <= 3 && int.Parse(p3) <= 3 && int.Parse(p4) <= 3 && int.Parse(p5) <= 3 && int.Parse(p6) <= 3)
                        {
                            int pFinal = int.Parse(p1) + int.Parse(p2) + int.Parse(p3) + int.Parse(p4) + int.Parse(p5) + int.Parse(p6);

                            string na;
                            if (pFinal >= 15)
                            {
                                na = $"{pFinal} - Nivel esperado";
                                dgvProdTextos.Rows[rows].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.ForestGreen, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }
                            else if (pFinal >= 10)
                            {
                                na = $"{pFinal} - En desarrollo";
                                dgvProdTextos.Rows[rows].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Gold, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }
                            else
                            {
                                na = $"{pFinal} - Requiere apoyo";
                                dgvProdTextos.Rows[rows].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Firebrick, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }

                            dgvProdTextos.Rows[rows].Cells[8].Value = pFinal.ToString();
                            dgvProdTextos.Rows[rows].Cells[9].Value = na;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTomaLectura_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int rows = 0; rows < dgvTomaLectura.Rows.Count; rows++)
                {
                    string p1 = dgvTomaLectura.Rows[rows].Cells[2].Value?.ToString();
                    string p2 = dgvTomaLectura.Rows[rows].Cells[3].Value?.ToString();
                    string p3 = dgvTomaLectura.Rows[rows].Cells[4].Value?.ToString();
                    string p4 = dgvTomaLectura.Rows[rows].Cells[5].Value?.ToString();
                    string p5 = dgvTomaLectura.Rows[rows].Cells[6].Value?.ToString();
                    string p6 = dgvTomaLectura.Rows[rows].Cells[7].Value?.ToString();

                    if (!string.IsNullOrEmpty(p1) && !string.IsNullOrEmpty(p2) && !string.IsNullOrEmpty(p3) && !string.IsNullOrEmpty(p4) && !string.IsNullOrEmpty(p5) && !string.IsNullOrEmpty(p6))
                    {
                        if (int.Parse(p1) <= 3 && int.Parse(p2) <= 3 && int.Parse(p3) <= 3 && int.Parse(p4) <= 3 && int.Parse(p5) <= 3 && int.Parse(p6) <= 3)
                        {
                            int pFinal = int.Parse(p1) + int.Parse(p2) + int.Parse(p3) + int.Parse(p4) + int.Parse(p5) + int.Parse(p6);

                            string na;
                            if (pFinal >= 15)
                            {
                                na = $"{pFinal} - Nivel esperado";
                                dgvTomaLectura.Rows[rows].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.ForestGreen, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }
                            else if (pFinal >= 10)
                            {
                                na = $"{pFinal} - En desarrollo";
                                dgvTomaLectura.Rows[rows].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Gold, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }
                            else
                            {
                                na = $"{pFinal} - Requiere apoyo";
                                dgvTomaLectura.Rows[rows].Cells[9].Style = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Firebrick, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Century Gothic", 8, FontStyle.Bold) };
                            }

                            dgvTomaLectura.Rows[rows].Cells[8].Value = pFinal.ToString();
                            dgvTomaLectura.Rows[rows].Cells[9].Value = na;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pdfGraph_Click(object sender, EventArgs e)
        {
            try
            {
                // Declarar variables, obtener grado y nombre de maestro
                DataTable dt = new DataTable();
                int grade = teachClass.GetGrade(iID);
                int ne = 0, ed = 0, ra = 0;
                string eval = "", ciclo = "", name = "", grado = "", periodo = "";
                name = teachClass.GetName(iID);

                // Obtener los niveles de aprendizaje de la evaluación solicitada
                switch (iOpcion)
                {
                    case 1:
                        ne = teachClass.GetCountCMNE(grade, sPeriodo, sCiclo);
                        ed = teachClass.GetCountCMED(grade, sPeriodo, sCiclo);
                        ra = teachClass.GetCountCMRA(grade, sPeriodo, sCiclo);
                        eval = "Cálculo Mental";
                        break;
                    case 2:
                        ne = teachClass.GetCountPTNE(grade, sPeriodo, sCiclo);
                        ed = teachClass.GetCountPTED(grade, sPeriodo, sCiclo);
                        ra = teachClass.GetCountPTRA(grade, sPeriodo, sCiclo);
                        eval = "Producción de Textos";
                        break;
                    case 3:
                        ne = teachClass.GetCountTLNE(grade, sPeriodo, sCiclo);
                        ed = teachClass.GetCountTLED(grade, sPeriodo, sCiclo);
                        ra = teachClass.GetCountTLRA(grade, sPeriodo, sCiclo);
                        eval = "Toma de Lectura";
                        break;
                }

                // Evaluar si existen datos para cada variable de nivel de aprendizaje
                // Si está vacío, se sale del método    
                if (ne == 0 && ed == 0 && ra == 0)
                {
                    MessageBox.Show("No se ha capturado ningún dato para generar una gráfica", "Error", MessageBoxButtons.OK);
                    return;
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

                // Establecer el grado como string
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

                switch (sPeriodo)
                {
                    case "Periodo Agosto - Noviembre":
                        periodo = "Primer trimestre: Noviembre";
                        break;
                    case "Periodo Diciembre - Marzo":
                        periodo = "Segundo trimestre: Marzo";
                        break;
                    case "Periodo Abril - Junio":
                        periodo = "Tercer trimestre: Junio";
                        break;
                }

                // Crear documento PDF
                PdfDocument document = new PdfDocument();

                // Agregar una hoja al documento
                PdfPage page = document.AddPage();

                // Crear un objeto XGraphics para dibujar sobre el documento
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Agregar la imagen del logo de la SEP
                gfx.DrawImage(XImage.FromFile(System.Windows.Forms.Application.StartupPath + @"logoSEP.png"), 30, -15, 100, 100);

                // Declarar las fuentes a utilizar
                XFont font = new XFont("Verdana", 10, XFontStyleEx.Bold);
                XFont font2 = new XFont("Verdana", 10, XFontStyleEx.Regular);

                // Agregar texto al documento
                gfx.DrawString("Gráfica de Concentrado de Salón de Evaluación SisAT", font, XBrushes.Black, 300, 10, XStringFormats.TopCenter);
                gfx.DrawString(eval, font, XBrushes.Black, 300, 21, XStringFormats.TopCenter);
                gfx.DrawString(periodo, font, XBrushes.Black, 300, 65, XStringFormats.TopCenter);
                gfx.DrawString("Escuela Primaria Francisco I. Madero", font, XBrushes.Black, 300, 32, XStringFormats.TopCenter);
                gfx.DrawString("Zona 077 | Sector III", font, XBrushes.Black, 298, 43, XStringFormats.TopCenter);
                gfx.DrawString($"{grado} Grado | Ciclo Escolar {ciclo}", font, XBrushes.Black, 298, 54, XStringFormats.TopCenter);
                gfx.DrawString($"Prof. {name}", font, XBrushes.Black, 298, 76, XStringFormats.TopCenter);

                // Crear brochas para dibujar los rectángulos de la gráfica
                XSolidBrush rect_style1 = new XSolidBrush(XColors.ForestGreen); 
                XSolidBrush rect_style2 = new XSolidBrush(XColors.Gold); 
                XSolidBrush rect_style3 = new XSolidBrush(XColors.Red); 

                // Crear plumas para dibujar líneas
                XPen line = new XPen(XColors.Black, 2);
                XPen line2 = new XPen(XColors.Black, 1);

                // Dibujar rectángulos
                gfx.DrawRectangle(rect_style1, 90, 600, 80, -(ne * 10));
                gfx.DrawRectangle(rect_style2, 255, 600, 80, -(ed * 10));
                gfx.DrawRectangle(rect_style3, 425, 600, 80, -(ra * 10));

                // Dibujar líneas
                // Línea sobre la cual se encuentra la gráfica
                gfx.DrawLine(line, 50, 600, 540, 600);
                // Líneas que se utilizan como borde de los rectángulos
                gfx.DrawLine(line2, 90, 600, 90, 600-(ne * 10));
                gfx.DrawLine(line2, 90, 600-(ne * 10), 170, 600-(ne * 10));
                gfx.DrawLine(line2, 170, 600, 170, 600-(ne * 10));
                gfx.DrawLine(line2, 255, 600, 255, 600 - (ed * 10));
                gfx.DrawLine(line2, 255, 600 - (ed * 10), 335, 600 - (ed * 10));
                gfx.DrawLine(line2, 335, 600, 335, 600 - (ed * 10));
                gfx.DrawLine(line2, 425, 600, 425, 600 - (ra * 10));
                gfx.DrawLine(line2, 425, 600 - (ra * 10), 505, 600 - (ra * 10));
                gfx.DrawLine(line2, 505, 600, 505, 600 - (ra * 10));

                // Escribir el nivel de aprendizaje y la cantidad de alumnos en cada nivel
                gfx.DrawString("Nivel esperado", font2, XBrushes.Black, 130, 610, XStringFormats.TopCenter);
                gfx.DrawString($"{ne}", font2, XBrushes.DarkGreen, 127, 580 - (ne * 10), XStringFormats.TopCenter);
                gfx.DrawString("En desarrollo", font2, XBrushes.Black, 296, 610, XStringFormats.TopCenter);
                gfx.DrawString($"{ed}", font2, XBrushes.DarkGoldenrod, 292, 580 - (ed * 10), XStringFormats.TopCenter);
                gfx.DrawString("Requiere apoyo", font2, XBrushes.Black, 464, 610, XStringFormats.TopCenter);
                gfx.DrawString($"{ra}", font2, XBrushes.DarkRed, 462, 580 - (ra * 10), XStringFormats.TopCenter);

                // Obtener la ruta a Documentos
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Guardar el documento en la ruta y con el nombre indicado
                string filename = $"{dir}\\Grafica_{eval}_{sPeriodo}_{sCiclo}.pdf";
                
                //Guardar el documento
                document.Save(filename);

                // Mensaje de confirmación con la ruta del documento
                MessageBox.Show($"Gráfica guardada en: {dir}\\Grafica_{eval}_{sPeriodo}_{sCiclo}.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            try
            {
                // Declarar variables necesarias y obtener grado y la lista de alumnos
                DataTable dtList = new DataTable();
                int grade = teachClass.GetGrade(iID), i = 1;
                teachClass.GetStudentsList(ref dtList, grade);
                string eval = "", ciclo = "", name = teachClass.GetName(iID), grado = "", periodo = "";

                // Obtener los años del ciclo escolar
                if (DateTime.Now.Month >= 8 && DateTime.Now.Day >= 1)
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y} - {y + 1}";
                }
                else
                {
                    int y = DateTime.Now.Year;
                    ciclo = $"{y - 1} - {y}";
                }

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

                switch (sPeriodo)
                {
                    case "Periodo Agosto - Noviembre":
                        periodo = "Primer trimestre: Noviembre";
                        break;
                    case "Periodo Diciembre - Marzo":
                        periodo = "Segundo trimestre: Marzo";
                        break;
                    case "Periodo Abril - Junio":
                        periodo = "Tercer trimestre: Junio";
                        break;
                }

                // Obtener el nombre de la evaluación SisAT
                switch (iOpcion)
                {
                    case 1:
                        eval = "Cálculo Mental";
                        break;
                    case 2:
                        eval = "Producción de Textos";
                        break;
                    case 3:
                        eval = "Toma de Lectura";
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
                gfx.DrawString(periodo, font, XBrushes.Black, 300, 65, XStringFormats.TopCenter);
                gfx.DrawString("Escuela Primaria Francisco I. Madero", font, XBrushes.Black, 300, 32, XStringFormats.TopCenter);
                gfx.DrawString("Zona 077 | Sector III", font, XBrushes.Black, 298, 43, XStringFormats.TopCenter);
                gfx.DrawString($"{grado} Grado | Ciclo Escolar {ciclo}", font, XBrushes.Black, 298, 54, XStringFormats.TopCenter);
                gfx.DrawString($"Prof. {name}", font, XBrushes.Black, 298, 76, XStringFormats.TopCenter);

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
                XFont fontParagraph2 = new XFont("Verdana", 8, XFontStyleEx.Bold);

                // Margen de la hoja
                int marginLeft = 20;
                int marginRight = marginLeft + 555;
                int marginTop = 95;

                // Altura del texto
                int el_height = 30;

                // Declarar brochas, con las cuales se rellenarán las celdas
                XSolidBrush rect_style1 = new XSolidBrush(XColors.AliceBlue);
                XSolidBrush rect_style2 = new XSolidBrush(XColors.DodgerBlue);
                XSolidBrush rect_ne = new XSolidBrush(XColors.ForestGreen);
                XSolidBrush rect_ed = new XSolidBrush(XColors.Gold);
                XSolidBrush rect_ra = new XSolidBrush(XColors.Red);

                // Declarar una pluma para dibujar líneas
                XPen line = new XPen(XColors.Black, 1);

                // Distancia desde la parte superior de la hoja
                double dist_Y = marginTop + 50;
                double dist_Y2 = dist_Y - 2;

                i = 1; // Contador
                foreach (DataRow rowL in dtList.Rows)
                {
                    // Obtener la idetificación de un alumno
                    int studID = Convert.ToInt16(rowL[0]);
                    DataTable dtPoints = new DataTable();

                    // Obtener sus resultados de una evaluación SisAT
                    switch (iOpcion)
                    {
                        case 1:
                            teachClass.GetCM(ref dtPoints, studID, sPeriodo, sCiclo);
                            break;
                        case 2:
                            teachClass.GetPT(ref dtPoints, studID, sPeriodo, sCiclo);
                            break;
                        case 3:
                            teachClass.GetTL(ref dtPoints, studID, sPeriodo, sCiclo);
                            break;
                    }

                    // Evaluar si se encuentra vacío el DataTable
                    if (dtPoints.Rows.Count > 0)
                    {
                        foreach (DataRow rowP in dtPoints.Rows)
                        {
                            // Rellenar cada segunda fila de otro color
                            if (i % 2 == 0)
                            {
                                gfx.DrawRectangle(rect_style1, marginLeft, dist_Y - 5, page.Width - 2 * marginLeft, el_height / 2 + 5);
                            }

                            string na = "";
                            switch (iOpcion)
                            {
                                case 1:
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
                                    {
                                        na = "Nivel esperado";
                                        gfx.DrawRectangle(rect_ne, marginLeft + 465, dist_Y-5, 90, 20);
                                    }
                                    else if (rowP[15].ToString().Contains("En desarrollo"))
                                    {
                                        na = "En desarrollo";
                                        gfx.DrawRectangle(rect_ed, marginLeft + 465, dist_Y-5, 90, 20);
                                    }
                                    else if (rowP[15].ToString().Contains("Requiere apoyo"))
                                    {
                                        na = "Requiere apoyo";
                                        gfx.DrawRectangle(rect_ra, marginLeft + 465, dist_Y-5, 90, 20);
                                    }

                                    // Escribir la información del alumno
                                    tf.DrawString($"{i}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 12, dist_Y, 20, el_height), format);
                                    tf.DrawString($"{rowL[1].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 40, dist_Y, 200, el_height), format);
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
                                    tf.DrawString($"{na}", fontParagraph2, XBrushes.White, new XRect(marginLeft + 470, dist_Y, 80, el_height), format);

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
                                    break;
                                case 2:
                                    // Si es la primera iteración, dibujar el header
                                    if (i == 1)
                                    {
                                        marginRight = marginLeft + 565;
                                        // Relleno de las celdas de título
                                        gfx.DrawRectangle(rect_style2, marginLeft, marginTop, page.Width - 2 * marginLeft, 52);
                                        gfx.DrawRectangle(rect_style2, marginLeft+496, marginTop, 69, 52);

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
                                        tf.DrawString("NIVEL DE APRENDIZAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 496, marginTop, 55, el_height), format);

                                        // Líneas para delimitar las celdas
                                        gfx.DrawLine(line, marginLeft, marginTop, marginLeft + 565, marginTop);
                                        gfx.DrawLine(line, marginLeft, marginTop, marginLeft, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft, marginTop + 52, marginLeft + 565, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 565, marginTop, marginLeft + 565, marginTop + 52);
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
                                    {
                                        na = "Nivel esperado";
                                        gfx.DrawRectangle(rect_ne, marginLeft + 495, dist_Y - 5, 70, 20);
                                    }
                                    else if (rowP[11].ToString().Contains("En desarrollo"))
                                    {
                                        na = "En desarrollo";
                                        gfx.DrawRectangle(rect_ed, marginLeft + 495, dist_Y - 5, 70, 20);
                                    }
                                    else if (rowP[11].ToString().Contains("Requiere apoyo"))
                                    {
                                        na = "Requiere apoyo";
                                        gfx.DrawRectangle(rect_ra, marginLeft + 495, dist_Y - 5, 70, 20);
                                    }

                                    // Escribir la información del alumno
                                    tf.DrawString($"{i}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 5, dist_Y, 20, el_height), format);
                                    tf.DrawString($"{rowL[1].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 25, dist_Y, 200, el_height), format);
                                    tf.DrawString($"{rowP[3].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 185, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[4].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 233, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[5].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 285, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[6].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 339, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[7].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 385, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[8].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 428, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[9].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 470, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{na}", fontParagraph2, XBrushes.White, new XRect(marginLeft + 496, dist_Y, 80, el_height + 10), format);

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
                                    gfx.DrawLine(line, marginLeft + 565, dist_Y - 15, marginLeft + 565, dist_Y + el_height - 15);
                                    break;
                                case 3:
                                    // Si es la primera iteración, dibujar el header de la tabla
                                    if (i == 1)
                                    {
                                        marginRight = marginLeft + 565;
                                        // Dibujar el rectángulo donde se encuentran los nombres de las columnas
                                        gfx.DrawRectangle(rect_style2, marginLeft, marginTop, page.Width - 2 * marginLeft, 43);
                                        gfx.DrawRectangle(rect_style2, marginLeft + 496, marginTop, 69, 43);

                                        // Escribir los nombres de las columnas
                                        tf.DrawString("No", fontHeader, XBrushes.White, new XRect(marginLeft + 3, marginTop, 20, el_height), format);
                                        tf.DrawString("NOMBRE DEL ALUMNO", fontHeader, XBrushes.White, new XRect(marginLeft + 25, marginTop, 120, el_height), format);
                                        tf.DrawString("LECTURA FLUIDA", fontHeader2, XBrushes.White, new XRect(marginLeft + 169, marginTop, 40, el_height), format);
                                        tf.DrawString("PRECISION DE LA LECTURA", fontHeader2, XBrushes.White, new XRect(marginLeft + 205, marginTop, 40, el_height + 20), format);
                                        tf.DrawString("ATENCION A PALABRAS COMPLEJAS", fontHeader2, XBrushes.White, new XRect(marginLeft + 250, marginTop, 40, el_height + 30), format);
                                        tf.DrawString("USO ADECUADO DE LA VOZ AL LEER", fontHeader2, XBrushes.White, new XRect(marginLeft + 295, marginTop, 40, el_height + 20), format);
                                        tf.DrawString("SEGURIDAD Y DISPOSICION ANTE LA LECTURA", fontHeader2, XBrushes.White, new XRect(marginLeft + 339, marginTop, 40, el_height), format);
                                        tf.DrawString("COMPRENSION GENERAL DE LA LECTURA", fontHeader2, XBrushes.White, new XRect(marginLeft + 392, marginTop, 40, el_height + 20), format);
                                        tf.DrawString("PUNTAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 449, marginTop, 60, el_height), format);
                                        tf.DrawString("NIVEL DE APRENDIZAJE", fontHeader, XBrushes.White, new XRect(marginLeft + 488, marginTop, 50, el_height), format);

                                        // Dibujar las líneas que delimitan las celdas
                                        gfx.DrawLine(line, marginLeft, marginTop, marginLeft + 565, marginTop);
                                        gfx.DrawLine(line, marginLeft, marginTop, marginLeft, marginTop + 43);
                                        gfx.DrawLine(line, marginLeft, marginTop + 43, marginLeft + 565, marginTop + 43);
                                        gfx.DrawLine(line, marginLeft + 565, marginTop, marginLeft + 565, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 18, marginTop, marginLeft + 18, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 167, marginTop, marginLeft + 167, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 203, marginTop, marginLeft + 203, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 248, marginTop, marginLeft + 248, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 293, marginTop, marginLeft + 293, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 337, marginTop, marginLeft + 337, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 390, marginTop, marginLeft + 390, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 447, marginTop, marginLeft + 447, marginTop + 52);
                                        gfx.DrawLine(line, marginLeft + 486, marginTop, marginLeft + 486, marginTop + 52);

                                        // Agregar a la distancia en Y con la cual se establecen las coordenadas
                                        dist_Y = marginTop + 50;
                                    }

                                    // Establecer el nivel de aprendizaje
                                    if (rowP[11].ToString().Contains("Nivel esperado"))
                                    {
                                        na = "Nivel esperado";
                                        gfx.DrawRectangle(rect_ne, marginLeft + 486, dist_Y - 5, 79, 20);
                                    }
                                    else if (rowP[11].ToString().Contains("En desarrollo"))
                                    {
                                        na = "En desarrollo";
                                        gfx.DrawRectangle(rect_ed, marginLeft + 486, dist_Y - 5, 79, 20);
                                    }
                                    else if (rowP[11].ToString().Contains("Requiere apoyo"))
                                    {
                                        na = "Requiere apoyo";
                                        gfx.DrawRectangle(rect_ra, marginLeft + 486, dist_Y - 5, 79, 20);
                                    }

                                    // Escribir la información del alumno
                                    tf.DrawString($"{i}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 5, dist_Y, 20, el_height), format);
                                    tf.DrawString($"{rowL[1].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 25, dist_Y, 200, el_height), format);
                                    tf.DrawString($"{rowP[3].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 182, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[4].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 222, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[5].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 268, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[6].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 311, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[7].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 360, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[8].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 415, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{rowP[9].ToString()}", fontParagraph, XBrushes.Black, new XRect(marginLeft + 462, dist_Y, 50, el_height), format);
                                    tf.DrawString($"{na}", fontParagraph2, XBrushes.White, new XRect(marginLeft + 488, dist_Y, 80, el_height + 10), format);

                                    // Dibujar las líneas que delimitan las columnas
                                    gfx.DrawLine(line, marginLeft, dist_Y - 15, marginLeft, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 18, dist_Y - 15, marginLeft + 18, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 167, dist_Y - 15, marginLeft + 167, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 203, dist_Y - 15, marginLeft + 203, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 248, dist_Y - 15, marginLeft + 248, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 293, dist_Y - 15, marginLeft + 293, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 337, dist_Y - 15, marginLeft + 337, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 390, dist_Y - 15, marginLeft + 390, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 447, dist_Y - 15, marginLeft + 447, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 486, dist_Y - 15, marginLeft + 486, dist_Y + el_height - 15);
                                    gfx.DrawLine(line, marginLeft + 565, marginTop, marginLeft + 565, marginTop + 52);
                                    gfx.DrawLine(line, marginLeft + 565, dist_Y - 15, marginLeft + 565, dist_Y + el_height - 15);
                                    break;
                            }

                            // Agregar a la distancia en Y y el contador
                            dist_Y += 20;
                            i++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen datos para generar un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Dibujar la última línea para cerrar la tabla
                gfx.DrawLine(line, marginLeft, dist_Y - 5, marginRight, dist_Y - 5);

                // Obtener la dirección de Documentos de la máquina
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Especificar la dirección y el nombre del archivo
                string filename = $"{dir}\\EvalSisAT_{eval}_{sPeriodo}_{sCiclo}.pdf";
                
                // Guardar el documento
                document.Save(filename);

                // Enviar un mensaje de confirmación con la dirección del documento
                MessageBox.Show($"Documento guardado en: {dir}\\EvalSisAT_{eval}_{sPeriodo}_{sCiclo}.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
