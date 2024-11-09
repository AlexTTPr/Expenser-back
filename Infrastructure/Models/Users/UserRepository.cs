using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Users;

using Infrastructure.Common;

namespace Infrastructure.Models.Users;
internal class UserRepository(AppDbContext context) : GenericRepository<User, Guid>(context), IUserRepository
{
}
