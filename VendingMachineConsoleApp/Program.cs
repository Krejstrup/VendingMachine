using System;
using VendingMachineConsoleApp.Data;

namespace VendingMachineConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Vending myVending = new Vending();
            int userInput;

            Console.WriteLine("Hello Vending Machine!");

            /*
            //====== Tester av Enums och Dictionaries för eget bruk ==============
            int EnFemtiLapp = (int)MyLocalCurrency.Fifty;
            Console.WriteLine("{0} = {1}",(MyLocalCurrency)50, EnFemtiLapp);

            Dictionary<MyLocalCurrency, int> moneyCollection = new Dictionary<MyLocalCurrency, int>();

            moneyCollection.Add(MyLocalCurrency.Fifty, 2);
            moneyCollection.Add(MyLocalCurrency.One, 2);
            moneyCollection.Add(MyLocalCurrency.Twenty, 2);
            Console.WriteLine("Antal Valörer: " + moneyCollection.Count);

            foreach (KeyValuePair<MyLocalCurrency, int> myValor in moneyCollection)
            {
                System.Console.WriteLine($"{myValor.Key}: {myValor.Value}");
            }


            === Tester av klassen MoneyPool ===========
            MoneyPool AnotherMoneyPool = new MoneyPool();
            AnotherMoneyPool.Add(MyLocalCurrency.Hundred);
            AnotherMoneyPool.Add(MyLocalCurrency.Ten);
            AnotherMoneyPool.Add(MyLocalCurrency.Fifty);
            AnotherMoneyPool.Add(MyLocalCurrency.Ten);
            AnotherMoneyPool.Add(MyLocalCurrency.Five);
            AnotherMoneyPool.Add(MyLocalCurrency.One);

             ========== More tests: ===========================================
            for (int myLoop = 0; myLoop <= 1000; myLoop++)
            {
                Console.Write("{0} ", Enum.GetName(typeof(MyLocalCurrency), myLoop));
            }
            */
            bool Repeat = true;
            // ===== input some money:
            while (Repeat)
            {
                Console.Clear();
                Console.WriteLine("Vendor offers: ");
                myVending.ShowAll();
                Console.WriteLine("\nCurrency acceptance: 1,5,10,20,50,100,1000.");
                Console.WriteLine("User money saldo: [0=exit] " + myVending.Saldo());
                Console.Write("Insert Money: ");
                userInput = GetNumber();
                if (userInput == 0) Repeat = false;

                if (Repeat)
                {
                    myVending.InsertMoney((Models.MyLocalCurrency)userInput);
                    Console.WriteLine("User money saldo: " + myVending.Saldo());
                }
            }

            //====== show goods: ========
            Console.Clear();
            Console.WriteLine("Vendorlist: ");
            myVending.ShowAll();

            Console.WriteLine("User money saldo: " + myVending.Saldo());
            Console.WriteLine("What you wanna buy? [id]: ");
            userInput = GetNumber();
            myVending.Purchase(userInput);
            Console.WriteLine("\n===== Checking rest of products in Vending Machine ==");
            myVending.ShowAll();
            Console.WriteLine("=====================================================\n");
            myVending.EndTeansaction();
            Console.WriteLine("Thanks for shopping att Buy n Large (BnL Corp.)!");
        }

        // ============== Reuse from older Exercise ============================
        private static int GetNumber()
        {
            int mySlask;
            bool runAgain = true;

            do
            {
                bool slaskTratt = (int.TryParse(Console.ReadLine(), out mySlask));

                if (slaskTratt) runAgain = false;
                if (!slaskTratt) Console.Write(" No, Bugger! Try again : ");

            } while (runAgain);
            return mySlask;
        }
    }
}
