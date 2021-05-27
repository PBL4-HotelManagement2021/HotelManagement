﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PBL3REAL.Extention;
using PBL3REAL.BLL;
using PBL3REAL.DAL;
using PBL3REAL.ViewModel;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.SqlClient;
namespace PBL3REAL.View
{
    public partial class Form_View_Statistic_Analyze : Form
    {
        QLInvoiceBLL invoiceBLL;
        List<Statistic_InvoiceVM> listVM;
        double rSquared, intercept, slope;
        double[] xValues;
        double[] yValues;
        double predictedValue;
        public Form_View_Statistic_Analyze(/*DateTime from, DateTime to*/)
        {
            InitializeComponent();
            invoiceBLL = new QLInvoiceBLL();
            listVM = invoiceBLL.findForStatistic(Convert.ToDateTime("2021-04-28"), Convert.ToDateTime("2021-05-10"));
            FillChart();
            this.chart1.SaveImage(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\chart.png", ChartImageFormat.Png);
            predictedValue = (slope * 2017) + intercept;
           /* LinearRegression(xValues, yValues, out rSquared, out intercept, out slope);*/
        }
        public void statistics(string query, int type)
        {
            dgv_Booking.DataSource = listVM;
            chart1.DataSource = listVM;
            chart1.Series.Add("Income");
            chart1.Series["Income"].XValueMember = "Date";
            chart1.Series["Income"].YValueMembers = "TotalByDate";
            chart1.Visible = true;
            //int len = dt.Rows.Count;
            //if (len == 0)
            //{
            //    MessageBox.Show("Không có giao dịch trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK);
            //    return;
            //}
            //double[] ArrDb = new double[len];
            //int d;
            //if (type == 1)
            //{
            //    d = 1;
            //}
            //else
            //{
            //    d = -1;
            //}
            //for (int i = 0; i < len; i++)
            //{
            //    DataRow dr = dt.Rows[i];
            //    ArrDb[i] = Double.Parse(dr.ItemArray[0].ToString()) * d;
            //}
            //MaxHeap stc = new MaxHeap(ArrDb, len);
            //foreach (DataRow item in dt.Rows)
            //{
            //    if (Double.Parse(item.ItemArray[0].ToString()) == d * (stc.Maximum()))
            //    {
            //        Tbx1.Text = item.ItemArray[0].ToString();
            //        Tbx2.Text = item.ItemArray[1].ToString();
            //        Tbx3.Text = item.ItemArray[2].ToString();
            //    }
            //}
        }
        public void FillChart()
        {
            chart1.DataSource = listVM;
            chart1.Series.Add("Income");
            chart1.Series["Income"].XValueMember = "Date";
            chart1.Series["Income"].YValueMembers = "TotalByDate";
            //if (type == 1)
            //{
            //    C1.Series["Series1"].XValueMember = "Ngày";
            //    C1.Series["Series1"].YValueMembers = "Số tiền đã thu";
            //}
            //else
            //{
            //    C1.Series["Series1"].XValueMember = "Mục đích chi tiêu";
            //    C1.Series["Series1"].YValueMembers = "Số tiền đã chi";
            //}
            chart1.Series["Income"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }
        public class LinearRegression
        {
            public double[] xVals { get; private set; }
            public double[] yVals { get; private set; }
            public LinearRegression(double[] xValss, double[] yValss)
            {
                this.xVals = xValss;
                this.yVals = yValss;
            }
            public void PredictData()
            {
                if (this.xVals.Length != this.yVals.Length)
                {
                    throw new Exception("Input values should be with the same length.");
                }
                double sumOfX = 0;
                double sumOfY = 0;
                double sumOfXSq = 0;
                double sumOfYSq = 0;
                double sumCodeviates = 0;
                for (var i = 0; i < xVals.Length; i++)
                {
                    var x = xVals[i];
                    var y = yVals[i];
                    sumCodeviates += x * y;
                    sumOfX += x;
                    sumOfY += y;
                    sumOfXSq += x * x;
                    sumOfYSq += y * y;
                }

                var count = xVals.Length;
                var ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
                var ssY = sumOfYSq - ((sumOfY * sumOfY) / count);

                var rNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
                var rDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
                var sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

                var meanX = sumOfX / count;
                var meanY = sumOfY / count;
                var dblR = rNumerator / Math.Sqrt(rDenom);

              /*  rSquared = dblR * dblR;
                yIntercept = meanY - ((sCo / ssX) * meanX);
                slope = sCo / ssX;*/
            }
        }
        public class MaxHeap
        {
            public MaxHeap(double[] input, int length)
            {
                this.Length = length;
                this.Array = input;
                BuildMaxHeap();
            }
            public double[] Array { get; private set; }
            public int Length { get; private set; }
            private void BuildMaxHeap()
            {
                for (int i = this.Length / 2; i > 0; i--)
                {
                    MaxHeapify(i);
                }
                return;
            }
            public void MaxHeapify(int index)
            {
                var left = 2 * index;
                var right = 2 * index + 1;
                int max = index;
                if (left <= this.Length && this.Array[left - 1] > this.Array[index - 1])
                {
                    max = left;
                }
                if (right <= this.Length && this.Array[right - 1] > this.Array[max - 1])
                {
                    max = right;
                }
                if (max != index)
                {
                    double temp = this.Array[max - 1];
                    this.Array[max - 1] = this.Array[index - 1];
                    this.Array[index - 1] = temp;
                    MaxHeapify(max);
                }
                return;
            }
            public double Maximum()
            {
                return this.Array[0];
            }
            public string rs;
            public string pointtime;
            public int len;
        }

        private void Form_View_Statistic_Analyze_Load(object sender, EventArgs e)
        {

        }
    }
}
