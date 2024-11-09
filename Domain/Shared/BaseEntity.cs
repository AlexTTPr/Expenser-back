using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared;
public class BaseEntity<TKey>
{
	public TKey Id { get; init; }

	//NOTE: not quite sure is it really necessary or not
	protected DateTime CreatedDateTime { get; init; }
	protected DateTime UpdatedDateTime { get; init; }
	protected bool IsDeleted { get; init; }

	//for EF
	protected BaseEntity() { }

	//UNDONE: consider using DateTimeProvider!!!
	public BaseEntity(TKey id)
	{
		Id = id;
		CreatedDateTime = DateTime.Now;
	}
	
	//NOTE: some features (e.g. domain events) to be added

	//lifet
}
