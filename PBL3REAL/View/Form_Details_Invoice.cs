﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.IO;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
namespace PBL3REAL.View
{
    public partial class Form_Details_Invoice : Form
    {
        public Form_Details_Invoice()
        {
            InitializeComponent();
        }
        public void ExportToPDF(string FileName)
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.Filter = "PDF (*.pdf)|*.pdf";
            //    sfd.FileName = "Output.pdf";
            //    bool fileError = false;
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        if (File.Exists(sfd.FileName))
            //        {
            //            try
            //            {
            //                File.Delete(sfd.FileName);
            //            }
            //            catch (IOException ex)
            //            {
            //                fileError = true;
            //                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
            //            }
            //        }
            //        if (!fileError)
            //        {
            //            try
            //            {
            //                PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
            //                pdfTable.DefaultCell.Padding = 3;
            //                pdfTable.WidthPercentage = 100;
            //                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            //                foreach (DataGridViewColumn column in dataGridView1.Columns)
            //                {
            //                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
            //                    pdfTable.AddCell(cell);
            //                }

            //                foreach (DataGridViewRow row in dataGridView1.Rows)
            //                {
            //                    foreach (DataGridViewCell cell in row.Cells)
            //                    {
            //                        pdfTable.AddCell(cell.Value.ToString());
            //                    }
            //                }

            //                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
            //                {
            //                    Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
            //                    PdfWriter.GetInstance(pdfDoc, stream);
            //                    pdfDoc.Open();
            //                    pdfDoc.Add(pdfTable);
            //                    pdfDoc.Close();
            //                    stream.Close();
            //                }

            //                MessageBox.Show("Data Exported Successfully !!!", "Info");
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Error :" + ex.Message);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No Record To Export !!!", "Info");
            //}
            PdfDocument pdf = new PdfDocument();
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            graph.DrawString("This is my first PDF document", font, XBrushes.Black,new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            pdf.Save("firstpage.pdf");
        }
    }
}
