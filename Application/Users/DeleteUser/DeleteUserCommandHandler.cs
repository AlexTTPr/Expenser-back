
using Domain.Users;

using MediatR;

namespace Application.Users.DeleteUser;
public sealed class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
{
	public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		await userRepository.RemoveAsync(request.Id);
	}
}