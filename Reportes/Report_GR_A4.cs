using Newtonsoft.Json;
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

            Datos datos = new Datos();
            string directorio = @"D:\DatosReportes\";
            string path = directorio + dt.Rows[0].ItemArray[0].ToString() + "Datos.json";

            if (File.Exists(path))
            {
                datos = JsonConvert.DeserializeObject<Datos>(File.ReadAllText(path));
            }
            else
            {
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                try
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {

                        string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                        sw.Write(json);
                        sw.Close();
                    }

                }
                catch (System.Exception ex)
                {

                }
            }

            this.TextBoxContacto.Value = datos.Contacto;
            this.textBoxCelular.Value = datos.Celular;
            this.textBoxEmail.Value = datos.Email;
            this.textBoxFacebook.Value = datos.Facebook;
            this.textBoxTextoLibre.Value = datos.TextoLibre;
            this.textBoxCta.Value = datos.Cta;

            this.pictureBox1.Value = Image.FromFile(PathLogo);
            
            this.DataSource = dt;
            //this.table1.DataSource = dt;
        }


    }
}