using Application.Users.CreateUser;
using Application.Users.DeleteUser;
using Application.Users.GetUserById;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
	[HttpPost]
	public async Task<ActionResult<CreateUserCommand>> CreateUser([FromBody] CreateUserCommand command)
	{
		var validation = new CreateUserCommandValidator().Validate(command);
		if(validation!.IsValid)
			return BadRequest(validation.Errors);

		var res = await mediator.Send(command);

		return Ok(res);
	}

	[HttpGet]
	[Route("{id:guid}")]
	public async Task<ActionResult<GetUserByidQuery>> GetUser(Guid id)
	{
		return Ok(await mediator.Send(new GetUserByidQuery(id)));
	}

	[HttpDelete]
	[Route("{id:guid}")]
	public async Task<ActionResult<DeleteUserCommand>> DeleteUser(Guid id)
	{
		await mediator.Send(new DeleteUserCommand(id));
		return Ok();
	}
}
