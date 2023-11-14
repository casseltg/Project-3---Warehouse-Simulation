///////////////////////////////////////////////////////////////////////////////
//
// Author: Derek Depew, depewdj@etsu.edu
// Author: Hope Grayson,casseltg@etsu.edu
// Author: Kevin Davis, daviskl2@etsu.edu
// Author: Venkata Sireesha Dulam,dulamv@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3: Warehouse Simulation
// Description: This Project simulates the production profit margin for a Warehouse.
//
//////////////////////////////////////////////////////////////////////////////
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
            Price = randy.Next(50, 501);
        }
    }
}
