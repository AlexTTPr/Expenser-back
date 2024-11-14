using Application.Transactions.CreateTransaction;
using Application.Transactions.DeleteTransaction;
using Application.Transactions.GetTransactionById;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TransactionsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpPost]
	public async Task<ActionResult<CreateTransactionCommandResponse>> CreateTransaction([FromBody] CreateTransactionCommand command)
	{
		var validation = new CreateTransactionCommandValidator().Validate(command);
		if(validation!.IsValid)
			return BadRequest(validation.Errors);

		return Ok(await _mediator.Send(command));
	}

	[HttpGet]
	[Route("{id:guid}")]
	public async Task<ActionResult<GetTransactionByIdQuery>> GetTransaction(Guid id)
	{
		return Ok(await _mediator.Send(new GetTransactionByIdQuery(id)));
	}

	[HttpDelete]
	[Route("{id:guid}")]
	public async Task<ActionResult<DeleteTransactionCommand>> DeleteTransaction(Guid id)
	{
		await _mediator.Send(new DeleteTransactionCommand(id));
		return Ok();
	}
}
