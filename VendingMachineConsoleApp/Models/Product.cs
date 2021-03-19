namespace VendingMachineConsoleApp.Models
{
    public abstract class Product : IUse
    {
        protected readonly int _price;
        protected readonly int _id;
        protected string _description;

        /// <summary>
        /// COnstructor for this base abstract class. Sets the most important
        /// values of the product - Id and Price.
        /// </summary>
        /// <param name="inId">The setting Id for this product.</param>
        /// <param name="inPrice">The price for this product.</param>
        public Product(int inId, int inPrice)
        {
            _id = inId;
            _price = inPrice;
        }

        /// <summary>
        /// GetPrice returns this products price.
        /// </summary>
        /// <returns>The products price as an integer.</returns>
        public int GetPrice()
        {
            return _price;
        }

        /// <summary>
        /// The Description of the product is quite important.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// GetId fetches the Id of this product.
        /// </summary>
        /// <returns>Returns the unique Id of this product.</returns>
        public int GetId()
        {
            return _id;
        }

        /// <summary>
        /// Use is an Virtual method declared here but implemented in the child class.
        /// </summary>
        public virtual void Use()
        {

        }

        /// <summary>
        /// Examine is a Virtual method declared here but implemented in the child class.
        /// </summary>
        public virtual void Examine()
        {

        }
    }

}