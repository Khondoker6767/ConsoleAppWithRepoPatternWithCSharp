using CSConsoleProject1.DTO;
using CSConsoleProject1.Repository;
using CSConsoleProject1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleProject1.MyApps
{
    class AppMedicines : IMyApps
    {
        IRepository<Medicines> repo = new RepoMedicines();
        public ActionType Action { get; set; }


        public void ShowMenu()
        {
            Array ShowOutput = Enum.GetValues(typeof(ActionType));
            foreach (var En in ShowOutput)
            {
                Console.WriteLine("     " + (int)En + ")" + En);
            }
        }


        public void ReadMenuSelection()
        {
            try
            {
                string key;
                do
                {
                    Console.Clear();
                    this.ShowMenu();
                    Console.Write("Please Enter a Action Number: [S to Stop]: \n");
                    key = Console.ReadLine();
                    if (key.ToLower() != "S")
                    {
                        int temp = 0;
                        temp = int.Parse(key);
                        Action = (ActionType)temp;
                        Console.Clear();
                        this.ManageAllAction();
                    }
                    else
                    {
                        //this.Close();
                    }
                } while (key.ToLower() != "S");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void WaitForGoBack()
        {
            ConsoleKeyInfo key;
            Console.WriteLine("\n\n\"Esc\" to go back");
            do
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    return;
                    //Environment.Exit(0);
                }
            }
            while (key.Key != ConsoleKey.Escape);
        }


        public void ManageAllAction()
        {
            switch (Action)
            {


                case ActionType.ShowAllData:
                    this.ShowAllDataAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.SearchByID:
                    this.SearchByIDAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.SearchByName:
                    this.SearchByNameAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.AddNewItem:
                    this.AddNewItemAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.UpdateByID:
                    this.UpdateByIDAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.DeleteByID:
                    this.DeleteByIDAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.AboutThisProject:
                    this.AboutThisProject();
                    this.WaitForGoBack();
                    break;
                case ActionType.DevelopedBy:
                    this.DevelopedBy();
                    this.WaitForGoBack();
                    break;
                default:
                    Console.WriteLine("Please Enter Valid Operation");
                    this.WaitForGoBack();
                    break;
            }
        }


        public void ShowAllDataAction()//1
        {
            Console.WriteLine("MedicineID:\tMedicineName:\tSideEffect:  \tQuantity:\tPrice: ");
            Console.WriteLine("-----------\t-------------\t-----------  \t---------\t------");
            var items = repo.GetAll();
            foreach (var obj2 in items)
            {
                
                //Console.WriteLine("MedicineID: {0}\t\tMedicineName: {1}\tSideEffect: {2}\tQuantity: {3}\tPrice: {4}", obj2.MedicineID, obj2.MedicineName, obj2.SideEffect, obj2.Quantity, obj2.Price);
                //Console.WriteLine("MedicineID: {0}\t\tMedicineName: {1}\tSideEffect: {2}\tQuantity: {3}\tPrice: {4}", obj2.MedicineID, obj2.MedicineName, obj2.SideEffect, obj2.Quantity, obj2.Price);
                Console.WriteLine($"    {obj2.MedicineID} \t{obj2.MedicineName}\t{obj2.SideEffect} \t\t{obj2.Quantity+" pcs"}\t\t{obj2.Price+" tk"}");
            }
        }


        public void SearchByIDAction()//2
        {
            Console.Write("\nEnter a Medicine ID: ");
            int id = int.Parse(Console.ReadLine());
            var Data = repo.Get(id);
            if (Data != null)
            {
                Console.Clear();
                Console.WriteLine("\nMedicineID:\tMedicineName:\tSideEffect:  \tQuantity:\tPrice: ");
                Console.WriteLine("-----------\t-------------\t-----------  \t---------\t------");
                Console.WriteLine($"    {Data.MedicineID} \t{Data.MedicineName}\t{Data.SideEffect} \t\t{Data.Quantity+" pcs"}\t\t{Data.Price+" tk"}");
            }
            else if (Data == null)
            {
                Console.WriteLine("You entered a invalid ID.");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }


        public void SearchByNameAction()//3
        {
            Console.Write("\nEnter a Medicine Name: ");
            string Name = Console.ReadLine();
            var Data = repo.Name(Name);
            if (Name != null)
            {
                Console.Clear();
                Console.WriteLine("\nMedicineID:\tMedicineName:\tSideEffect:  \tQuantity:\tPrice: ");
                Console.WriteLine("-----------\t-------------\t-----------  \t---------\t------");
                Console.WriteLine($"    {Data.MedicineID} \t{Data.MedicineName}\t{Data.SideEffect} \t\t{Data.Quantity + " pcs"}\t\t{Data.Price + " tk"}");
            }
            else if (Name == null)
            {
                Console.WriteLine("You entered a invalid Name.");
            }
        }
       
      
        public void AddNewItemAction()//4
        {
            Medicines obj = new Medicines();
            Console.Write("Enter a Medicine Name: ");
            obj.MedicineName = Console.ReadLine();


            Console.Write("Enter theMedicine SideEffect: true or false: ");
            obj.SideEffect = bool.Parse(Console.ReadLine());

            Console.Write("Enter the Medicine Quantity: ");
            obj.Quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter the Medicine Price: ");
            obj.Price = long.Parse(Console.ReadLine());


            obj = repo.Add(obj);
            Console.WriteLine("\nThe Medicine is Succesfully added. \nYour Medicine Id is: {0}", obj.MedicineID);
        }


        public void UpdateByIDAction()//5
        {
            Console.Write("Press any key to show all data:  ");
            string name = Console.ReadLine();

            this.ShowAllDataAction();
            Console.Write("\nDo you want to update? ");
            Console.Write("\nPress any key to update...\n");
            this.WaitForGoBack();

            Medicines obj2 = new Medicines();
            ConColor obj = new ConColor();
            obj.WriteMessage("Enter a valid ID: ", MessageType.Warning);
            obj2.MedicineID = long.Parse(Console.ReadLine());


            obj.WriteMessage("\nEnter your Medicine Name: ", MessageType.Warning);
            obj2.MedicineName = Console.ReadLine();

            obj.WriteMessage("Enter theMedicine SideEffect: true or false: ", MessageType.Warning);
            obj2.SideEffect = bool.Parse(Console.ReadLine());

            obj.WriteMessage("Enter the Medicine Quantity: ", MessageType.Warning);
            obj2.Quantity = int.Parse(Console.ReadLine());

            obj.WriteMessage("Enter the Medicine Price: ", MessageType.Warning);
            obj2.Price = long.Parse("0" + Console.ReadLine());


            repo.Update(obj2);
            obj.WriteMessage("\nThe Medicine is Succesfully Updated.", MessageType.Success);
        }


        public void DeleteByIDAction()//6
        {
            Medicines obj = new Medicines();
            Console.Write("Enter a valid ID: ");
            long id = long.Parse(Console.ReadLine());
            repo.Remove(id);
            if (repo.Remove(id))
            {

                Console.WriteLine("The Entered Id is Removed");
            }

            else
            {
                Console.WriteLine("The Entered Id is not Here");
            }
        }


        public void AboutThisProject()//7
        {
            ConColor Col = new ConColor();
            Col.WriteMessage("\nWelcome!! This is my First project using C#\n that has basic CRUD operation with in memory data.", MessageType.Success);
            //Console.WriteLine("\nWelcome to my First Project.\nThis is the project where you can act many operations. Basically It's my first project about CRUD on C#");
        }


        public void DevelopedBy()//8
        {
            ConColor Col = new ConColor();
            Col.WriteMessage("\n\tThe Project is developed by KHONDOKER FARHAD. \n\tTraineeID  : 1257368.\n\tBatch ID   : ESAD-CS/USSL/44/01.\n\tTspCentre  : US-Software Limited.", MessageType.Success);
            //Console.WriteLine("\n\tThe Project is developed by MD.OBYDULLAH. \n\tTraineeID  : 1257676.\n\tBatch ID   : ESAD-CS/USSL/44/01.\n\tTspCentre  : US-Software Limited.");
        }      
    }
}
