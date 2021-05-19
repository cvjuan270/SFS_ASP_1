using System.Data;
using System.Drawing;
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

            this.pictureBox1.Value = Image.FromFile(PathLogo);
            this.panel1.Style.BorderStyle.Default = BorderType.Outset;
            this.DataSource = dt;
            //this.table1.DataSource = dt;
        }


    }
}