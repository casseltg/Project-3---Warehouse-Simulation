using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Warehouse_Simulation
{
    internal class Report
    {
        public int DocksOpen { get; set; }
        public int LongestLine { get; set; }
        public int TotalTrucksProcessed { get; set; }
        public int TotalCratesUnloaded { get; set; }
        public double TotalCratesValue { get; set; }

        public double AverageCrateValue { get; set; }
        public double AverageTrailerValue { get; set; }
        public List<int> DockTimeUse { get; set; }

        public Report(int docksOpen)
        {
            DocksOpen = docksOpen;
            LongestLine = 0;
            TotalTrucksProcessed = 0;
            TotalCratesUnloaded = 0;
            AverageCrateValue = 0;
            AverageTrailerValue = 0;
            DockTimeUse = new List<int>(docksOpen);
            for (int i = 0; i < docksOpen; i++)
            {
                DockTimeUse.Add(0);
            }
        }

        
        

        public override string ToString()
        {
            string report = $"The number of docks open was {DocksOpen}" +
                   $"\nThe longest line at any loading dock was {LongestLine}" +
                   $"\nThe total number of trucks processed was {TotalTrucksProcessed}" +
                   $"\nThe total number of crates unloaded was {TotalCratesUnloaded}" +
                   $"\nThe total value of the crates unloaded was {TotalCratesValue}" +
                   $"\nThe average value of the crates unloaded was {Math.Round(AverageCrateValue, 2)}" +
                   $"\nThe average value of each truck unloaded was {Math.Round(AverageTrailerValue, 2)}";

            int totalTime = 0;
            for (int i = 0; i < DockTimeUse.Count; i++)
            {
                double dockTimeUseDouble = DockTimeUse[i];
                report += $"\nDock {i + 1} was in use for {DockTimeUse[i]} time increments" +
                          $"\nDock {i + 1} was not in use for {48 - DockTimeUse[i]} time increments" +
                          $"\nDock {i + 1} was open for {Math.Round(dockTimeUseDouble / 48d * 100, 2)}% of the time increments";
                totalTime += DockTimeUse[i];
            }
            report += $"\nThe average time any dock was in use was {totalTime / DockTimeUse.Count}" +
                      $"\nThe total cost of operating all docks was ${DockTimeUse.Count * 48 * 100}" +
                      $"\nThe total profit of the warehouse was ${TotalCratesValue - (DockTimeUse.Count * 48 * 100)}";
            return report;
        }
    }
}
