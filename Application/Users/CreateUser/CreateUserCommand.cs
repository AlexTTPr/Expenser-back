using MediatR;

namespace Application.Users.CreateUser;
// Include properties to be used as input for the command
public record CreateUserCommand(
	string Name,
	string Email,
	string Password) : IRequest<CreateUserCommandResponse>;