using System.Collections.Generic;
using VendingMachineConsoleApp.Data;
using VendingMachineConsoleApp.Models;
using Xunit;

namespace VendingMachineConsoleApp.Tests.Models
{
    public class ToyTests
    {

        //============== Use() ========================================
        [Fact]
        public void Use_Set_Get()   //???
        {
            //Arrange
            bool ExpexctedResult = true;
            Toy aToyProduct = new Toy(0, "A ball", 57);   // id=0, A ball, 57:-

            //Act
            aToyProduct.Use();  // ???

            //Assert
            Assert.True(ExpexctedResult);   // ???
        }


        //============= Examine() =====================================
        [Fact]
        public void Examine_Cond_Expect()   //????
        {
            //Arrange

            //Act

            //Assert

        }


        //============ GetId() ===============================
        [Fact]
        public void GetId_CreateVendorPickFoodOut_CheckedIdIs1()
        {
            //Arrange
            Vending myVendor = new Vending();
            List<Product> collection = myVendor.GetProducts();
            Product myProduct = collection[1];
            int expectedId = 1;

            //Act
            int myProductId = myProduct.GetId();

            //Assert
            Assert.Equal(expectedId, myProductId);
        }

    }
}
