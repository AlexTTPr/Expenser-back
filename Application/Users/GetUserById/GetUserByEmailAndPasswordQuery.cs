using MediatR;

namespace Application.Users.GetUserById;
// Include properties to be used as input for the query
public record GetUserByEmailAndPasswordQuery(string Email, string Password) : IRequest<GetUserByEmailAndPasswordQueryResponse>;
