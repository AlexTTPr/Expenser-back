using Domain.Transactions;
using Domain.Users;

namespace Infrastructure.Common;
public static class DbSeeder
{
	public static void SeedDb(AppDbContext context)
	{
		if(context.Users.Any())
			return;

		User[] users = [
			new User("u1", "e1", "p1"),
			new User("u2", "e2", "p2"),
			new User("u3", "e3", "p3")
		];

		TransactionCategory[] categories = [
			new TransactionCategory(null, "Shopping", TransactionType.Expense),
			new TransactionCategory(null, "Work", TransactionType.Income),
		];

		Tag[] tags = [
			new Tag("1", users[0].Id),
			new Tag("2", users[1].Id)
		];

		context.AddRange(users);
		context.SaveChanges();
		context.AddRange(categories);
		context.SaveChanges();
		context.AddRange(tags);
		context.SaveChanges();
	}
}
