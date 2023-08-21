using AutoMapperLayer.DTOs.BankAccount;
using AutoMapperLayer.DTOs.BankTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IBankTransactionRepo
    {
        Task Create(BankTransactionDTO bankTransactionDTO);
        Task<IList<BankTransactionDTO>> GetAllAccount();
        Task<BankTransactionDTO> GetAccount(int? id);
        Task<BankTransactionDTO> UpdateAccount(int id, BankTransactionDTO bankAccountDTO);
        Task DeleteAccount(int id);
    }
}
