﻿
using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBacketResponse(bool IsSuccess);

    public class DeleteBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(userName));
                var response = result.Adapt<DeleteBacketResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteBasket")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Basket")
            .WithDescription("Delete Basket");
        }
    }
}
