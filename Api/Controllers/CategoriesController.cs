using Application.Categories.CreateCategory;
using Application.Categories.DeleteCategory;
using Application.Categories.GetCategory;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController(IMediator _mediator) : ControllerBase
{
	[HttpGet]
	[Route("{id:guid}")]
	public async Task<ActionResult<GetCategoryByIdQueryResponse>> GetCategory(Guid id, [FromQuery] Guid userId)
	{
		return Ok(await _mediator.Send(new GetCategoryByIdQuery(userId, id)));
	}

	[HttpGet]
	[Route("availableFor/{userId:guid}")]
	public async Task<ActionResult<GetAllCategoriesByUserIdQueryResponse>> GetUsersCategories(Guid userId)
	{
		return Ok(await _mediator.Send(new GetAllCategoriesByUserIdQuery(userId)));
	}

	[HttpPost]
	public async Task<ActionResult<CreateCategoryCommandResponse>> CreateCategory([FromBody] CreateCategoryCommand command)
	{
		return Ok(await _mediator.Send(command));
	}

	[HttpDelete]
	[Route("{id:guid}")]
	public async Task<ActionResult> DeleteCategory(Guid id, [FromQuery] Guid userId)
	{
		await _mediator.Send(new DeleteCategoryCommand(userId, id));

		return Ok();
	}
}
