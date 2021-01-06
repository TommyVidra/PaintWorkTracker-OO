using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
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
            using(var context = new WorkContext())
            {
                var Workers = (from s in context.Workers orderby s.name select s).ToList<Worker>();
                var Resource = (from s in context.Resources orderby s.name select s).ToList<Resource>();
                var Stocks = (from s in context.Stocks orderby s.resource select s).ToList<Stock>();
                var Works = (from s in context.Works orderby s.Id select s).ToList<Work>();
                var Positions = (from s in context.Positions orderby s.position select s).ToList<Position>();

                StringBuilder sb = new StringBuilder();
                sb.Append("Id,Name,Last Name,Position");
                sb.Append("\r\n");

                foreach (var Worker in Workers)
                {
                    var Position = context.Positions
                                    .Where(c => c.Id == Worker.position)
                                    .FirstOrDefault();

                    Console.WriteLine("ID: {0}, Name: {1}, Position: {2}", Worker.Id, Worker.name, Position.position);
                    sb.Append(Worker.Id + "," + Worker.name + "," + Worker.lastName + "," + Position.position);
                    sb.Append("\r\n");

                }

                File.WriteAllText("G:\\Projects\\Fax\\OO\\Paint Work Tracker\\PaintWorkTracker\\StariApp\\WorkerTest.csv", sb.ToString(), Encoding.UTF8); 
                foreach (var R in Resource)
                    Console.WriteLine("ID: {0}, Name: {1}", R.Id, R.name);
                foreach (var P in Positions)
                    Console.WriteLine("ID: {0}, Name: {1}", P.Id, P.position);
                foreach (var S in Stocks)
                    Console.WriteLine("ID: {0}, Amount: {1}, Date: {2}", S.Id, S.amount, S.date);
                foreach (var W in Works)
                    Console.WriteLine("ID: {0}, Duration: {1}, Date: {2}", W.Id, W.duration, W.date);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form1());
        }
    }
}

