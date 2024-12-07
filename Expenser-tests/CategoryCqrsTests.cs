using System.Linq.Expressions;

using Application.Categories.CreateCategory;
using Application.Categories.DeleteCategory;
using Application.Categories.GetCategory;

using Domain.Transactions;
using Domain.Users;

using Moq;

namespace Expenser_tests;

public class CategoryCqrsTests
{
	private Mock<IUserRepository> _userRepositoryMock;
	private Mock<ICategoryRepository> _categoryRepositoryMock;

	[SetUp]
	public void Setup()
	{
		_userRepositoryMock = new Mock<IUserRepository>();
		_categoryRepositoryMock = new Mock<ICategoryRepository>();
	}

	[Test]
	public void CreateCategory_Succeeds()
	{
		var userId = Guid.NewGuid();
		_userRepositoryMock
			.Setup(e => e.GetByIdAsync(userId))
			.Returns(Task.FromResult(new User("1", "1", "1"))!);

		_categoryRepositoryMock
			.Setup(e => e.AddAsync(It.IsAny<TransactionCategory>()))
			.Returns(Task.CompletedTask);

		var req = new CreateCategoryCommand(userId, "1", 0);
		var handler = new CreateCategoryCommandHandler(_userRepositoryMock.Object, _categoryRepositoryMock.Object);

		Assert.That(() => handler.Handle(req, new CancellationToken()), Throws.Nothing);
	}

	[Test]
	public void CreateCategory_Throws()
	{
		var userId = Guid.NewGuid();
		_userRepositoryMock
			.Setup(e => e.GetByIdAsync(userId))
			.Throws(new ArgumentException());

		_categoryRepositoryMock
			.Setup(e => e.AddAsync(It.IsAny<TransactionCategory>()))
			.Returns(Task.CompletedTask);

		var req = new CreateCategoryCommand(userId, "1", 0);
		var handler = new CreateCategoryCommandHandler(_userRepositoryMock.Object, _categoryRepositoryMock.Object);

		Assert.That(() => handler.Handle(req, new CancellationToken()), Throws.ArgumentException);
	}

	[Test]
	public void DeleteCategory_Succeeds()
	{
		var userId = Guid.NewGuid();

		_userRepositoryMock
			.Setup(e => e.GetByIdAsync(userId))
			.Returns(Task.FromResult(new User("1", "1", "1"))!);

		var caregoryId = Guid.NewGuid();

		_categoryRepositoryMock
			.Setup(e => e.GetByIdAsync(caregoryId))
			.Returns(Task.FromResult(new TransactionCategory(userId, "1", 0))!);

		_categoryRepositoryMock
			.Setup(e => e.RemoveAsync(caregoryId))
			.Returns(Task.CompletedTask);

		var req = new DeleteCategoryCommand(caregoryId, userId);
		var handler = new DeleteCategoryCommandHandler(_userRepositoryMock.Object, _categoryRepositoryMock.Object);

		Assert.That(() => handler.Handle(req, new CancellationToken()), Throws.Nothing);
	}

	[Test]
	public void GetAllCategoriesByUserId_Succeeds()
	{
		var userId = Guid.NewGuid();

		List<TransactionCategory> categories = [
			new TransactionCategory(userId, "1", 0),
			new TransactionCategory(userId, "2", 0),
			new TransactionCategory(userId, "3", 0),
			new TransactionCategory(userId, "4", 0),
			new TransactionCategory(userId, "5", 0)];

		_userRepositoryMock
			.Setup(e => e.GetByIdAsync(userId))
			.Returns(Task.FromResult(new User("1", "1", "1"))!);

		_categoryRepositoryMock
			.Setup(e => e.GetManyAsync(It.IsAny<Expression<Func<TransactionCategory, bool>>>(), false))
			.Returns(Task.FromResult(categories as ICollection<TransactionCategory>));

		var req = new GetAllCategoriesByUserIdQuery(userId);
		var handler = new GetAllCategoriesByUserIdQueryHandler(_userRepositoryMock.Object, _categoryRepositoryMock.Object);

		Assert.That(() => handler.Handle(req, new CancellationToken()), Throws.Nothing);
	}

	[Test]
	public void GetAllCategoriesByUserId_Fails()
	{
		var userId = Guid.NewGuid();

		List<TransactionCategory> categories = [
			new TransactionCategory(userId, "1", 0),
			new TransactionCategory(userId, "2", 0),
			new TransactionCategory(userId, "3", 0),
			new TransactionCategory(userId, "4", 0),
			new TransactionCategory(userId, "5", 0)];

		_categoryRepositoryMock
			.Setup(e => e.GetManyAsync(It.IsAny<Expression<Func<TransactionCategory, bool>>>(), false))
			.Returns(Task.FromResult(categories as ICollection<TransactionCategory>));

		var req = new GetAllCategoriesByUserIdQuery(userId);
		var handler = new GetAllCategoriesByUserIdQueryHandler(_userRepositoryMock.Object, _categoryRepositoryMock.Object);

		Assert.That(() => handler.Handle(req, new CancellationToken()), Throws.ArgumentException);
	}
}
