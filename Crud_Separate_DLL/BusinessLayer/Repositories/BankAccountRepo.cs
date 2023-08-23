using AutoMapper;
using AutoMapperLayer.DTOs.BankAccount;
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
    public class BankAccountRepo : IBankAccountRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BankAccountRepo(ApplicationDbContext context,IMapper mapper)
        {
                _context = context;
                _mapper = mapper;
        }
        public async Task Create(BankAccountDTO bankAccountDTO)
        {
            var bankAccount = _mapper.Map<BankAccount>(bankAccountDTO);
            await _context.BankAccounts.AddAsync(bankAccount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccount(int id)
        {
             var account = await _context.BankAccounts.FirstOrDefaultAsync(x => x.Id == id);
             _context.BankAccounts.Remove(account);
             await _context.SaveChangesAsync();
        }

        public async Task<BankAccountDTO> GetAccount(int? id)
        {
            var account = await _context.BankAccounts.Include(x => x.Person).Include(x => x.AccountType).FirstOrDefaultAsync(x => x.Id == id);
            var mappedAccount = _mapper.Map<BankAccountDTO>(account);
            return mappedAccount;

        }

        public async Task<IList<BankAccountDTO>> GetAllAccount()
        {
            var accountList = await _context.BankAccounts.Include(x=>x.Person).Include(x => x.AccountType).ToListAsync();
            var mappedList = _mapper.Map<List<BankAccountDTO>>(accountList);
            return mappedList;
        }

        public async Task<BankAccountDTO> UpdateAccount(int id,BankAccountDTO bankAccountDTO)
        {
            var account = await _context.BankAccounts.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map( bankAccountDTO,account);
            await _context.SaveChangesAsync();
            return bankAccountDTO;

        }
    }
}
