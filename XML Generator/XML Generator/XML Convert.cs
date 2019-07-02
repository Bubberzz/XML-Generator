using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XML_Generator
{
    internal class XmlConvert : SqlConnection
    {
        private static readonly XmlGeneratorForm Form1 = Application.OpenForms.OfType<XmlGeneratorForm>().FirstOrDefault();
        public DataTable SqlData;
        public DataTable LocalData;

        // Returns data from SQL Connection to Form1.Data
        public DataTable GetData()
        {
            SqlData = LoadDataFromStoredProcedure();
            Form1.Invoke(new MethodInvoker(delegate () { Form1.Data = SqlData; }));
            return SqlData;
        }

        // Builds the XML file using LocalData DataTable - which contains data returned from SQL database
        public void ToXmlItl()
        {
            try
            {
                Form1.Invoke(new MethodInvoker(delegate () { LocalData = Form1.Data; }));
                string filename;
                var saveXml = new SaveFileDialog
                {
                    Filter = "XML files|*.xml",
                    FileName = "XMLData.xml"
                };

                if (saveXml.ShowDialog() == DialogResult.OK)
                {
                    filename = saveXml.FileName;
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SavedFilename = Path.GetFileName(filename); }));
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SavedFilePath = Path.GetFullPath(filename); }));
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SaveFileDialogResult = " saved!"; }));
                }
                else
                {
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SaveFileDialogResult = ""; }));
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SavedFilename = ""; }));
                    return;
                }

                using (var sw = new StreamWriter(filename))
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
                    sb.AppendFormat(@"<dcsextractdata xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""../lib/extractitl.xsd"" >");
                    sb.AppendFormat("<dataheaders>");
                    foreach (DataRow row in LocalData.Rows)
                    {
                        sb.AppendFormat("<dataheader>");
                        for (var i = 0; i < LocalData.Columns.Count; i++)
                        {
                            sb.AppendFormat("<{0}>{1}</{0}>", LocalData.Columns[i].ColumnName.ToLower(), row[i]);
                        }
                        sb.AppendFormat("</dataheader>");
                    }
                    sb.AppendFormat("</dataheaders>");
                    sb.AppendFormat("</dcsextractdata>");
                    sw.Write(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting ITL XML file");
                MessageBox.Show(ex.Message, "Export to XML error");
            }
        }

        // Builds the XML file using LocalData DataTable - which contains data returned from SQL database
        public void ToXmlPadex()
        {
            try
            {
                Form1.Invoke(new MethodInvoker(delegate () { LocalData = Form1.Data; }));
                string filename;
                var saveXml = new SaveFileDialog
                {
                    Filter = "XML files|*.xml",
                    FileName = "XMLData.xml"
                };

                if (saveXml.ShowDialog() == DialogResult.OK)
                {
                    filename = saveXml.FileName;
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SavedFilename = Path.GetFileName(filename); }));
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SavedFilePath = Path.GetFullPath(filename); }));
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SaveFileDialogResult = " saved!"; }));
                }
                else
                {
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SaveFileDialogResult = ""; }));
                    Form1.Invoke(new MethodInvoker(delegate () { Form1.SavedFilename = ""; }));
                    return;
                }

                using (var sw = new StreamWriter(filename))
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
                    sb.AppendFormat(@"<dcsextractdata xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""../lib/extractpad.xsd"" >");
                    sb.AppendFormat("<dataheaders>");
                    sb.AppendFormat("<dataheader>");
                    int i;
                    foreach (DataRow row in LocalData.Rows)
                    {
                        for (i = 0; i < 14; i++)
                        {
                            sb.AppendFormat("<{0}>{1}</{0}>", LocalData.Columns[i].ColumnName.ToLower(), row[i]);
                        }
                        sb.AppendFormat("<datalines>");
                        break;
                    }
                    foreach (DataRow row in LocalData.Rows)
                    {
                        sb.AppendFormat("<dataline>");
                        for (i = 14; i < LocalData.Columns.Count; i++)
                        {
                            sb.AppendFormat("<{0}>{1}</{0}>", LocalData.Columns[i].ColumnName.ToLower(), row[i]);
                        }
                        sb.AppendFormat("</dataline>");
                    }
                    sb.AppendFormat("</datalines>");
                    sb.AppendFormat("</dataheader>");
                    sb.AppendFormat("</dataheaders>");
                    sb.AppendFormat("</dcsextractdata>");
                    sw.Write(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting PADEX XML file");
                MessageBox.Show(ex.Message, "Export to XML error");
            }
        }
    }
}