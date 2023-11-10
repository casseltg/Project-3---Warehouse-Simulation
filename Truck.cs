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

        ///
        /// <summary>
        /// Unloads a crate from the truck object
        /// </summary>
        /// <returns>The crate being removed</returns>
        public Crate UnloadTruck()
        {
            If(Trailer.Count != 0)
            {
                Trailer.Pop(); 
                return Trailer.Pop(); 
            }
            return Trailer;
        }  

        /// <summary>
        /// Checks that the truck trailer contains crates
        /// </summary>
        /// <returns></returns>
        public Crate ViewCratesInTrailer()
        {
            If(Trailer.Count != 0)
            {
                Trailer.Peek(); 
                return Trailer.Peek(); 
            }    
            return Trailer; 
        }
    }
}
