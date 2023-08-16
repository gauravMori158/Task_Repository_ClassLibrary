using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceLayer
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(GetPaymentMethods());
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            return new List<PaymentMethod>()
            {
                new PaymentMethod()
                {
                    Id = 1,
                    Name = "Cash"
                },
                new PaymentMethod()
                {
                    Id = 2,
                    Name = "Cheque"
                },
                new PaymentMethod()
                {
                    Id = 3,
                    Name = "NEFT"
                },
                new PaymentMethod()
                {
                    Id = 4,
                    Name = "RTGS"
                },
                new PaymentMethod()
                {
                    Id = 5,
                    Name = "Other"
                }
            };
        }

    }
}