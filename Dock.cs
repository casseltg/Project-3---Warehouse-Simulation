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
    internal class Dock
    {
        public string Id { get; private set; }
        public Queue<Truck> line;
        public double TotalSales { get; internal set; }
        public int TotalCrates { get; private set; }
        public int TimeInUse { get; private set; }
        public int TimeNotInUse {  get; private set; }
        public Truck truckToUnload;

        public Dock()
        {
            Id = string.Empty;
            line = new Queue<Truck>(); //The () were missing on these;
            TotalSales = 0;
            TotalCrates = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
            truckToUnload = null;
        }
        //<summary>
        // Creates an indidividual dock
        // with ID, line, TotalSales, TotalCrates, 
        // TimeInUse, TimeNotInUse, and TrucktoUnloak
        // Sets an individual dock to be empty
        //</summary 
        public Dock(string id)
        {
            Id = id;
            line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
            truckToUnload = null;
        }

        ///
        /// <summary>
        /// Queues a truck in the line to use the dock
        /// </summary>
        /// <param name="truck">The truck to be queued</param>
        public void JoinLine (Truck truck)
        {
            line.Enqueue(truck);
        }
        
        ///
        /// <summary>
        /// Method for offloading truck from queue into active use in the dock
        /// </summary>
        /// <returns>A truck to be unloaded</returns>
        public Truck? SendOff()
        {
            if (line.Count > 0)
            {
                return line.Dequeue();
            }
            return null;
        }
    }
}
