using MediatR;

namespace Application.Categories.GetCategory;
// Include properties to be used as input for the query
public record GetCategoryByIdQuery(Guid UserId, Guid CategoryId) : IRequest<GetCategoryByIdQueryResponse>;
