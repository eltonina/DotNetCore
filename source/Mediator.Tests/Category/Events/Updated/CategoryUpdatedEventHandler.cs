using DotNetCore.Results;
using System.Threading.Tasks;

namespace DotNetCore.Mediator.Tests
{
    public sealed class CategoryUpdatedEventHandler : IHandler<CategoryUpdatedEvent>
    {
        public Task<IResult> HandleAsync(CategoryUpdatedEvent @event)
        {
            return Result.SuccessAsync();
        }
    }
}
