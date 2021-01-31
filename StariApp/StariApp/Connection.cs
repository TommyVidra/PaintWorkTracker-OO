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
            public double Trajanje { get; set; }
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
            public string Napomena { get; set; }
        }

        private static WorkContext context = new WorkContext();

        public static void DissposeContext() { context.Dispose(); }

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
                        Napomena = note.note
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
                        Trajanje = work.duration
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

        public static List<Position> ListPositions() 
        {
            List<Position> ReturnList = new List<Position>();
            (from s in context.Positions orderby s.Id select s).ToList<Position>().ForEach((p) =>
            {
                ReturnList.Add(new Position { Id = p.Id, position = p.position});
            });

            return ReturnList;
        }

        public static List<Resource> ListResources() 
        {
            List<Resource> ReturnList = new List<Resource>();
            (from s in context.Resources orderby s.Id select s).ToList<Resource>().ForEach((r) =>
            {
                ReturnList.Add( new Resource { Id = r.Id, name = r.name, mass = r.mass, metric = r.metric, price = r.price});
            });

            return ReturnList;
        }

        public static void ModifyWorker(List<WorkerView> ListData)
        {
            foreach(var View in ListData)
            {
                Worker Temp = new Worker();
                Temp.name = View.Ime;
                Temp.lastName = View.Prezime;

                if(context.Workers.Any(w => w.Id == View.Id))
                {
                    var Worker = context.Workers.SingleOrDefault(w => w.Id == View.Id);

                    if (context.Positions.Any(p => p.position == View.Pozicija))
                    {
                        Temp.position = context.Positions.FirstOrDefault(p => p.position == View.Pozicija).Id;

                        if (Temp.lastName.Equals(Worker.lastName) && Temp.name.Equals(Worker.name)
                            && Temp.Id == Worker.Id && Temp.position == Worker.position)

                            { Console.WriteLine("Nema promjene na zaposleniku"); }

                        else
                        {
                            Worker.name = Temp.name;
                            Worker.lastName = Temp.lastName;
                            Worker.position = Temp.position;
                            context.SaveChanges();
                        }
                    }

                    else
                    {
                        Console.WriteLine("N#ma pozicije u bazi");
                        Position NewPosition = new Position
                        {
                            Id = 0,
                            position = View.Pozicija
                        };

                        AddPosition(NewPosition);

                        Worker.name = Temp.name;
                        Worker.lastName = Temp.lastName;
                        Worker.position = NewPosition.Id;
                        context.SaveChanges();
                    }
                }
            }
        }

        public static void AddWorker(WorkerView worker)
        {
            worker.Id = context.Workers.Max(w => w.Id) + 1;
            int idPosition;

            if(context.Positions.Any(p => p.position == worker.Pozicija))
            {
                idPosition = context.Positions.FirstOrDefault(p => p.position == worker.Pozicija).Id;
            }
            else
            {
                Console.WriteLine("Nema pozicije u bazi");
                idPosition = context.Positions.Max(p => p.Id) + 1;

                Position NewPosition = new Position
                {
                    Id = idPosition,
                    position = worker.Pozicija
                };

                AddPosition(NewPosition);
            }

            Worker NewWorker = new Worker
            {
                Id = worker.Id,
                name = worker.Ime,
                lastName = worker.Prezime,
                position = idPosition
            };

            context.Workers.Add(NewWorker);
            context.SaveChanges();

        }

        public static void RemoveWorker(int Id)
        {
            if(context.Workers.Any(w => w.Id == Id))
            {
                if(context.Notes.Any(n => n.worker == Id))
                {
                    (from s in context.Notes orderby s.Id select s).ToList<Note>().ForEach((n) =>
                    {
                        if (n.worker == Id)
                            context.Notes.Remove(n);
                    });
                }

                if (context.Works.Any(w => w.worker == Id))
                {
                    (from s in context.Works orderby s.Id select s).ToList<Work>().ForEach((w) =>
                    {
                        if (w.worker == Id)
                            context.Works.Remove(w);
                    });
                }
                var Worker = context.Workers.FirstOrDefault(w => w.Id == Id);
                context.Workers.Remove(Worker);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Zaposlenik ne postoji");
            
        }

        public static void AddResource(Resource NewResourse)
        {
            if(context.Resources.Any(r => r.name == NewResourse.name))
                Console.WriteLine("Resurs već postoji");
            else
            {
                NewResourse.Id = context.Resources.Max(r => r.Id) + 1;
                context.Resources.Add(NewResourse);
                context.SaveChanges();
            }
        }

        public static void ModifyResource(List<Resource> Resources)
        {
            foreach (var TempResource in Resources)
            {
                if (context.Resources.Any(r => r.Id == TempResource.Id))
                {
                    var Resource = context.Resources.SingleOrDefault(r => r.Id == TempResource.Id);
                    Console.WriteLine(Resource.ToString());
                    Console.WriteLine(TempResource.ToString());

                    if(context.Resources.Count(r => r.name == TempResource.name && r.mass == TempResource.mass && r.metric == TempResource.metric && r.price == TempResource.price) >= 1)
                        Console.WriteLine("Resurs već postoji");

                    else
                    {
                        Resource.mass = TempResource.mass;
                        Resource.metric = TempResource.metric;
                        Resource.name = TempResource.name;
                        Resource.price = TempResource.price;
                        context.SaveChanges();
                    }
                }
            }
        }

        public static void RemoveResource(int Id)
        {

            if (context.Resources.Any(r => r.Id == Id))
            {
                if(context.Stocks.Any(s => s.resource == Id))
                {
                    (from s in context.Stocks orderby s.Id select s).ToList<Stock>().ForEach((s) =>
                    {
                        if (s.resource == Id)
                            context.Stocks.Remove(s);
                    });
                }

                var Resource = context.Resources.FirstOrDefault(r => r.Id == Id);
                context.Resources.Remove(Resource);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Resurs ne postoji");
        }

        public static void AddPosition(Position NewPosition)
        {
            if (context.Positions.Any(p => p.position == NewPosition.position))
                Console.WriteLine("Pozicija već postoji");
            else
            {
                Console.WriteLine("Nadodaje se nova Pozicija");
                NewPosition.Id = context.Positions.Max(p => p.Id) + 1;
                context.Positions.Add(NewPosition);
                context.SaveChanges();
            }
        }

        public static void ModifyPosition(List<Position> Positions)
        {
            foreach (var TempPosition in Positions)
            {
                if (context.Positions.Any(p => p.Id == TempPosition.Id))
                {
                    var Positon = context.Positions.SingleOrDefault(p => p.Id == TempPosition.Id);

                    if (context.Positions.Count(p => p.position == TempPosition.position) >= 1)
                        Console.WriteLine("Pozicija već postoji");

                    else
                    {
                        Positon.position = TempPosition.position;
                        context.SaveChanges();
                    }
                }
            }
        }

        public static void RemovePosition(int Id)
        {

            if(Id == 0)
            {
                Console.WriteLine("Ova pozicija se ne može brisat");
                return;
            }

            if (context.Positions.Any(p => p.Id == Id))
            {
                if(context.Workers.Any(w => w.position == Id))
                {
                    (from s in context.Workers orderby s.Id select s).ToList<Worker>().ForEach((w) =>
                    {
                        w.position = 0;
                    });
                }
                var Position = context.Positions.FirstOrDefault(p => p.Id == Id);
                context.Positions.Remove(Position);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Pozicija ne postoji");
        }

        public static void AddNote(NotesView NotesView)
        {
            NotesView.Id = context.Notes.Max(w => w.Id) + 1;
            int idWorker;

            if (context.Workers.Any(w => w.name == NotesView.Ime && w.lastName == NotesView.Prezime))
                idWorker = context.Workers.FirstOrDefault(w => w.name == NotesView.Ime && w.lastName == NotesView.Prezime).Id;

            else
            {
                Console.WriteLine("Nema navedenog zaposlenika u bazi");
                return;
            }

            Note NewNote = new Note
            {
                Id = NotesView.Id,
                date = NotesView.Datum,
                worker = idWorker,
                note = NotesView.Napomena
            };

            context.Notes.Add(NewNote);
            context.SaveChanges();

        }

        public static void ModifyNote(List<NotesView> Notes)
        {
            foreach (var TempNoteView in Notes)
            {
                if (context.Notes.Any(n => n.Id == TempNoteView.Id))
                {
                    var Note = context.Notes.SingleOrDefault(n => n.Id == TempNoteView.Id);

                    if (context.Workers.Any(w => w.name == TempNoteView.Ime && w.lastName == TempNoteView.Prezime))
                    {
                        int idWorker = context.Workers.FirstOrDefault(w => w.name == TempNoteView.Ime && w.lastName == TempNoteView.Prezime).Id;

                        Note.date = TempNoteView.Datum;
                        Note.note = TempNoteView.Napomena;
                        Note.worker = idWorker;
                        context.SaveChanges();
                    }
                    else
                        Console.WriteLine("Ne postoji naveden zaposlenik");
                }
            }
        }

        public static void RemoveNote(int Id)
        {

            if (context.Notes.Any(n => n.Id == Id))
            {
                var Note = context.Notes.FirstOrDefault(n => n.Id == Id);
                context.Notes.Remove(Note);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Napomena ne postoji");
        }

        public static void RemoveWork(int Id)
        {

            if (context.Works.Any(w => w.Id == Id))
            {
                var Work = context.Works.FirstOrDefault(w => w.Id == Id);
                context.Works.Remove(Work);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Posao ne postoji");
        }

        public static void ModifyWork(List<PeriodWorkView> Work)
        {
            foreach (var TempWorkView in Work)
            {
                if (context.Works.Any(w => w.Id == TempWorkView.Id))
                {
                    var CurrWork = context.Works.SingleOrDefault(w => w.Id == TempWorkView.Id);

                    if (context.Workers.Any(w => w.name == TempWorkView.Ime && w.lastName == TempWorkView.Prezime))
                    {
                        int idWorker = context.Workers.FirstOrDefault(w => w.name == TempWorkView.Ime && w.lastName == TempWorkView.Prezime).Id;

                        CurrWork.date = TempWorkView.Datum;
                        CurrWork.duration = TempWorkView.Trajanje;
                        CurrWork.worker = idWorker;
                        context.SaveChanges();
                    }
                    else
                        Console.WriteLine("Ne postoji naveden zaposlenik");
                }
            }
        }

        public static void AddWork(PeriodWorkView WorkView)
        {
            WorkView.Id = context.Works.Max(w => w.Id) + 1;
            int idWorker;

            if (context.Workers.Any(w => w.name == WorkView.Ime && w.lastName == WorkView.Prezime))
                idWorker = context.Workers.FirstOrDefault(w => w.name == WorkView.Ime && w.lastName == WorkView.Prezime).Id;

            else
            {
                Console.WriteLine("Nema navedenog zaposlenika u bazi");
                return;
            }

            Work NewWork = new Work
            {
                Id = WorkView.Id,
                date = WorkView.Datum,
                worker = idWorker,
                duration = WorkView.Trajanje
            };

            context.Works.Add(NewWork);
            context.SaveChanges();

        }

        public static void RemoveStock(int Id)
        {

            if (context.Stocks.Any(s => s.Id == Id))
            {
                var Stock = context.Stocks.FirstOrDefault(s => s.Id == Id);
                context.Stocks.Remove(Stock);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Zapis o resursu ne postoji");
        }

        public static void ModifyStock(List<PeriodResourceView> Stock)
        {
            foreach (var TempStockView in Stock)
            {
                if (context.Stocks.Any(s => s.Id == TempStockView.Id))
                {
                    var CurrStock = context.Stocks.SingleOrDefault(s => s.Id == TempStockView.Id);

                    if (context.Resources.Any(r => r.name == TempStockView.Resurs))
                    {
                        int idResource = context.Resources.FirstOrDefault(r => r.name == TempStockView.Resurs).Id;

                        CurrStock.date = TempStockView.Datum;
                        CurrStock.amount = TempStockView.Količina;
                        CurrStock.resource = idResource;
                        context.SaveChanges();
                    }
                    else
                        Console.WriteLine("Ne postoji naveden resurs");
                }
            }
        }

        public static void AddStock(PeriodResourceView StockView)
        {
            StockView.Id = context.Stocks.Max(w => w.Id) + 1;
            int idResource;

            if (context.Resources.Any(r => r.name == StockView.Resurs))
                idResource = context.Resources.FirstOrDefault(r => r.name == StockView.Resurs).Id;

            else
            {
                Console.WriteLine("Nema navedenog resursa u bazi");
                return;
            }

            Stock NewStock = new Stock
            {
                Id = StockView.Id,
                date = StockView.Datum,
                resource = idResource,
                amount = StockView.Količina
            };

            context.Stocks.Add(NewStock);
            context.SaveChanges();

        }

    }
}
