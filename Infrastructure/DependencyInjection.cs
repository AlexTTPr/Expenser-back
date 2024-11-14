using Domain.Transactions;
using Domain.Users;

using Infrastructure.Common;
using Infrastructure.Models.Categories;
using Infrastructure.Models.Tags;
using Infrastructure.Models.Transactions;
using Infrastructure.Models.Users;

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
		services
			.AddScoped<IUserRepository, UserRepository>()
			.AddScoped<ITagRepository, TagRepository>()
			.AddScoped<ICategoryRepository, CategoryRepository>()
			.AddScoped<ITransactionRepository, TransactionRepository>();

		return services;
	}
}
