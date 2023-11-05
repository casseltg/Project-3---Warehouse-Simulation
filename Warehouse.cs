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
            Random randy = new Random();
            for (int i = 1; i <= 48; i++)
            {
                if (randy.Next(1) = 1)
                {
                    //Truck arrives
                }
            }

        }
}
