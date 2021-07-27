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
    public partial class Report_FT_A4 : Telerik.Reporting.Report
    {
        public Report_FT_A4(DataTable dt,string PathLogo)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

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

            /**/
            //this.textBox29.Style.BackgroundColor = Color.Transparent;
            //this.textBox30.Style.BackgroundColor = Color.Transparent;
            //this.textBox32.Style.BackgroundColor = Color.Transparent;
            //this.textBox31.Style.BackgroundColor = Color.Transparent;
            //this.textBox36.Style.BackgroundColor = Color.Transparent;
            //this.textBox15.Style.BackgroundColor = Color.Transparent;
            //this.textBox18.Style.BackgroundColor = Color.Transparent;
            //this.textBox21.Style.BackgroundColor = Color.Transparent;
            ///**/
            this.pictureBox1.Value = Image.FromFile(PathLogo);
           // this.panel1.Style.BorderStyle.Default = BorderType.Outset;
            this.DataSource = dt;
            //this.table1.DataSource = dt;

           
        }


    }
}