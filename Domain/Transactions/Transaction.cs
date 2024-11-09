using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Shared;

namespace Domain.Transactions;
public class Transaction : BaseEntity<Guid>
{
	public Guid UserId { get; init; }

	public DateTime TransactionDate { get; private set; }
	public Money Money { get; private set; }

	public TransactionType Type { get; init; }

	//NOTE: different for income or expense
	private TransactionCategory _category;
	public TransactionCategory Category
	{
		get => _category;
		init
		{
			if(value.TransactionType == _category.TransactionType)
				_category = value;
		}
	}

	private IList<Tag> _tags;
	public IReadOnlyCollection<Tag> Tags
	{
		get => _tags.AsReadOnly();
	}

	//TODO: add Note class
	public string Note { get; set; }

	public Transaction(DateTime transactionDate, TransactionType type, TransactionCategory category, Money money, IList<Tag> tags, string note)
		: base(Guid.NewGuid())
	{
		TransactionDate = transactionDate;
		Type = type;
		Category = category;
		Money = money;
		_tags = tags;
		Note = note;
	}

	//NOTE: should i really use these factory methods? I'd delay answering that question
	//public static Transaction CreateMultiCurrencyTransaction(Guid userId, DateTime transactionDate, ConvertedMoney money, IList<Tag> tags, string note)
	//{
	//    return new Transaction(userId, transactionDate, money, tags, note);
	//}

	//public static Transaction Create(Guid userId, DateTime transactionDate, Money money, IList<Tag> tags, string note)
	//{
	//    return new Transaction(userId, transactionDate, money, tags, note);
	//}

	public void AddTag(Tag tag)
	{
		if(!_tags.Contains(tag))
			_tags.Add(tag);
	}

	public void RemoveTag(Tag tag)
	{
		_tags.Remove(tag);
	}
}
