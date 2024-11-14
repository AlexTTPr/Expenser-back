using FluentValidation;

namespace Application.Users.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
	public CreateUserCommandValidator()
	{
		RuleFor(e => e.Name).NotNull().Length(1, 30);
		RuleFor(e => e.Email).NotNull().Length(5, 30).Matches("^[A-Za-zА-Яа-я0-9._%+-]+@[A-Za-zА-Яа-я0-9.-]+\\.[A-Za-zА-Яа-я]{2,}$");
		RuleFor(e => e.Password).NotNull().Length(8, 30).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d@$!%*?&]{8,32}$");
	}
}
