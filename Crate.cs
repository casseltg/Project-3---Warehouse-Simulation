using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Warehouse_Simulation
{
    internal class Crate
    {
        public string ID {get; private set;}     
        public double Price {get; private set;}

        public Crate()
        {
            Random randy = new Random();
            ID = randy.Next(1000, 10000).ToString();
            Price = randy.Next(100, 1000);
        }
    }
}
