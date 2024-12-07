using Domain.Transactions;

namespace Application.Categories.GetCategory;

public record GetCategoryByIdQueryResponse(Guid Id, Guid UserId, string Name, TransactionType TransactionType);
