using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions
{
    public class ProductNoFoundException : NotFoundException
    {
        public ProductNoFoundException(Guid id) : base("Product", id)
        {
        }
    }
}
