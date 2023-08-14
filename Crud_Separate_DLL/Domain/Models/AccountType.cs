using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AccountType : Base_Account_Payment
    {
        public ICollection<BankAccount> BankAccounts { get; set; }

    }
}
