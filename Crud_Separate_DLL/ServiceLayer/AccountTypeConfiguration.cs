using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.HasData(GetAccountTypes());//

        }

        private List<AccountType> GetAccountTypes()
        {
            return new List<AccountType> {
                new AccountType()
                {
                    Id = 1,
                    Name = "Liability"
                },
               new AccountType()
               {
                   Id = 2,
                   Name = "Asset"
               }
        };
        }
    }
}
