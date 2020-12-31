using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StariApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            //Console.WriteLine(wanted_path);

            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + wanted_path + "\\StariAppDB.mdf;Integrated Security=True");
            //SqlCommand command = new SqlCommand();
            //SqlDataReader reader = null;
            //try
            //{
            //    // 2. Open the connection
            //    connection.Open();

            //    // 3. Pass the connection to a command object
            //    SqlCommand cmd = new SqlCommand("select * from Resource", connection);

            //    //
            //    // 4. Use the connection
            //    //

            //    // get query results
            //    reader = cmd.ExecuteReader();

            //    // print the CustomerID of each record
            //    while (reader.Read())
            //    {
            //        Console.WriteLine(reader[1]);
            //    }
            //}
            //finally
            //{
            //    // close the reader
            //    if (reader != null)
            //    {
            //        reader.Close();
            //    }

            //    // 5. Close the connection
            //    if (connection != null)
            //    {
            //        connection.Close();
            //    }
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form1());
        }
    }
}
