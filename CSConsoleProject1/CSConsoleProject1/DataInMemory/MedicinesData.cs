using CSConsoleProject1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleProject1.DataInMemory
{
    class MedicinesData : IData<Medicines>
    {
        static List<Medicines> data = new List<Medicines>() {
            new Medicines () { MedicineID= 101,    MedicineName= "Synthroid      ",  SideEffect= true,      Quantity=5,     Price=1320},
            new Medicines () { MedicineID= 102,    MedicineName= "Crestor        ",  SideEffect= false,     Quantity=6,     Price=1600 },
            new Medicines () { MedicineID= 103,    MedicineName= "Lantus Solostar",  SideEffect= true,      Quantity=7,     Price=550 },
            new Medicines () { MedicineID= 104,    MedicineName= "Januvia        ",  SideEffect= true,      Quantity=8,     Price=1000 },
            new Medicines () { MedicineID= 105,    MedicineName= "Ventolin HFA   ",  SideEffect= false,     Quantity=2,     Price=1500 },
            new Medicines () { MedicineID= 106,    MedicineName= "Parasitamal    ",  SideEffect= false,     Quantity=3,     Price=1000 }

        };

        public IEnumerable<Medicines> GetAll()//1
        {
            return data;
        }

        public Medicines Get(long id)//2
        {
            Medicines cust = data.Find(p => p.MedicineID == id);
            return cust;
        }



        public Medicines Get(string name)//3
        {
            return data.FirstOrDefault(p => p.MedicineName == name);

        }

        public IEnumerable<Medicines> GetByName(string name)//3
        {
            var gets = data.Where(a => a.MedicineName.Contains(name));
            return gets;
        }


        public Medicines Name(string name)//3
        {
            return data.FirstOrDefault(p => p.MedicineName.Contains(name));
        }


        public Medicines Add(Medicines obj)//4
        {

            obj.MedicineID = 1;
            if (data != null && data.Count > 0)
                obj.MedicineID = data.Max(a => a.MedicineID) + 1;
            data.Add(obj);
            return obj;


        }

        public Medicines Update(Medicines obj)//5
        {
            Medicines r = data.FirstOrDefault(q => q.MedicineID == obj.MedicineID);
            //r.MedicineName = obj.MedicineName;
            //r.IsActive = obj.IsActive;
            //r.Details = obj.Details;
            //r.Price = obj.Price;


            if (obj.MedicineName != null && obj.MedicineName.Trim() != "")
            {
                r.MedicineName = obj.MedicineName;
            }
            else if (obj.SideEffect != null)
            {
                r.SideEffect = obj.SideEffect;
            }
            else if (obj.Quantity != null)
            {
                r.Quantity = obj.Quantity;
            }
            else if (obj.Price != null)
            {
                r.Price = obj.Price;
            }
            return r;
        }
                     

        public bool Remove(long id)//6
        {
            data.RemoveAll(p => p.MedicineID == id);
            return true;
        }

        public bool Remove(Medicines obj)//6
        {
            data.RemoveAll(p => p.MedicineID == obj.MedicineID);
            return true;
        }



        //public void LoadSampleData()
        //{
        //    this.Add(new Medicines { MedicineName = "Napa", SideEffect = false, Quantity = 2, Price = 52000 });
        //    this.Add(new Medicines { MedicineName = "Seclo", SideEffect = true, Quantity = 3, Price = 2000 });
        //    this.Add(new Medicines { MedicineName = "Napa Extra", SideEffect = true, Quantity = 4, Price = 500 });
        //    this.Add(new Medicines { MedicineName = "Phenjit", SideEffect = false, Quantity = 8, Price = 600 });

        //}


    }
}
