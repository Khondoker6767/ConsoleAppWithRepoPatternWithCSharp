using CSConsoleProject1.DataInMemory;
using CSConsoleProject1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleProject1.Repository
{
    public class RepoMedicines : IRepository<Medicines>, IRepository
    {
        MedicinesData Prod = new MedicinesData();

        public IEnumerable<Medicines> GetAll()//1
        {
            return Prod.GetAll();
        }

        public Medicines Get(long id)//2
        {
            return Prod.Get(id);
        }


        public IEnumerable<Medicines> GetByName(string name)//3
        {
            return Prod.GetAll();
        }

        public Medicines Name(string name)//3
        {

            return Prod.Name(name);
        }


        public Medicines Add(Medicines obj)//4
        {
            return Prod.Add(obj);
        }



        public Medicines Update(Medicines svm)//5
        {
            return Prod.Update(svm);
        }




        public bool Remove(long id)//6
        {
            return Prod.Remove(id);
        }

        public bool Remove(Medicines svm)//6
        {
            return Prod.Remove(svm);
        }

        
    }
}
