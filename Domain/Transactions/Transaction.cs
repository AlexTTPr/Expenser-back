﻿using Domain.Shared;

namespace Domain.Transactions;
public class Transaction : BaseEntity<Guid>
{
	public Guid UserId { get; init; }

	public DateTime TransactionDate { get; set; }
	public Money Money { get; set; }

	public TransactionType Type { get; set; }

	//NOTE: different for income or expense
	public Guid CategoryId { get; init; }
	private TransactionCategory _category;
	public TransactionCategory Category
	{
		get => _category;
		set
		{
			if(value.TransactionType == Type)
				_category = value;
		}
	}

	private IList<Tag> _tags = [];
	public IReadOnlyCollection<Tag> Tags
	{
		get => _tags.AsReadOnly();
	}

	protected Transaction() { } //NOTE: For EF

	public Transaction(Guid userId, DateTime transactionDate, TransactionType type, TransactionCategory category, Money money, IList<Tag> tags)
		: base(Guid.NewGuid())
	{
		UserId = userId;
		TransactionDate = transactionDate;
		Type = type;
		Category = category;
		CategoryId = category.Id;
		Money = money;
		_tags = tags;
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
