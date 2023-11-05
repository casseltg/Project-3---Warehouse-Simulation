using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Warehouse_Simulation
{
    internal class Dock
    {
        public string Id { get; private set; }
        private Queue<Truck> line;
        public double TotalSales { get; private set; }
        public int TotalCrates { get; private set; }
        public int TimeInUse { get; private set; }
        public int TimeNotInUse {  get; private set; }

        public Dock()
        {
            Id = string.Empty;
            line = new Queue<Truck>() //The () were missing on these;
            TotalSales = 0;
            TotalCrates = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
        }

        public Dock(string id)
        {
            Id = id;
            line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
        }

        void JoinLine (Truck truck)
        {
            line.Enqueue(truck);
        }
        
        Truck SendOff()
        {
            return line.Dequeue();
        }

    }
}
