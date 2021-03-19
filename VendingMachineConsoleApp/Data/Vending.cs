using System.Collections.Generic;
using VendingMachineConsoleApp.Models;


namespace VendingMachineConsoleApp.Data
{


    public class Vending
    {
        readonly MoneyPool userMoneyPool = new MoneyPool();
        readonly IdGenerator myIdGenerator = new IdGenerator();
        readonly List<Product> productList = new List<Product>();
        //readonly List<Product> userList = new List<Product>();

        public Vending()
        {
            //insert one product of each in vendor
            productList.Add(new Toy(myIdGenerator.GetNewId(), "A Football", 27));
            productList.Add(new Drink(myIdGenerator.GetNewId(), "A bottle of water", 9));
            productList.Add(new Food(myIdGenerator.GetNewId(), "A Sandwich", 12));
        }

        public void InsertMoney(MyLocalCurrency inPut)
        {
            userMoneyPool.Add(inPut);
        }

        public void ShowAll()
        {
            foreach (Product prodObj in productList)
            {
                if (prodObj is Toy)
                {
                    ((Toy)prodObj).Examine();
                }
                if (prodObj is Food)
                {
                    ((Food)prodObj).Examine();
                }
                if (prodObj is Drink)
                {
                    ((Drink)prodObj).Examine();
                }
            }
        }

        public bool Purchase(int Id)  // köpa grejerna
        {
            foreach (Product prodObj in productList)
            {
                if (prodObj.GetId() == Id)
                {
                    int priceTag = prodObj.GetPrice();
                    if (userMoneyPool.HaveMoney(priceTag))
                    {
                        productList.Remove(prodObj);
                        userMoneyPool.UseMoney(prodObj.GetPrice());
                        prodObj.Use();  // don't know if well just use it now
                        //userList.Add( prodObj); // or put it in a new list and use all at checkout
                        return true;
                    }

                }
            }
            return false;
        }

        public int Saldo()
        {
            return userMoneyPool.Saldo();
        }

        public void EndTeansaction()
        {
            int userSaldo = userMoneyPool.Saldo();
            System.Console.WriteLine("Here's your change back from {0} kr:", userSaldo);

            // Erase the User Money Pool/Saldo
            userMoneyPool.UseMoney(userSaldo);
            int value;

            for (int i = 1000; i > 0; i--)  // couldn't find any easier way than this... 
            {
                if (System.Enum.IsDefined(typeof(MyLocalCurrency), i))
                {
                    value = userSaldo / i;
                    userSaldo -= value * i;
                    if (value > 0)
                    {
                        System.Console.WriteLine("{0}: {1}", (MyLocalCurrency)i, value);
                    }
                }
            }
        }

        public List<Product> GetProducts()  // ONLY FOR xUnitTests!!
        {
            return productList;
        }


    }
}
