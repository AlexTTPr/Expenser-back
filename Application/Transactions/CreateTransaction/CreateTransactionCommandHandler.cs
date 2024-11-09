using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Transactions;

using FluentValidation;

using Mapster;

using MediatR;

namespace Application.Transactions.CreateTransaction;
public class CreateTransactionCommandHandler(ITransactionRepository transactionRepository) 
	: IRequestHandler<CreateTransactionCommand, CreateTransactionCommandResponse>
{
	private readonly ITransactionRepository _transactionRepository = transactionRepository;

	public async Task<CreateTransactionCommandResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken = default)
	{
		var transaction = request.Adapt<Transaction>();

		await _transactionRepository.AddAsync(transaction);

		return new CreateTransactionCommandResponse(transaction.Id);
	}
}
