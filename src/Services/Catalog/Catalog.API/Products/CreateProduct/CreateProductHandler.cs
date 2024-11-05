using System.ComponentModel;
using System.Xml.Linq;
using BuildingBlocks.CQRS;
using Catalog.API.Modules;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Create product entity from command object
            //Save to database
            //Return createProductresult result

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            return new CreateProductResult(Guid.NewGuid());



        }
    }
}
