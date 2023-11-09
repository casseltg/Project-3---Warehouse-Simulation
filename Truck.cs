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
  //The function below is to unload a truck. 
  //It checks first to make sure there is data there before removing a crate
  //returns item removed if there is an item to remove
  //returns empty trailer if there is no item to remove 
        public Crate UnloadTruck()
        {
            
            If(Trailer.Count != 0)
            {
                Trailer.Pop(); 
                return Trailer.Pop(); 
            }
            return Trailer;
        }  
    //View
        public Crate View()
        {
            
        }
    }
}
