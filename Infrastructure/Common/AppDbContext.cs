using Domain.Shared;
using Domain.Transactions;
using Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<User> Users { get; set; }
	public DbSet<Transaction> Transactions { get; set; }

	//TODO: make context configurations
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		modelBuilder
			.Ignore<Money>();

		modelBuilder
			.Entity<TransactionCategory>(builder =>
			{
				builder
					.HasKey(e => e.Id);

				builder
					.Property(e => e.Name);

				builder
				.Property(e => e.TransactionType)
					.HasConversion<int>()
					.IsRequired();
			});

		modelBuilder
			.Entity<User>(builder =>
			{
				builder
					.HasKey(e => e.Id);

				builder
					.HasMany<Transaction>()
					.WithOne()
					.HasForeignKey(e => e.UserId)
					.IsRequired();

				builder
					.HasMany<Tag>()
					.WithOne()
					.HasForeignKey(e => e.UserId)
					.IsRequired();
			});

		modelBuilder
			.Entity<Transaction>(builder =>
			{
				builder
					.HasKey(x => x.Id);
				builder
					.Property(e => e.TransactionDate)
					.IsRequired();

				builder
					.HasOne(e => e.Category)
					.WithMany()
					.HasForeignKey(e => e.CategoryId);

				builder
					.Property(e => e.Type)
					.HasConversion<int>()
					.IsRequired();

				builder
					.ComplexProperty(e => e.Money)
					.IsRequired();

				builder
					.HasMany(e => e.Tags)
					.WithMany();
			});

		base.OnModelCreating(modelBuilder);
	}
}
