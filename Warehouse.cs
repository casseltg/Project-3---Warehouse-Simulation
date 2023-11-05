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
        private List<Dock> Docks { get; set; }

        private Queue<Truck> Entrance { get; set; }

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
            int timeIntervalsPassed = 0;
            
            Random randy = new Random();
            for (timeIntervalsPassed = 0; i <= 48; i++)
            {
                if (randy.Next(1) = 1)
                {
                    //Truck arrives
                }
            

        //Once a truck arrives, it is sent to the gate entrance.
        
        //Once at the gate entrance, a truck is added to a loading dock once every time increment.
        
        //Once at the loading dock, one of a truck’s crates is unloaded at every time increment.
        
        //When the truck is completely unloaded, it is immediately swapped with the next truck in line. (Queue)
        //a.    One-time increment to unload the last item off the current truck
        //b.    Next-time increment to unload the first item off next truck.
            }

        }
}
