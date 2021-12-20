using System.Data;
using System.Drawing;
using System.IO;
using Telerik.Reporting.Drawing;

namespace Reportes
{
    /// <summary>
    /// Summary description for Report_GR_A4.
    /// </summary>
    public partial class Report_GR_A4 : Telerik.Reporting.Report
    {
        public Report_GR_A4(DataTable dt,string PathLogo)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            if (File.Exists("TexAdi_GR.txt"))
            {

                this.textBoxTexAdi.Value= File.ReadAllText("TexAdi_GR.txt");
            }
            else
            {
                try
                {
                    using (StreamWriter sw =  File.CreateText("TexAdi_GR.txt"))
                    {
                        sw.WriteLine("--");
                    }

                }
                catch (System.Exception)
                {

                }
                this.textBoxTexAdi.Value = "-";
            }

            this.pictureBox1.Value = Image.FromFile(PathLogo);
            
            this.DataSource = dt;
            //this.table1.DataSource = dt;
        }


    }
}