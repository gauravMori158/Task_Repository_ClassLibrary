using AutoMapper;
using AutoMapperLayer.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MigrationLayer.Database;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class TransactionTypeRepo : ITransactionTypeRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TransactionTypeRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(AccountTypeDTO accountTypeDTO)
        {
            var accountType = _mapper.Map<AccountType>(accountTypeDTO);
            await _context.AccountTypes.AddAsync(accountType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteType(int id)
        {
            var accountType = await _context.AccountTypes.FirstOrDefaultAsync(x => x.Id == id);
            _context.AccountTypes.Remove(accountType);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<AccountTypeDTO>> GetAllType()
        {
            var accountTypeList = await _context.AccountTypes.ToListAsync();
            var mappedList = _mapper.Map<List<AccountTypeDTO>>(accountTypeList);
            return mappedList;
        }

        public async Task<AccountTypeDTO> GetType(int? id)
        {
            var accoutType = await _context.AccountTypes.FirstOrDefaultAsync(x => x.Id == id);
            var mappedMethod = _mapper.Map<AccountTypeDTO>(accoutType);
            return mappedMethod;

        }

        public async Task<AccountTypeDTO> UpdateType(int id, AccountTypeDTO accountTypeDTO)
        {
            var accountType = await _context.AccountTypes.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(accountTypeDTO, accountType);
            await _context.SaveChangesAsync();
            return accountTypeDTO;
        }
    }
}
