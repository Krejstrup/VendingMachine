using VendingMachineConsoleApp.Models;
using Xunit;

namespace VendingMachineConsoleApp.Tests.Models
{
    public class IdGeneratorTests
    {



        [Fact]
        public void GetNewId_GetTwoDifferentID_DifferentID()
        {
            //Arrange
            IdGenerator myIdGenerator = new IdGenerator();

            //Act
            int localId1 = myIdGenerator.GetNewId();
            int localId2 = myIdGenerator.GetNewId();

            //Assert
            Assert.NotEqual(localId1, localId2);
        }


    }
}
