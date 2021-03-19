namespace VendingMachineConsoleApp.Models
{
    class Drink : Product
    {


        public Drink(int Id, string inDescription, int price) : base(Id, price)
        {
            base.Description = inDescription;
        }

        /// <summary>
        /// Use is supposed to show the interface what usage this product has when used.
        /// Outputs string.
        /// </summary>
        public override void Use()
        {
            System.Console.WriteLine("Drink the drink!");

        }

        /// <summary>
        /// Examine prints out information about this product.
        /// </summary>
        public override void Examine()
        {
            System.Console.WriteLine("[{0}]: Price: {1} info: {2}", _id, _price, Description);
        }

        /// <summary>
        /// GetId returns this specific product its Id. This is fetched from the base class.
        /// </summary>
        /// <returns>Returns the Id of this item.</returns>
        public int GetId()
        {
            return base.GetId();
        }
    }
}
