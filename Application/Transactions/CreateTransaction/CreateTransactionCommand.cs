using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Shared;
using Domain.Transactions;

using MediatR;

namespace Application.Transactions.CreateTransaction;
public record class CreateTransactionCommand(DateTime TransactionDate, TransactionType Type, TransactionCategory Category, Money Money, IList<Tag> Tags, string Note)
	: IRequest<CreateTransactionCommandResponse>;
