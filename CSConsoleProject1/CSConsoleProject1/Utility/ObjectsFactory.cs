using CSConsoleProject1.DTO;
using CSConsoleProject1.MyApps;
using CSConsoleProject1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleProject1.Utility
{
    public class Factory
    {
        public static Packages SelectedPackage;

        public static IMyApps GetApp()
        {
            IMyApps app = null;
            switch (Factory.SelectedPackage)
            {
                case Packages.MedicineStore:
                    app = new AppMedicines();
                    break;
                default:
                    app = null;
                    break;
            }
            return app;
        }
        public static IRepository GetRepo()
        {
            IRepository repo = null;
            switch (Factory.SelectedPackage)
            {
                case Packages.MedicineStore:
                    repo = new RepoMedicines();
                    break;
                default:
                    repo = null;
                    break;
            }
            return repo;
        }

        public static IObjects GetDTO()
        {
            IObjects dto = null;
            switch (Factory.SelectedPackage)
            {
                case Packages.MedicineStore:
                    dto = new Medicines();
                    break;
                default:
                    dto = null;
                    break;
            }
            return dto;
        }
    }
}
