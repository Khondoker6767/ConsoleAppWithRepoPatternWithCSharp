using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleProject1.DTO
{
    public class Medicines : IObjects
    {
        public long MedicineID { get; set; }
        public string MedicineName { get; set; }
        public Nullable<bool> SideEffect { get; set; }
        public int Quantity { get; set; }
        public Nullable<double> Price { get; set; }
    }
}
