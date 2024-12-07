using Domain.Transactions;

namespace Application.Categories.GetCategory;

public record GetAllCategoriesByUserIdQueryResponse(ICollection<TransactionCategory> Categories);
