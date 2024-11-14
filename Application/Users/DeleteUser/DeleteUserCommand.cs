using MediatR;

namespace Application.Users.DeleteUser;
// Include properties to be used as input for the command
public record DeleteUserCommand(Guid Id) : IRequest;