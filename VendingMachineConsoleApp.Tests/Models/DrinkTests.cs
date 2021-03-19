using System.Collections.Generic;
using VendingMachineConsoleApp.Data;
using VendingMachineConsoleApp.Models;
using Xunit;


namespace VendingMachineConsoleApp.Tests.Models
{
    public class DrinkTests
    {
        //=========== Use() ====================
        [Fact]
        public void Use_Set_Get()
        {
            //Arrange

            //Act

            //Assert

        }


        //============ Examine() ===============
        [Fact]
        public void Examine_Cond_Expect()
        {
            //Arrange

            //Act

            //Assert

        }


        //============ GetId() ===============================
        [Fact]
        public void GetId_CreateVendorPickDrinkOut_CheckedIdIs2()
        {
            //Arrange
            Vending myVendor = new Vending();
            List<Product> collection = myVendor.GetProducts();
            Product myProduct = collection[2];
            int expectedId = 2;
            //Act
            int myProductId = myProduct.GetId();

            //Assert
            Assert.Equal(expectedId, myProductId);
        }


    }
}
