using Application.Transactions.CreateTransaction;
using Application.Transactions.DeleteTransaction;
using Application.Transactions.UpdateTransaction;

using Domain.Shared;
using Domain.Transactions;
using Domain.Users;

using Moq;

namespace Expenser_tests;

public class TransactionCqrsTests
{
	private Mock<IUserRepository> _userRepositoryMock;
	private Mock<ITransactionRepository> _transactionRepositoryMock;
	private Mock<ICategoryRepository> _categoryRepositoryMock;
	private Mock<ITagRepository> _tagRepositoryMock;

	[SetUp]
	public void Setup()
	{
		_userRepositoryMock = new Mock<IUserRepository>();
		_transactionRepositoryMock = new Mock<ITransactionRepository>();
		_categoryRepositoryMock = new Mock<ICategoryRepository>();
		_tagRepositoryMock = new Mock<ITagRepository>();
	}

	[Test]
	public void CreateTransaction_CreationFails()
	{
		var categoryId = Guid.NewGuid();

		Assert.Throws<ArgumentException>(() => new CreateTransactionCommand(Guid.NewGuid(), DateTime.Now, 0, new Money() { Amount = -54, Currency = Currency.RUB }, categoryId, []));
	}

	[Test]
	public void CreateTransaction_Succeeds()
	{
		var userId = Guid.NewGuid();
		_userRepositoryMock
			.Setup(e => e.GetByIdAsync(userId))
				.Returns(Task.FromResult(new User("1", "1", "1"))!);

		var categoryId = Guid.NewGuid();
		_categoryRepositoryMock
			.Setup(e => e.GetByIdAsync(categoryId))
				.Returns(Task.FromResult(new TransactionCategory(userId, "1", 0))!);

		_tagRepositoryMock
			.Setup(e => e.GetByIdAsync(It.IsAny<Guid>()))
				.Returns(Task.FromResult(new Tag(Guid.NewGuid().ToString(), userId))!);

		_transactionRepositoryMock
			.Setup(e => e.AddAsync(It.IsAny<Transaction>()))
				.Returns(Task.CompletedTask);

		var req = new CreateTransactionCommand(userId, DateTime.Now, 0, new Money() { Amount = 54, Currency = Currency.RUB }, categoryId, [Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()]);

		var handler = new CreateTransactionCommandHandler(_transactionRepositoryMock.Object, _tagRepositoryMock.Object, _userRepositoryMock.Object, _categoryRepositoryMock.Object);

		Assert.DoesNotThrow(() => handler.Handle(req).Wait());
	}

	[Test]
	public void UpdateTransaction_Succeeds()
	{
		var userId = Guid.NewGuid();
		var categoryId = Guid.NewGuid();
		var transactionId = Guid.NewGuid();

		var category = new TransactionCategory(userId, userId.ToString(), 0);

		_categoryRepositoryMock
			.Setup(e => e.GetByIdAsync(categoryId))
			.Returns(Task.FromResult(category)!);

		_transactionRepositoryMock
			.Setup(e => e.UpdateAsync(It.IsAny<Transaction>()))
				.Returns(Task.CompletedTask);

		_transactionRepositoryMock
			.Setup(e => e.GetByIdAsync(transactionId))
			.Returns(Task.FromResult(new Transaction(userId, DateTime.Now, 0, category, new Money() { Amount = 54, Currency = Currency.RUB }, []))!);

		var req = new UpdateTransactionCommand(userId, transactionId, DateTime.Now, 0, new Money() { Amount = 54, Currency = Currency.RUB }, categoryId, []);
		var handler = new UpdateTransactionCommandHandler(_transactionRepositoryMock.Object, _tagRepositoryMock.Object, _userRepositoryMock.Object, _categoryRepositoryMock.Object);

		Assert.DoesNotThrow(() => handler.Handle(req, new CancellationToken()).Wait());
	}

	[Test]
	public void UpdateTransaction_Fails()
	{
		var userId = Guid.NewGuid();
		var categoryId = Guid.NewGuid();
		var transactionId = Guid.NewGuid();

		var category = new TransactionCategory(userId, userId.ToString(), 0);

		_transactionRepositoryMock
			.Setup(e => e.UpdateAsync(It.IsAny<Transaction>()))
				.Returns(Task.CompletedTask);

		_transactionRepositoryMock
			.Setup(e => e.GetByIdAsync(transactionId))
			.Returns(Task.FromResult(new Transaction(userId, DateTime.Now, 0, category, new Money() { Amount = 54, Currency = Currency.RUB }, []))!);

		var req = new UpdateTransactionCommand(userId, transactionId, DateTime.Now, 0, new Money() { Amount = 54, Currency = Currency.RUB }, categoryId, []);
		var handler = new UpdateTransactionCommandHandler(_transactionRepositoryMock.Object, _tagRepositoryMock.Object, _userRepositoryMock.Object, _categoryRepositoryMock.Object);

		Assert.Throws<AggregateException>(() => handler.Handle(req, new CancellationToken()).Wait());
	}


	[Test]
	public void DeleteTransaction_Succeeds()
	{
		var transactionId = Guid.NewGuid();

		_transactionRepositoryMock
			.Setup(e => e.RemoveAsync(transactionId))
			.Returns(Task.CompletedTask);

		var req = new DeleteTransactionCommand(transactionId);
		var handler = new DeleteTransactionCommandHandler(_transactionRepositoryMock.Object);

		Assert.That(() => handler.Handle(req, new CancellationToken()), Throws.Nothing);
	}

	[Test]
	public void DeleteTransaction_Fails()
	{
		var transactionId = Guid.NewGuid();

		_transactionRepositoryMock
			.Setup(e => e.RemoveAsync(transactionId))
			.Throws(new ArgumentException());

		var req = new DeleteTransactionCommand(transactionId);
		var handler = new DeleteTransactionCommandHandler(_transactionRepositoryMock.Object);

		Assert.That(() => handler.Handle(req, new CancellationToken()), Throws.ArgumentException);
	}
}