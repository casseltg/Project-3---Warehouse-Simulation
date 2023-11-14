using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Warehouse_Simulation
{
    internal class Truck
    {
        public string Driver { get; private set; }
        public string DeliveryCompany { get; private set; }
        public Stack<Crate> Trailer;

        public Truck()
        {
            List<string> driverNames = new List<string>(10)
            {
                "Bob",
                "Steve",
                "Cassandra",
                "Jebediah",
                "Gregor",
                "Landry",
                "Vlorflumaax the Destroyer",
                "Bob's Cousin",
                "Larry",
                "Lowry"
            };
            Random randy = new Random();
            Driver = driverNames[randy.Next(10)];
            List<string> deliveryCompany = new List<string>(5)
            {
                "BUPS",
                "XPORT",
                "BreadEx",
                "EHL",
                "GillTrans"
            };
            DeliveryCompany = deliveryCompany[randy.Next(5)];
            Trailer = new Stack<Crate>();
            for (int i = 0; i < randy.Next(1, 11); i++)
            {
                Trailer.Push(new Crate());
            }
        }

        public void LoadTruck(Crate crate)
        {
            Trailer.Push(crate);
        }

        ///
        /// <summary>
        /// Unloads a crate from the truck object
        /// </summary>
        /// <returns>The crate being removed</returns>
        public Crate UnloadTruck()
        {
            return Trailer.Pop();
        }  

        /// <summary>
        /// Checks that the truck trailer contains crates
        /// </summary>
        /// <returns></returns>
        public Crate ViewCratesInTrailer()
        {
            return Trailer.Peek(); 
        }
    }
}
