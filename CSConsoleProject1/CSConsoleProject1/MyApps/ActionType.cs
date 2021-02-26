using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleProject1.MyApps
{
    public enum Packages
    {
        MedicineStore = 1, FishMarked, FruitMarked
    }
    public enum ActionType
    {
        ShowAllData = 1,
        SearchByID,
        SearchByName,
        AddNewItem,
        UpdateByID,
        DeleteByID,
        AboutThisProject,
        DevelopedBy
    }
}
