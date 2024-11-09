using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Shared;

namespace Domain.Users;
public interface IUserRepository : IRepository<User, Guid>
{
}
