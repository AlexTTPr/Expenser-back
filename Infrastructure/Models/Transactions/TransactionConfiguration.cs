using Domain.Transactions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Transactions;
internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
	public void Configure(EntityTypeBuilder<Transaction> builder)
	{
		//builder
		//	.HasKey(x => x.Id);

		//builder
		//	.HasOne(e => e.User)
		//	.WithMany(e => e.Transactions)
		//	.HasForeignKey(e => e.UserId);

		//builder
		//	.Property(e => e.TransactionDate);

		//builder
		//	.Property(e => e.Type)
		//	.HasConversion<int>();

		//builder
		//	.ComplexProperty(e => e.Money);

		//builder
		//	.ComplexProperty(e => e.Category);

		//builder
		//	.HasMany(e => e.Tags)
		//	.WithMany();
	}
}
