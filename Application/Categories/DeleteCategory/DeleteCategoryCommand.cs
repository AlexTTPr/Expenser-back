using MediatR;

namespace Application.Categories.DeleteCategory;
// Include properties to be used as input for the command
public record DeleteCategoryCommand(Guid CategoryId, Guid UserId) : IRequest;