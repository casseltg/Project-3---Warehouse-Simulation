using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_3___Warehouse_Simulation
{
    internal class Warehouse
    {
        public List<Dock> Docks { get; private set; }

        public Queue<Truck> Entrance { get; private set; }

        private string Log { get; set; }

        public Warehouse()
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
        }

        public Warehouse(int numOfDocks)
        {
            Docks = new List<Dock>();
            for (int i = 0; i < numOfDocks; i++)
            {
                Dock dock = new Dock($"{i + 1}");
                Docks.Add(dock);
            }
            Entrance = new Queue<Truck>();
        }

        ///
        /// <summary>
        /// Runs warehouse simulation
        /// </summary>
        public void Run()
        {
            //A loaded truck arrives at the Warehouse with a random # of cargo crates in a random time interval between increments of 1 to 48.
            Report report = new Report(Docks.Count);
            Random randy = new Random();
            for (int timeIntervalsPassed = 1; timeIntervalsPassed <= 48; timeIntervalsPassed++)
            {
                int probabilityTruckArrives;
                if (timeIntervalsPassed <= 24)
                {
                    probabilityTruckArrives = randy.Next(1, timeIntervalsPassed + 1);
                }
                else
                {
                    probabilityTruckArrives = randy.Next(1, 50 - timeIntervalsPassed);
                }
                if (randy.Next(24) <= probabilityTruckArrives)
                {
                    Entrance.Enqueue(new Truck());
                }


                //Once a truck arrives, it is sent to the gate entrance.

                //Once at the gate entrance, a truck is added to a loading dock once every time increment.
                if (Entrance.Count > 0)
                {
                    int smallestQueueCount = Docks[0].line.Count;
                    int smallestQueueIndex = 0;
                    for (int i = 1; i < Docks.Count; i++)
                    {
                        if (Docks[i].line.Count < smallestQueueCount)
                        {
                            smallestQueueCount = Docks[i].line.Count;
                            smallestQueueIndex = i;
                        }
                    }

                    Docks[smallestQueueIndex].JoinLine(Entrance.Dequeue());

                    //Once at the loading dock, one of a truck’s crates is unloaded at every time increment.
                    string crateLog = string.Empty;
                    for (int i = 0; i < Docks.Count; i++)
                    {
                        if (Docks[i].line.Count > report.LongestLine)
                        {
                            report.LongestLine = Docks[i].line.Count;
                        }
                        if (Docks[i].truckToUnload != null && Docks[i].truckToUnload.Trailer.Count != 0)
                        {
                            crateLog += timeIntervalsPassed + ",";
                            crateLog += Docks[i].truckToUnload.Driver + ",";
                            crateLog += Docks[i].truckToUnload.DeliveryCompany + ",";
                            crateLog += Docks[i].truckToUnload.Trailer.Peek().ID + ",";
                            crateLog += Docks[i].truckToUnload.Trailer.Peek().Price + ",";
                            Docks[i].TotalSales += Docks[i].truckToUnload.UnloadTruck().Price;
                            report.TotalCratesUnloaded++;
                            report.DockTimeUse[i]++;

                            if (Docks[i].truckToUnload.Trailer.Count != 0)
                            {
                                crateLog += "A crate was unloaded but the truck still has more crates to unload.\n";
                                Log += crateLog;
                            }
                            else if (Docks[i].line.TryPeek(out Truck result))
                            {
                                crateLog += "A crate was unloaded, and the truck has no more crates to unload, and another truck is already in the Dock.\n";
                                Docks[i].truckToUnload = Docks[i].SendOff();
                                report.TotalTrucksProcessed++;
                                Log += crateLog;
                            }
                            else
                            {
                                crateLog += "A crate was unloaded, and the truck has no more crates to unload, but another truck is NOT already in the Dock.\n";
                                Log += crateLog;
                            }

                        }
                        else if (Docks[i].line.TryPeek(out Truck result))
                        {
                            Docks[i].truckToUnload = Docks[i].SendOff();
                            report.TotalTrucksProcessed++;
                        }



                        //When the truck is completely unloaded, it is immediately swapped with the next truck in line. (Queue)
                        //a.    One-time increment to unload the last item off the current truck
                        //b.    Next-time increment to unload the first item off next truck
                    }
                }
            }
            foreach (Dock dock in Docks)
            {
                report.TotalCratesValue += dock.TotalSales;
            }
            report.AverageCrateValue = report.TotalCratesValue / report.TotalCratesUnloaded;
            report.AverageTrailerValue = report.TotalCratesValue / report.TotalTrucksProcessed;
            Console.WriteLine(report.ToString());
            WriteToLog(Log);
        }

        public static void WriteToLog(string crateLog)
        {
            using (StreamWriter wtr = new StreamWriter(@"..\..\..\Log.csv"))
            {
                wtr.WriteLine(crateLog);
            }
        }
    }
}