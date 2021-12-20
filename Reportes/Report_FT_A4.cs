using System;
using System.Data;
using System.Drawing;
using System.IO;
using Telerik.Reporting.Drawing;

namespace Reportes
{
    /// <summary>
    /// Summary description for Report_GR_A4.
    /// </summary>
    public partial class Report_FT_A4 : Telerik.Reporting.Report
    {
        public Report_FT_A4(DataTable dt,string PathLogo)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //if (File.Exists("TexAdi_FT.txt"))
            //{

            //    this.textBoxTexAdi.Value = File.ReadAllText("TexAdi_FT.txt");
            //}
            //else
            //{
            //    try
            //    {
            //        using (StreamWriter sw = File.CreateText("TexAdi_FT.txt"))
            //        {
            //            sw.WriteLine("--");
            //        }

            //    }
            //    catch (System.Exception)
            //    {

            //    }
            //    this.textBoxTexAdi.Value = "-";
            DateTime f1 = DateTime.Parse(dt.Rows[0].ItemArray[7].ToString());
            DateTime f2 = DateTime.Parse(dt.Rows[0].ItemArray[8].ToString());

            if (f2 > f1)
            {
                textBoxForPag.Value = "CREDITO";
                textBoxCuota.Value = "001";
                textBoxImpCuo.Value = float.Parse(dt.Rows[0].ItemArray[13].ToString()).ToString("N2");
                textBoxFecCuo.Value = f2.ToString("dd/MM/yyyy");
            }
            else
            {
                textBoxForPag.Value = "CONTADO";
                textBox53.Style.Visible = false;
                textBox52.Style.Visible = false;
                textBox10.Style.Visible = false;
                textBoxCuota.Style.Visible = false;
                textBoxImpCuo.Style.Visible = false;
                textBoxFecCuo.Style.Visible = false;
            }


            this.pictureBox1.Value = Image.FromFile(PathLogo);
           // this.panel1.Style.BorderStyle.Default = BorderType.Outset;
            this.DataSource = dt;
            //this.table1.DataSource = dt;
        }


    }
}