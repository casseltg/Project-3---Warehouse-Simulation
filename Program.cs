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

namespace Project_3___Warehouse_Simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse(3);
            warehouse.Run();
        }
    }
}
