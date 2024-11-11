namespace Catalog.API.Exceptions
{
    public class ProductNoFoundException : Exception
    {
        public ProductNoFoundException() : base("Product no found!")
        {
        }
    }
}
