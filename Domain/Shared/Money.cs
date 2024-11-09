using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared;
public class Money
{
    private decimal _amount;
    public decimal Amount
    {
        get => _amount;
        init
        {
            if (value <= 0)
                throw new ArgumentException("Amount should be greater than 0", nameof(Amount));
            _amount = value;
        }
    }

    public Currency Currency { get; init; }
}
