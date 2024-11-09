using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Transactions;

using Infrastructure.Common;
using Infrastructure.Models.Transactions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddPersistence();

		return services;
	}

	private static IServiceCollection AddPersistence(this IServiceCollection services)
	{
		services.AddDbContext<AppDbContext>(options => options.UseNpgsql());

		//NOTE: Add repositories
		services.AddScoped<ITransactionRepository, TransactionRepository>();

		return services;
	}
}
