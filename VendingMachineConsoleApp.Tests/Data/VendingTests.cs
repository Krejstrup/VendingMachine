using System.Collections.Generic;
using VendingMachineConsoleApp.Data;
using VendingMachineConsoleApp.Models;
using Xunit;

namespace VendingMachineConsoleApp.Tests.Data
{
    public class VendingTests
    {

        //=========== Constructor Vending() =======================
        [Fact]
        public void Constructor_Create_NotNull()
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            //Act
            List<Product> collection = myVendor.GetProducts();
            //Assert
            Assert.NotNull(collection);
        }
        [Fact]
        public void Constructor_Create_NotEmpty()
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            //Act
            List<Product> collection = myVendor.GetProducts();
            //Assert
            Assert.NotEmpty(collection);
        }
        [Fact]
        public void Constructor_Create_ThreeItems()
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            int expectedSumOfItems = 3;
            int numberOfItems = 0;
            List<Product> collection = myVendor.GetProducts();
            //Act
            foreach (var item in collection)
            {
                numberOfItems++;
            }
            //Assert
            Assert.Equal(expectedSumOfItems, numberOfItems);
        }

        //================ InsertMoney() =============================
        [Fact]
        public void InsertMoney_PutInHundred_HundredInSaldo()
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            int expectedValue = 100;
            //Act
            myVendor.InsertMoney(MyLocalCurrency.Hundred);
            int userMoney = myVendor.Saldo();
            //Assert
            Assert.Equal(expectedValue, userMoney);
        }

        //=============== ShowAll() ====================================
        [Fact]
        public void ShowAll_Cond_Expect()   // ??? 
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            //Act

            //Assert

        }

        //=============== Purchase() ====================================
        [Fact]
        public void Purchase_PutIn3ItemsBuy1_LessItemsLeftOnlyTwoItemsLeft()  //???
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            List<Product> collection = myVendor.GetProducts();
            int expectedNumberOfItems = 2;

            //Act
            myVendor.InsertMoney((MyLocalCurrency)100); // Even if ve pretend to buy, we need money!
            int NumberOfItems1 = collection.Count;
            myVendor.Purchase(1);                       // Purchase the first item in Vendor
            int NumberOfItems2 = collection.Count;

            //Assert
            Assert.NotEqual(NumberOfItems1, NumberOfItems2);
            Assert.Equal(expectedNumberOfItems, NumberOfItems2);
        }

        //================ Saldo() ======================================
        [Fact]
        public void Saldo_PutInHundred_SaldoIsHundred()
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            int expectedValue = 100;

            //Act
            myVendor.InsertMoney(MyLocalCurrency.Hundred);
            int userMoney = myVendor.Saldo();

            //Assert
            Assert.Equal(expectedValue, userMoney);

        }

        //================ EndTansaction() =============================
        [Fact]
        public void EndTeansaction_PutInMoneyExit_ReturnsMoneyVendorEmpty()
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            int expectedSaldo = 0;

            //Act
            myVendor.InsertMoney((MyLocalCurrency)100); // Even if ve pretend to buy, we need money!
            myVendor.EndTeansaction();
            int userSaldo = myVendor.Saldo();

            //Assert
            Assert.Equal(expectedSaldo, userSaldo);
        }

        [Fact]
        public void EndTeansaction_PutInMoneyExit_SameAmountProductsLeftInVendor()
        {
            //Arrange
            Vending myVendor = new Vending();   // vending machine is now populated with standard products
            List<Product> collection = myVendor.GetProducts();
            int expectedNumberOfItems = 3;

            //Act
            myVendor.InsertMoney((MyLocalCurrency)100); // Even if ve pretend to buy, we need money!
            myVendor.EndTeansaction();
            int numberOfItems2 = collection.Count;

            //Assert
            Assert.Equal(expectedNumberOfItems, numberOfItems2);

        }


    }
}
