namespace VendingMachineConsoleApp.Models
{
    public class IdGenerator        // was internal But public for xUnitTests
    {

        int idCounter = 0;

        /// <summary>
        /// GetNewId for indexing the products. Also used for pointing out the product to buy.
        /// </summary>
        /// <returns>Returns a unique Id every time.</returns>
        public int GetNewId()     // Was internal, but changed to public for xUnitTests
        {
            return ++idCounter;
        }

    }
}
