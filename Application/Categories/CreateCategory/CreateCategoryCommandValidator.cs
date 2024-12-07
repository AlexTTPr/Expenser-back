using FluentValidation;

namespace Application.Categories.CreateCategory;
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
	public CreateCategoryCommandValidator()
	{
		RuleFor(e => e.Name).Length(1, 50);
	}
}
