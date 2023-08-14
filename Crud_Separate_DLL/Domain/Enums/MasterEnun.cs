using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum TransactionType
    {
        Credit = 1,
        Debit = 2
    }

    public enum Category
    {
        Opening_Balance = 1,
        Bank_Interest = 2,
        Bank_Charges = 3,
        Normal_Transactions = 4
    }
}
