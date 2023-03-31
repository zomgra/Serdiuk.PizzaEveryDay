using FluentResults;
using MediatR;

namespace Serdiuk.PizzaEveryDay.Application.Products.GetAll
{
    /// <summary>
    /// Query to get all product
    /// </summary>
    public class GetAllProductQuery : IRequest<Result<object>>
    {

    }
}
