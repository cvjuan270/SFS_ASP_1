using System.Data;
using System.Drawing;
using System.IO;
using Telerik.Reporting.Drawing;

namespace Reportes
{
    /// <summary>
    /// Summary description for Report_GR_A4.
    /// </summary>
    public partial class Report_NC_A4 : Telerik.Reporting.Report
    {
        public Report_NC_A4(DataTable dt,string PathLogo)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            if (File.Exists("TexAdi_FT.txt"))
            {

                this.textBoxTexAdi.Value = File.ReadAllText("TexAdi_FT.txt");
            }
            else
            {
                try
                {
                    using (StreamWriter sw = File.CreateText("TexAdi_FT.txt"))
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
            this.panel1.Style.BorderStyle.Default = BorderType.Outset;
            this.DataSource = dt;
            //this.table1.DataSource = dt;
        }


    }
}