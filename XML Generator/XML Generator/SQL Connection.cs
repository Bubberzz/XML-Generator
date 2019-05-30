using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace XML_Generator
{
    internal class SqlConnection
    {
        public static string ConnectionString { get; set; }
        public static bool LabelText { get; set; }
        public static string Mda { get; set; }
        public static string StoredProcedure { get; set; }
        protected System.Data.SqlClient.SqlConnection Connection;
        protected SqlCommand Command;
        protected SqlDataReader DataReader;

        // Creates a connection to database and executes stored procedure (selected via dropdown menu) with mda (user input number) parameter
        protected DataTable LoadDataFromStoredProcedure()
        {
            DataTable data = null;
            try
            {
                using (Connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    Connection.Open();
                    using (Command = Connection.CreateCommand())
                    {
                        Command = new SqlCommand(StoredProcedure, Connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        Command.Parameters.Add(new SqlParameter("@mda", Mda));
                        Command.CommandTimeout = 900;
                        DataReader = Command.ExecuteReader();
                        data = new DataTable();

                        if (DataReader.HasRows)
                        {
                            data.Load(DataReader);
                            Console.WriteLine("has rows");
                            LabelText = true;
                        }
                        else
                        {
                            Console.WriteLine("no rows");
                            LabelText = false;
                        }
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not load data in SQL Connection");
                MessageBox.Show(ex.Message, "Could not load data");
                return data;
            }
        }
    }
}
