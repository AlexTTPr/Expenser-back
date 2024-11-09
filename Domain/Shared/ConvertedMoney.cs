using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared;
public class ConvertedMoney : Money
{
    private decimal _convertedAmount;
    public decimal ConvertedAmount
    {
        get => _convertedAmount;
        init
        {
            if (value <= 0)
                throw new ArgumentException("Converted amount should be greater than 0", nameof(ConvertedAmount));
            _convertedAmount = value;
        }
    }

    private Currency _convertedCurrency;
    public Currency ConvertedCurrency
    {
        get => _convertedCurrency;
        set
        {
            if (value == Currency)
                throw new ArgumentException("Currencies should be different", nameof(Currency));
            _convertedCurrency = value;
        }
    }
}
