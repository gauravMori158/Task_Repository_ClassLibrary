using AutoMapperLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ITransactionTypeRepo
    {
        Task Create(AccountTypeDTO accountTypeDTO);
        Task<IList<AccountTypeDTO>> GetAllType();
        Task<AccountTypeDTO> GetType(int? id);
        Task<AccountTypeDTO> UpdateType(int id, AccountTypeDTO  accountTypeDTO);
        Task DeleteType(int id);
    }
}
