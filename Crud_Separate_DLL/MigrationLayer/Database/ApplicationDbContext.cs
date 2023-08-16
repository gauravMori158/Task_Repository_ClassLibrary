using Domain.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationLayer.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());

        }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

    }
}
