using System.Collections.Generic;
using VendingMachineConsoleApp.Models;
using Xunit;

namespace VendingMachineConsoleApp.Tests.Models
{
    public class MoneyPoolTests
    {


        [Fact]
        public void Add_ValuesIn_ExpectCorrectValues()
        {
            //Arrange
            MoneyPool myMoneyPool = new MoneyPool();
            myMoneyPool.Add(MyLocalCurrency.Fifty);
            myMoneyPool.Add(MyLocalCurrency.Ten);
            myMoneyPool.Add(MyLocalCurrency.Five);
            myMoneyPool.Add(MyLocalCurrency.One);
            myMoneyPool.Add(MyLocalCurrency.One);
            int myExpectedSaldo = 67;

            //Act
            int mySaldo = myMoneyPool.Saldo();

            //Assert
            Assert.Equal(myExpectedSaldo, mySaldo);
        }


        // Tests if we have enough money on saldo to buy by value
        [Fact]
        public void HaveMoney_PutInMoney_HaveEnoughMoney()
        {
            //Arrange
            MoneyPool myMoneyPool = new MoneyPool();
            myMoneyPool.Add(MyLocalCurrency.Fifty);
            myMoneyPool.Add(MyLocalCurrency.Ten);
            myMoneyPool.Add(MyLocalCurrency.Five);
            myMoneyPool.Add(MyLocalCurrency.One);
            myMoneyPool.Add(MyLocalCurrency.One);
            //Act
            bool haveMoney = myMoneyPool.HaveMoney(25);

            //Assert
            Assert.True(haveMoney);
        }

        // Tests if we dont have enough money on saldo to buy by value
        [Fact]
        public void HaveMoney_PutInMoney_HaveNotEnoughMoney()
        {
            //Arrange
            MoneyPool myMoneyPool = new MoneyPool();
            myMoneyPool.Add(MyLocalCurrency.Fifty);
            myMoneyPool.Add(MyLocalCurrency.Ten);
            myMoneyPool.Add(MyLocalCurrency.Five);
            myMoneyPool.Add(MyLocalCurrency.One);
            myMoneyPool.Add(MyLocalCurrency.One);
            //Act
            bool haveMoney = myMoneyPool.HaveMoney(125);

            //Assert
            Assert.False(haveMoney);
        }

        // Tests if we have right sum of money on saldo after use of money
        [Fact]
        public void HaveMoney_UseMoney_HaveRightMoneyLeft()
        {
            //Arrange
            MoneyPool myMoneyPool = new MoneyPool();
            myMoneyPool.Add(MyLocalCurrency.Fifty);
            myMoneyPool.Add(MyLocalCurrency.Ten);
            myMoneyPool.Add(MyLocalCurrency.Five);
            myMoneyPool.Add(MyLocalCurrency.One);
            myMoneyPool.Add(MyLocalCurrency.One);
            int myExpectedSaldo = 37;

            //Act
            myMoneyPool.UseMoney(30);
            int mySaldo = myMoneyPool.Saldo();

            //Assert
            Assert.Equal(myExpectedSaldo, mySaldo);
        }



        // Test that the UseMoney doesn't use if not enough saldo
        [Fact]
        public void UseMoney_PutInMoneyUseToMuch_SameSaldo()
        {
            //Arrange
            MoneyPool myMoneyPool = new MoneyPool();
            myMoneyPool.Add(MyLocalCurrency.Fifty);
            myMoneyPool.Add(MyLocalCurrency.Ten);
            myMoneyPool.Add(MyLocalCurrency.Five);
            myMoneyPool.Add(MyLocalCurrency.One);
            myMoneyPool.Add(MyLocalCurrency.One);
            int myExpectedSaldo = 7;

            //Act
            myMoneyPool.UseMoney(30);
            myMoneyPool.UseMoney(30);
            myMoneyPool.UseMoney(30);
            int mySaldo = myMoneyPool.Saldo();

            //Assert
            Assert.Equal(myExpectedSaldo, mySaldo);

        }



        [Fact]
        public void GetMoneyPool_Cond_Expect()
        {
            //Arrange
            MoneyPool myMoneyPool = new MoneyPool();
            myMoneyPool.Add(MyLocalCurrency.Fifty);
            myMoneyPool.Add(MyLocalCurrency.Ten);
            myMoneyPool.Add(MyLocalCurrency.Five);
            myMoneyPool.Add(MyLocalCurrency.One);
            myMoneyPool.Add(MyLocalCurrency.One);

            //Act
            Dictionary<MyLocalCurrency, int> currencyInput = myMoneyPool.GetMoneyPool();

            //Assert
            Assert.NotNull(currencyInput);
        }


        // EndAndEmpty has been tested by Program (that was fun!)
        [Fact]
        public void EndAndEmpty_Cond_Expect()
        {
            //Arrange
            MoneyPool myMoneyPool = new MoneyPool();
            myMoneyPool.Add(MyLocalCurrency.Fifty);
            myMoneyPool.Add(MyLocalCurrency.Ten);
            myMoneyPool.Add(MyLocalCurrency.Five);
            myMoneyPool.Add(MyLocalCurrency.One);
            myMoneyPool.Add(MyLocalCurrency.One);
            int myExpectedSaldo = 0;
            //Act
            myMoneyPool.EndAndEmpty();
            int mySaldo = myMoneyPool.Saldo();

            //Assert
            Assert.Equal(myExpectedSaldo, mySaldo);
        }


    }
}
