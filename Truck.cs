using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Warehouse_Simulation
{
    internal class Truck
    {
        string driver;
        string deliveryCompany;
        Stack<Crate> Trailer = new Stack<Crate>();
        public void LoadTruck(Crate crate)
        {
            Trailer.Push(crate);
        }

        public Crate UnloadTruck()
        {
            return Trailer.Pop();
        }    
    }
}
