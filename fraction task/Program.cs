using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fraction_task { 
     
    class Cat
    {
        public string NickName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Energy { get; set; }
        public int Price { get; set; }
        public int MealQuantity { get; set; }

        public void Eat()
        {
            Energy += 5;
            Price += 1; 
        }
        public void Sleep()
        {
            Energy += 50;
        }
        public void Play()
        {
            Energy -= 10;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+++++++++ Cat INFO ++++++++++");
            Console.WriteLine($"Nick Name : {NickName}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"Gender : {Gender}");
            Console.WriteLine($"Energy : {Energy}");
            Console.WriteLine($"Price : {Price}");
            Console.WriteLine($"Meal Quantity : {MealQuantity}");
        }
    }
    class CatHouse
    {
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; }

        public void AddCat(ref Cat cat)
        {
            Cat[] temp = new Cat[++CatCount];
            if (Cats != null)
            {
                Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cat;
            Cats = temp;
        }

        
        public void ShowCats()
        {
            if (Cats != null)
            {
                foreach (var item in Cats)
                {
                    item.Show();
                }
            }
        }

        private int Find(string name)
        {
            int index = -1;
            for (int k = 0; k < CatCount; k++)
            {
                if (Cats[k].NickName == name)
                {
                    index = k;
                    break;
                }
            }
            return index;
        }
        public void RemoveByNickname(string name)
        {
            Cat[] destination = new Cat[CatCount - 1];
            int index = Find(name);



            if (Cats != null && index != -1)
            {
                Array.Copy(Cats, 0, destination, 0, index);
            }
            if (index < CatCount - 1)
            {
                Array.Copy(Cats, index + 1, destination, index, CatCount - index - 1);
            }
            Cats = destination;
        }
    }

    class PetHouse
    {
        public CatHouse[] Cathouses { get; set; }
        public int CatHouseCount { get; set; }

        public Cat[] cats { get; set; }

        public void AddCatHouse(CatHouse catHouse)
        {
            CatHouse[] temp = new CatHouse[++CatHouseCount];
            if (Cathouses != null)
            {
                Cathouses.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = catHouse;
            Cathouses = temp;
        }

        public int CalculateMealQuantity()
        {
            int sumQuantity = 0;
            foreach (var item in cats)
            {
                sumQuantity += item.MealQuantity;
            }
            return sumQuantity;
        }

        public int CalculatePrice()
        {
            int sumPrice = 0 ;
            foreach (var item in cats)
            {
                sumPrice += item.Price;
            }
            return sumPrice;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            Cat cat1 = new Cat
            {
                NickName = "Mestan",
                Age = 2,
                Gender = "D",
                Energy = 100,
                Price = 50,
                MealQuantity = 30
            };
            Cat cat2 = new Cat
            {
                NickName = "John",
                Age = 2,
                Gender = "E",
                Energy = 100,
                Price = 50,
                MealQuantity = 30
            };
            Cat[] cats = new Cat[2] { cat1, cat2 };
            CatHouse catHouse1 = new CatHouse();
            CatHouse catHouse2 = new CatHouse();
            CatHouse[] catHouses = new CatHouse[2] { catHouse1, catHouse2 };
            PetHouse petHouse = new PetHouse()
            {
                cats = cats,
                Cathouses = catHouses,
                CatHouseCount = 1
            };
            catHouse1.AddCat(ref cat1);
            catHouse1.AddCat(ref cat2);
            catHouse1.ShowCats();
            petHouse.AddCatHouse(catHouse1);

            //catHouse1.RemoveByNickname("John");
            //Console.Clear();
            //catHouse1.ShowCats();

            Console.WriteLine($"\n\n\nTotal meal quantity : {petHouse.CalculateMealQuantity()}");
            Console.WriteLine($"\nTotal Price : {petHouse.CalculatePrice()}");
        }
    }
}
