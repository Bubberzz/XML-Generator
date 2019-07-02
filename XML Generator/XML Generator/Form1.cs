using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace XML_Generator
{
    public partial class XmlGeneratorForm : Form
    {
        public XmlGeneratorForm()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            pictureBox1.Visible = false;
            comboBox1.Items.Add(Dropdown.ITL);
            comboBox1.Items.Add(Dropdown.PADEX);
        }

        // These strings hold notification/feedback text for labelFeedback 
        public string SavedFilename;
        public string SavedFilePath;
        public string SaveFileDialogResult;
        public DataTable Data;

        // This method sets the font, size and colour of text displayed in labelFeedback
        private void LabelText(string text)
        {
            labelFeedback.Font = new Font("Arial", 9);
            labelFeedback.ForeColor = Color.Red;
            labelFeedback.Text = text;
        }

        // Load button - data validation only allows numbers and field cannot be empty. Starts new thread if checks have passed
        private void Load_Button_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxInput.Text, "[ ^ 0-9]"))
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    LabelText("Select ITL or PADEX");
                    return;
                }
                try
                {
                    // Calls LoadData method in new thread
                    var threadInput = new Thread(LoadData);
                    threadInput.Start();
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                }
            }
            else
            {
                LabelText("Type in 14 digit MDA number");
                return;
            }
        }

        // This method calls SQL Wrapper class - passing MDA number and stored procedure type 
        private void LoadData()
        {
            SetLoading(true);
            var sqlWrapper = new SqlWrapper();
            var text = "";
            this.Invoke(new MethodInvoker(delegate () { labelFeedback.Text = ""; }));
            this.Invoke(new MethodInvoker(delegate () { text = comboBox1.Text; }));

            switch (text)
            {
                case "ITL":
                    sqlWrapper.LoadSql("ITLStoredProcedure", TextBoxInput.Text);
                    break;
                case "PADEX":
                    sqlWrapper.LoadSql("PADEXStoredProcedure", TextBoxInput.Text);
                    break;
                default:
                    this.Invoke(new MethodInvoker(delegate () { labelFeedback.ForeColor = Color.Red; labelFeedback.Text = "Select ITL or PADEX"; }));
                    SetLoading(false);
                    return;
            }

            if (SqlConnection.LabelText == false)
            {
                labelFeedback.Invoke(new MethodInvoker(delegate () { LabelText("No rows returned"); }));
                SetLoading(false);
                return;
            }

            SetLoading(false);
            this.Invoke(new MethodInvoker(delegate () { labelFeedback.ForeColor = Color.Green; labelFeedback.Text = "Results returned!"; }));
        }

        // Create button - check if data has been loaded. Calls CreateFile method
        private void Create_button_Click(object sender, EventArgs e)
        {
            if (SqlConnection.LabelText == true)
            {
                try
                {
                    var threadInput2 = new Thread(CreateFile);
                    threadInput2.SetApartmentState(ApartmentState.STA);
                    threadInput2.Start();
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                }
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate () { labelFeedback.ForeColor = Color.Red; labelFeedback.Text = "Load data first"; }));
            }
        }

        // Depending on which drop down menu item is selected a SqlWrapper class is called to create the XML file
        private void CreateFile()
        {
            var sqlWrapper = new SqlWrapper();
            var text = "";
            this.Invoke(new MethodInvoker(delegate () { labelFeedback.Text = ""; }));
            this.Invoke(new MethodInvoker(delegate () { text = comboBox1.Text; }));
            SetLoading(true);

            if (SqlConnection.LabelText == true)
            {
                switch (text)
                {
                    case "ITL":
                        sqlWrapper.CreateXmlItl();
                        try
                        {
                            var text1 = File.ReadAllText(SavedFilePath);
                            text1 = text1.Replace("&", "&amp;");
                            File.WriteAllText(SavedFilePath, text1);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                        break;
                    case "PADEX":
                        {
                            sqlWrapper.CreateXmlPadex();

                            // Known issue - due to duplicate column names returned from stored procedure 1 is added at the end of
                            // the repeated columns. This code replaces those columns with normal names.
                            try
                            {
                                var text1 = File.ReadAllText(SavedFilePath);
                                text1 = text1.Replace("record_type1", "record_type");
                                text1 = text1.Replace("action1", "action");
                                text1 = text1.Replace("client_id1", "client_id");
                                text1 = text1.Replace("pre_advice_id1", "pre_advice_id");
                                text1 = text1.Replace("&", "&amp;");
                                File.WriteAllText(SavedFilePath, text1);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }

                            break;
                        }
                    default:
                        break;
                }
            }
            SetLoading(false);
            this.Invoke(new MethodInvoker(delegate () { labelFeedback.Text = SavedFilename + SaveFileDialogResult; }));
        }

        // General error handling method - displays message with error 
        private static void DisplayError(Exception ex)
        {
            MessageBox.Show("The below error occurred while processing the request: \n\r \n\r" + ex.Message);
        }

        // Displays loading icon whilst the database query is running - turned on/off with visible true/false parameters
        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    pictureBox1.Visible = true;
                    dataGridView1.Visible = false;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    pictureBox1.Visible = false;
                    dataGridView1.Visible = true;
                    this.Cursor = Cursors.Default;
                });
            }
        }
    }
}
