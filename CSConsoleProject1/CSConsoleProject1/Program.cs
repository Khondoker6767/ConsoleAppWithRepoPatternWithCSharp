using CSConsoleProject1.MyApps;
using CSConsoleProject1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleProject1
{    
     class Program
     {
          static void Main(string[] args)
          {
              Factory.SelectedPackage = Packages.MedicineStore;
              IMyApps app = Factory.GetApp();

              app.ReadMenuSelection();

              Console.ReadLine();
          }
     }
    
}
