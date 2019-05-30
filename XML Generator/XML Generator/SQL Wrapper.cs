using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace XML_Generator
{
    public class SqlWrapper
    {
        private static readonly XmlGeneratorForm Form1 = Application.OpenForms.OfType<XmlGeneratorForm>().FirstOrDefault();
        private string _connectionString = null;
        private readonly XmlConvert _export = new XmlConvert();
        public DataTable Data = null;

        // Establishes connection with the database using appConfig file - passing Mda, StoredProcedure and ConnectionString to it
        // Loads returned data into Data DataTable
        public void LoadSql(string storedProcedure, string mda)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConfig"].ConnectionString;
            SqlConnection.Mda = mda;
            SqlConnection.StoredProcedure = storedProcedure;
            SqlConnection.ConnectionString = _connectionString;
            Data = _export.GetData();
            Form1.dataGridView1.Invoke(new MethodInvoker(delegate () { Form1.dataGridView1.DataSource = Data; }));
        }

        // Calls XMLConvert.ToXmlItl
        public void CreateXmlItl()
        {
            _export.ToXmlItl();
        }

        // Calls XMLConvert.ToXmlPadex
        public void CreateXmlPadex()
        {
            _export.ToXmlPadex();
        }
    }
}
