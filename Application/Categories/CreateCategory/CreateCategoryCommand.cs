using Domain.Transactions;

using MediatR;

namespace Application.Categories.CreateCategory;
// Include properties to be used as input for the command
public record CreateCategoryCommand(Guid UserId, string Name, TransactionType TransactionType) : IRequest<CreateCategoryCommandResponse>;