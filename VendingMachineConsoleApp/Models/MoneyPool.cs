using System.Collections.Generic;


namespace VendingMachineConsoleApp.Models
{

    public enum MyLocalCurrency
    {
        Thousend = 1000, FiveHundred = 500, Hundred = 100, Fifty = 50, Twenty = 20, Ten = 10, Five = 5, One = 1
    }

    /// <summary>
    /// MoneyPool keeps the collection of the different types of values in currency.
    /// </summary>
    public class MoneyPool
    {
        private int _userMoney;
        private readonly Dictionary<MyLocalCurrency, int> _moneyCollection = new Dictionary<MyLocalCurrency, int>();

        /// <summary>
        /// Empty Constructor.
        /// </summary>
        public MoneyPool()
        {

        }

        /// <summary>
        /// Add method increases the saldo for the user. Note only Enum specified values
        /// are accepted, by input hardware io interface.
        /// </summary>
        /// <param name="Input">One Input by Enumerator value at a time.</param>
        /// <param name="value">If you input a value more than once in a row, set this value.</param>
        public void Add(MyLocalCurrency Input, int value = 1)
        {
            // only valid currency input
            _userMoney += (int)Input;
            if (_moneyCollection.ContainsKey(Input))
            {
                _moneyCollection[Input] += value;
            }
            else
            {
                _moneyCollection.Add(Input, value);
            }

        }

        /// <summary>
        /// Saldo returns the sum of the User vending saldo.
        /// </summary>
        /// <returns>Returns an integer of saldo.</returns>
        public int Saldo()
        {
            return _userMoney;
        }

        /// <summary>
        /// Checks that the user has the money for a comming transaction.
        /// </summary>
        /// <param name="Cost">The price of the product tha should be checked.</param>
        /// <returns>Returns true if the saldo checks out. Returns false if not.</returns>
        public bool HaveMoney(int Cost)
        {
            if (Cost > _userMoney)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// UseMoney reduces the saldo of the user by the amount passed in. Function checks
        /// if there is enough money to use before withdrawl.
        /// </summary>
        /// <param name="useValue">The amount of money that will be withdrawn.</param>
        public void UseMoney(int useValue)
        {
            if (HaveMoney(useValue))
            {
                _userMoney -= useValue;
            }

        }

        /// <summary>
        /// GetMoneyPool returns the list of input money into the pool.
        /// </summary>
        /// <returns>Dictionary collection of the money.</returns>
        public Dictionary<MyLocalCurrency, int> GetMoneyPool()
        {
            return _moneyCollection;
            //IEnumerable<out _moneyCollection >;

        }

        /// <summary>
        /// EndAndEmpty is the last thing the user sees from a normal vending
        /// point of view - the usage of the product is beyond the normal behaviour
        /// of a vending machine. User gets some change back and vendor emties saldo.
        /// </summary>
        public void EndAndEmpty()
        {
            System.Console.WriteLine("Here's your change back from {0} kr:", _userMoney);

            _moneyCollection.Clear();
            int value;

            for (int i = 1000; i > 0; i--)
            {
                if (System.Enum.IsDefined(typeof(MyLocalCurrency), i))
                {
                    value = _userMoney / i;
                    _userMoney -= value * i;
                    if (value > 0)
                    {
                        System.Console.WriteLine("{0}: {1}", (MyLocalCurrency)i, value);
                    }
                }
            }

            _userMoney = 0;
        }

    }
}
