using AutoMapperLayer.DTOs;
using AutoMapperLayer.DTOs.BankTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IPaymentMethodRepo
    {
        Task Create(PaymentMethodDTO  paymentMethodDTO );
        Task<IList<PaymentMethodDTO>> GetAllMethod();
        Task<PaymentMethodDTO> GetMethod(int? id);
        Task<PaymentMethodDTO> UpdateMethod(int id, PaymentMethodDTO paymentMethodDTO);
        Task DeleteMethod(int id);
    }
}
