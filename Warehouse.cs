using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Warehouse_Simulation
{
    internal class Warehouse
    {
        public List<Dock> Docks { get; private set; }

        public Queue<Truck> Entrance { get; private set; }

        public Warehouse()
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
        }

        public Warehouse(int numOfDocks)
        {
            for (int i = 0; i < numOfDocks; i++)
            {
                Dock dock = new Dock(i);
                this.Docks.Add(dock);
            }
            Entrance = new Queue<Truck>();
        }

        public void Run()
        {
            //A loaded truck arrives at the Warehouse with a random # of cargo crates in a random time interval between increments of 1 to 48.

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
                Docks[smallestQueueIndex].line.Add(Entrance.Dequeue());
              
                //Once at the loading dock, one of a truck’s crates is unloaded at every time increment.
                foreach (Dock dock in Docks)
                {
                    //Should cause an exception if the truck is empty. Will fix if it works normally
                    dock.UnloadCrate();
                }
        
        //When the truck is completely unloaded, it is immediately swapped with the next truck in line. (Queue)
        //a.    One-time increment to unload the last item off the current truck
        //b.    Next-time increment to unload the first item off next truck.
            }

        }
}
