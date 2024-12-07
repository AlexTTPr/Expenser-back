using MediatR;

namespace Application.Categories.GetCategory;
// Include properties to be used as input for the query
public record GetAllCategoriesByUserIdQuery(Guid UserId) : IRequest<GetAllCategoriesByUserIdQueryResponse>;
