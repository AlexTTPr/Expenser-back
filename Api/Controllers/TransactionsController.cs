using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TransactionsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;
	[HttpPost]
	public async Task<ActionResult> CreateTransaction()
	{
		return Created();
	}
}
