using System.Collections.Generic;
using VendingMachineConsoleApp.Data;
using VendingMachineConsoleApp.Models;
using Xunit;

namespace VendingMachineConsoleApp.Tests.Models
{
    public class FoodTests
    {

        [Fact]
        public void Use_Set_Get()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public void Examine_Cond_Expect()
        {
            //Arrange

            //Act

            //Assert

        }


        //============ GetId() ===============================
        [Fact]
        public void GetId_CreateVendorPickFoodOut_CheckedIdIs3()
        {
            //Arrange
            Vending myVendor = new Vending();
            List<Product> collection = myVendor.GetProducts();
            Product myProduct = collection[3];
            int expectedId = 3;

            //Act
            int myProductId = myProduct.GetId();

            //Assert
            Assert.Equal(expectedId, myProductId);
        }

    }
}
