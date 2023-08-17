using AutoMapper;
using AutoMapperLayer.DTOs.BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IBankAccountRepo 
    {
        Task Create(BankAccountDTO bankAccountDTO);
        Task<IList<BankAccountDTO>> GetAllAccount();
        Task<BankAccountDTO> GetAccount(int? id);
        Task<BankAccountDTO> UpdateAccount(int id,BankAccountDTO bankAccountDTO);
        Task DeleteAccount(int id);
    }
}
