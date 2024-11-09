using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Shared;

namespace Domain.Transactions;
public interface ITransactionRepository : IRepository<Transaction, Guid>
{
}
