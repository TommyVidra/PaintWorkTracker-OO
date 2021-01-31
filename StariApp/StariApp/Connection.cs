using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StariApp
{
    class Connection
    {

        public class WorkerView
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Pozicija { get; set; }
        }

        public class PeriodWorkView
        {
            public int Id { get; set; }
            public DateTime Datum { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public double Duration { get; set; }
        }

        public class PeriodResourceView
        {
            public int Id { get; set; }
            public DateTime Datum { get; set; }
            public string Resurs { get; set; }
            public double Količina { get; set; }
            public double Cijena { get; set; }
        }

        public class NotesView
        {
            public int Id { get; set; }
            public DateTime Datum { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Note { get; set; }
        }

        private static WorkContext context = new WorkContext();

        public static void DissposeContext()
        {
            context.Dispose();
        }

        //public static string path = ConfigurationManager.ConnectionStrings["StariApp.Properties.Settings.StariAppDBConnectionString"].ConnectionString;

        public static List<NotesView> ListNotes(DateTime FirstDate, DateTime SecondDate)
        {
            var Data = context.Notes
                .Join(
                    context.Workers,
                    note => note.worker,
                    worker => worker.Id,
                    (note, worker) => new NotesView
                    {
                        Id = note.Id,
                        Datum = note.date,
                        Ime = worker.name,
                        Prezime = worker.lastName,
                        Note = note.note
                    })
                .Where(n => n.Datum <= SecondDate && n.Datum >= FirstDate).OrderBy(n => n.Datum).ToList();

            return Data;
        }

        public static List<PeriodResourceView> ListResourcePeriods(DateTime FirstDate, DateTime SecondDate)
        {
            var Data = context.Stocks
                .Join(
                    context.Resources,
                    stock => stock.resource,
                    resource => resource.Id,
                    (stock, resource) => new PeriodResourceView
                    {
                        Id = stock.Id,
                        Datum = stock.date,
                        Resurs = resource.name,
                        Količina = stock.amount,
                        Cijena = stock.amount * resource.price
                    })
                .Where(s => s.Datum <= SecondDate && s.Datum >= FirstDate).OrderBy(s => s.Datum).ToList();

            return Data;
        }

        public static List<PeriodWorkView> ListWorksPeriods(DateTime FirstDate, DateTime SecondDate)
        {
            var Data = context.Works
                .Join(
                    context.Workers,
                    work => work.worker,
                    worker => worker.Id,
                    (work, worker) => new PeriodWorkView
                    {
                        Id = work.Id,
                        Datum = work.date,
                        Ime = worker.name,
                        Prezime = worker.lastName,
                        Duration = work.duration
                    })
                .Where(w => w.Datum <= SecondDate && w.Datum >= FirstDate).OrderBy(w => w.Datum).ToList();

            return Data;
        }

        public static List<WorkerView> ListWorkers() 
        {
            var Data = context.Workers
            .Join(
                context.Positions,
                worker => worker.position,
                position => position.Id,
                (worker, position) => new WorkerView
                {
                    Id = worker.Id,
                    Ime = worker.name,
                    Prezime = worker.lastName,
                    Pozicija = position.position
                }).ToList();
           
            return Data;
        }

        public static List<Position> ListPositions() { return (from s in context.Positions orderby s.Id select s).ToList<Position>(); }

        public static List<Resource> ListResources() { return (from s in context.Resources orderby s.Id select s).ToList<Resource>(); }

        public static async void ModifyWorker(List<WorkerView> ListData)
        {
            foreach(var View in ListData)
            {
                if(context.Workers.Any(w => w.Id == View.Id))
                {
                    var Worker = context.Workers.SingleOrDefault(w => w.Id == View.Id);
                    Worker.name = View.Ime;
                    Worker.lastName = View.Prezime;

                    Console.WriteLine(Worker.name + " | " + Worker.lastName);
                    if (context.Positions.Any(p => p.position == View.Pozicija))
                    {
                        Worker.position = context.Positions.FirstOrDefault(p => p.position == View.Pozicija).Id; 
                    }

                    else
                    {
                        Console.WriteLine("N#ma pozicije u bazi");
                        int newId = context.Positions.Max(p => p.Id) + 1;

                        Position NewPosition = new Position
                        {
                            Id = newId,
                            position = View.Pozicija
                        };

                        Console.WriteLine(NewPosition.Id + " | " + NewPosition.position);
                        AddPosition(NewPosition);
                        Worker.position = NewPosition.Id;
                    }

                    Console.WriteLine(Worker);
                }
                context.SaveChanges();
            
            }
            
        }

        public static async void AddPosition(Position NewPosition)
        {
            Console.WriteLine("Nadodaje se nova Pozicija");
            context.Positions.Add(NewPosition);
            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>


        //public static void addWorker(WorkerView view)
        //{
        //    int count = workerCount(name, lastName);

        //    //if a worker doesnt exist
        //    if (count == 0)
        //    {
        //        int id = Count("Workers"); ++id;

        //        //SqlConnection connection2 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\StariAppDB.mdf;Integrated Security=True");
        //        SqlConnection connection2 = new SqlConnection(path);
        //        connection2.Open();
        //        SqlCommand insert = new SqlCommand("INSERT INTO Workers (Id, Name, LastName, Position)  VALUES(@id, @name, @lastName, @position)", connection2);

        //        List<SqlParameter> para1 = new List<SqlParameter>()
        //        {
        //            new SqlParameter("@id", SqlDbType.Int) {Value = id},
        //            new SqlParameter("@name", SqlDbType.VarChar) {Value = name},
        //            new SqlParameter("@lastName", SqlDbType.VarChar) {Value = lastName},
        //            new SqlParameter("@position", SqlDbType.Int) {Value = position},
        //        };

        //        insert.Parameters.AddRange(para1.ToArray());
        //        insert.ExecuteNonQuery();
        //        connection2.Close();
        //    }

        //}

        //public static void removeWorker(string name, string lastName)
        //{
        //    int count = workerCount(name, lastName);

        //    if (count != 0)
        //    {
        //        SqlConnection connection = new SqlConnection(path);
        //        connection.Open();

        //        SqlCommand delete = new SqlCommand("delete from Workers where lower(Name) = lower(@userName) and lower(LastName) = lower(@userLast)", connection);

        //        List<SqlParameter> para = new List<SqlParameter>()
        //        {
        //            new SqlParameter("@userName", SqlDbType.VarChar) {Value = name},
        //            new SqlParameter("@userLast", SqlDbType.VarChar) {Value = lastName},
        //        };

        //        delete.Parameters.AddRange(para.ToArray());
        //        delete.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //    else
        //    {
        //        Console.WriteLine("There is no worker in db with that name");
        //    }
        //}

        //private static int workerCount(string name, string lastName)
        //{

        //    SqlConnection connection = new SqlConnection(path);
        //    SqlCommand command = new SqlCommand("select Count(*) from Workers where lower(Name) = lower(@userName) and lower(LastName) = lower(@userLast)", connection);
        //    connection.Open();

        //    List<SqlParameter> para = new List<SqlParameter>()
        //    {
        //        new SqlParameter("@userName", SqlDbType.VarChar) {Value = name},
        //        new SqlParameter("@userLast", SqlDbType.VarChar) {Value = lastName},
        //    };

        //    command.Parameters.AddRange(para.ToArray());
        //    int count = (int)command.ExecuteScalar();
        //    connection.Close();
        //    return count;
        //}

        //public static void addResource(string name, float price, float mass, string metric)
        //{

        //    int count = resourceCount(name, price, metric);

        //    //if a worker doesnt exist
        //    if (count == 0)
        //    {
        //        int id = Count("Resource"); ++id;

        //        SqlConnection connection2 = new SqlConnection(path);
        //        connection2.Open();
        //        SqlCommand insert = new SqlCommand("INSERT INTO Resource (Id, Name, Price, Mass, Metric)  VALUES(@id, @name, @price, @mass, @metric)", connection2);

        //        List<SqlParameter> para1 = new List<SqlParameter>()
        //        {
        //            new SqlParameter("@id", SqlDbType.Int) {Value = id},
        //            new SqlParameter("@name", SqlDbType.VarChar) {Value = name},
        //            new SqlParameter("@price", SqlDbType.Float) {Value = price},
        //            new SqlParameter("@mass", SqlDbType.Float) {Value = mass},
        //            new SqlParameter("@metric", SqlDbType.VarChar) {Value = metric},
        //        };

        //        insert.Parameters.AddRange(para1.ToArray());
        //        insert.ExecuteNonQuery();
        //        connection2.Close();
        //    }

        //}

        //public static void removeResource(string name, float price, string metric)
        //{

        //    int count = resourceCount(name, price, metric);

        //    if (count != 0)
        //    {
        //        SqlConnection connection = new SqlConnection(path);
        //        connection.Open();

        //        SqlCommand delete = new SqlCommand("delete from Resource where lower(Name) = lower(@name) and Price = price and lower(Metric) = lower(@metric)", connection);

        //        List<SqlParameter> para = new List<SqlParameter>()
        //        {
        //            new SqlParameter("@name", SqlDbType.VarChar) {Value = name},
        //            new SqlParameter("@price", SqlDbType.Float) {Value = price},
        //            new SqlParameter("@metric", SqlDbType.VarChar) {Value = metric},
        //        };

        //        delete.Parameters.AddRange(para.ToArray());
        //        delete.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //    else
        //    {
        //        Console.WriteLine("There is no resource in db with that name");
        //    }
        //}

        //private static int resourceCount(string name, float price, string metric)
        //{

        //    SqlConnection connection = new SqlConnection(path);
        //    SqlCommand command = new SqlCommand("select Count(*) from Resource where lower(Name) = lower(@name) and Price = @price and lower(Metric) = lower(@metric) ", connection);
        //    connection.Open();

        //    List<SqlParameter> para = new List<SqlParameter>()
        //    {
        //        new SqlParameter("@name", SqlDbType.VarChar) {Value = name},
        //        new SqlParameter("@price", SqlDbType.Float) {Value = price},
        //        new SqlParameter("@metric", SqlDbType.VarChar) {Value = metric},
        //    };

        //    command.Parameters.AddRange(para.ToArray());
        //    int count = (int)command.ExecuteScalar();
        //    connection.Close();
        //    return count;
        //}

        //public static void addNote(string note, DateTime date, int workerId)
        //{

        //    int id = Count("Note"); ++id;

        //    SqlConnection connection2 = new SqlConnection(path);
        //    connection2.Open();

        //    SqlCommand insert = new SqlCommand("INSERT INTO Note (Date, Note, Worker, Id)  VALUES( @date, @note, @workerId, @id)", connection2);

        //    List<SqlParameter> para1 = new List<SqlParameter>()
        //    {
        //        new SqlParameter("@date", SqlDbType.Date) {Value = date},
        //        new SqlParameter("@note", SqlDbType.NVarChar) {Value = note},
        //        new SqlParameter("@workerId", SqlDbType.Int) {Value = workerId},
        //        new SqlParameter("@id", SqlDbType.Int) {Value = id},
        //    };

        //    insert.Parameters.AddRange(para1.ToArray());
        //    insert.ExecuteNonQuery();
        //    connection2.Close();
        //}

        ////private static int getWorkerId(string name, string lastName)
        ////{
        ////    SqlConnection connection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Projects\\StariApp\\StariApp\\StariApp\\StariAppDB.mdf;Integrated Security=True");
        ////    connection1.Open();
        ////    SqlCommand temp = new SqlCommand("select Id from Workers where lower(Name) = lower(@name) and lower(LastName) = lower(@lastName)", connection1);
        ////    List<SqlParameter> para = new List<SqlParameter>()
        ////        {
        ////            new SqlParameter("@name", SqlDbType.VarChar) {Value = name},
        ////            new SqlParameter("@lastName", SqlDbType.VarChar) {Value = lastName},
        ////        };
        ////    temp.Parameters.AddRange(para.ToArray());
        ////    int WorkerID = (int)temp.ExecuteScalar();
        ////    connection1.Close();

        ////    return WorkerID;
        ////}

        //private static int Count(string table)
        //{

        //    SqlConnection connection = new SqlConnection(path);
        //    SqlCommand command = new SqlCommand("select count(*) from " + table, connection);
        //    connection.Open();

        //    int count = (int)command.ExecuteScalar();
        //    if (count == 0)
        //    {
        //        connection.Close();
        //        return count;
        //    }
        //    else
        //    {
        //        int max;
        //        SqlCommand command2 = new SqlCommand("select max(Id) from " + table, connection);
        //        max = (int)command2.ExecuteScalar();
        //        return max;
        //    }


        //}



        //public static void removeById(int Id, string table)
        //{

        //    SqlConnection connection = new SqlConnection(path);
        //    connection.Open();

        //    SqlCommand delete = new SqlCommand("delete from " + table + "  where Id = @id", connection);

        //    List<SqlParameter> para = new List<SqlParameter>()
        //        {
        //            new SqlParameter("@id", SqlDbType.Int) {Value = Id},
        //        };

        //    delete.Parameters.AddRange(para.ToArray());
        //    delete.ExecuteNonQuery();
        //    connection.Close();

        //}

        //public static void removeByIdMultiple(string ids, string table)
        //{

        //    SqlConnection connection = new SqlConnection(path);
        //    connection.Open();

        //    foreach (string s in ids.Split())
        //    {
        //        if(s != "")
        //        {
        //            SqlCommand delete = new SqlCommand("delete from " + table + "  where Id = @id", connection);

        //            List<SqlParameter> para = new List<SqlParameter>()
        //            {
        //                new SqlParameter("@id", SqlDbType.Int) {Value = int.Parse(s)},
        //            };

        //            delete.Parameters.AddRange(para.ToArray());
        //            delete.ExecuteNonQuery();
        //        }

        //    }
        //    connection.Close();
        //}

        //public static void addStock(DateTime date, int resource, float amount)
        //{

        //    int id = Count("Stock"); ++id;

        //    SqlConnection connection1 = new SqlConnection(path);
        //    connection1.Open();

        //    //SqlCommand temp = new SqlCommand("select Id from Resource where lower(Name) = lower(@name)", connection1);
        //    //List<SqlParameter> para = new List<SqlParameter>()
        //    //    {
        //    //        new SqlParameter("@name", SqlDbType.VarChar) {Value = resource},
        //    //    };

        //    //temp.Parameters.AddRange(para.ToArray());
        //    //int resourceId = (int)temp.ExecuteScalar();

        //    SqlCommand insert = new SqlCommand("INSERT INTO Stock (Resource, Amount, Date, Id)  VALUES( @resource, @amount, @date, @id)", connection1);

        //    List<SqlParameter> para1 = new List<SqlParameter>()
        //    {
        //        new SqlParameter("@date", SqlDbType.Date) {Value = date.Date},
        //        new SqlParameter("@resource", SqlDbType.Int) {Value = resource},
        //        new SqlParameter("@amount", SqlDbType.Float) {Value = amount},
        //        new SqlParameter("@id", SqlDbType.Int) {Value = id},
        //    };

        //    insert.Parameters.AddRange(para1.ToArray());
        //    insert.ExecuteNonQuery();
        //    connection1.Close();

        //}

        //public static void addWork(DateTime date, string ids, float duration)
        //{


        //    SqlConnection connection2 = new SqlConnection(path);
        //    connection2.Open();

        //    foreach(string s in ids.Split())
        //    {
        //        int id = Count("Work"); ++id;
        //        SqlCommand insert = new SqlCommand("INSERT INTO Work (Id, Duration, Date, Worker)  VALUES(@id, @duration, @date, @workerId)", connection2);

        //        List<SqlParameter> para1 = new List<SqlParameter>()
        //        {
        //        new SqlParameter("@date", SqlDbType.Date) {Value = date.Date},
        //        new SqlParameter("@duration", SqlDbType.Float) {Value = duration},
        //        new SqlParameter("@workerId", SqlDbType.Int) {Value = int.Parse(s)},
        //        new SqlParameter("@id", SqlDbType.Int) {Value = id},
        //        };

        //        insert.Parameters.AddRange(para1.ToArray());
        //        insert.ExecuteNonQuery();

        //    }

        //    connection2.Close();

        //}
    }
}
