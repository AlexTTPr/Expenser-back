using Application.Users.CreateUser;
using Application.Users.DeleteUser;
using Application.Users.GetUserById;

using Domain.Users;

using Moq;

namespace Expenser_tests;

public class UserCqrsTests
{
	private Mock<IUserRepository> userRepositoryMock;

	[SetUp]
	public void Setup()
	{
		userRepositoryMock = new Mock<IUserRepository>();
	}

	[Test]
	public void CreateUser_SucceedsValidation()
	{
		var req = new CreateUserCommand("1", "1", "1");

		Assert.That(new CreateUserCommandValidator().Validate(req).IsValid, Is.False);
	}

	[Test]
	public void CreateUser_FailsValidation()
	{
		var req = new CreateUserCommand("Alexander", "Alexander@gamil.com", "Qwerty123456!");

		Assert.That(new CreateUserCommandValidator().Validate(req).IsValid, Is.True);
	}

	[Test]
	public void DeleteUser_Succeeds()
	{
		var id = Guid.NewGuid();
		userRepositoryMock
			.Setup(e => e.RemoveAsync(id))
				.Returns(Task.CompletedTask);

		var req = new DeleteUserCommand(id);
		var handler = new DeleteUserCommandHandler(userRepositoryMock.Object);

		Assert.DoesNotThrow(() => handler.Handle(req, new CancellationToken()).Wait());
	}

	[Test]
	public void GetUserById_Succeeds()
	{
		var id = Guid.NewGuid();

		userRepositoryMock
			.Setup(e => e.GetByIdAsync(id))
				.Returns(Task.FromResult(new User("1", "1", "1"))!);

		var req = new GetUserByidQuery(id);
		var handler = new GetUserByidQueryHandler(userRepositoryMock.Object);

		Assert.DoesNotThrow(() => handler.Handle(req, new CancellationToken()).Wait());
	}
}
