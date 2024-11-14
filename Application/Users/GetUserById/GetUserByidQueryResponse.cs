namespace Application.Users.GetUserById;

public record class GetUserByidQueryResponse(
	string Name,
	string Email,
	string PasswordHash);