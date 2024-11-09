using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Transactions;

using Infrastructure.Common;

namespace Infrastructure.Models.Transactions;
public class TransactionRepository(AppDbContext context) : GenericRepository<Transaction, Guid>(context), ITransactionRepository
{
}
