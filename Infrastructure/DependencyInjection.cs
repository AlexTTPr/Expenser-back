using Domain.Transactions;

using Infrastructure.Common;
using Infrastructure.Models.Transactions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddPersistence(configuration);

		return services;
	}

	private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(
			options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

		//NOTE: Add repositories
		services.AddScoped<ITransactionRepository, TransactionRepository>();

		return services;
	}
}
