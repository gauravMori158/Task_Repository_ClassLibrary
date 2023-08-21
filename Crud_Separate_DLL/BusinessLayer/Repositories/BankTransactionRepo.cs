using AutoMapper;
using AutoMapperLayer.DTOs.BankAccount;
using AutoMapperLayer.DTOs.BankTransaction;
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
    public class BankTransactionRepo : IBankTransactionRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BankTransactionRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(BankTransactionDTO  bankTransactionDTO)
        {
            var bankTransaction = _mapper.Map<BankTransaction>(bankTransactionDTO);
            await _context.BankTransactions.AddAsync(bankTransaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccount(int id)
        {
            var bankTransaction = await _context.BankTransactions.FirstOrDefaultAsync(x => x.Id == id);
            _context.BankTransactions.Remove(bankTransaction);
            await _context.SaveChangesAsync();
        }

        public async Task<BankTransactionDTO> GetAccount(int? id)
        {
            var bankTransaction = await _context.BankTransactions.Include(x => x.Person).Include(x => x.PaymentMethod).FirstOrDefaultAsync(x => x.Id == id);
            var mappedTransaction = _mapper.Map<BankTransactionDTO>(bankTransaction);
            return mappedTransaction;

        }

        public async Task<IList<BankTransactionDTO>> GetAllAccount()
        {
            var TransactionList = await _context.BankTransactions.Include(x => x.Person).Include(x => x.PaymentMethod).ToListAsync();
            var mappedList = _mapper.Map<List<BankTransactionDTO>>(TransactionList);
            return mappedList;
        }

        public async Task<BankTransactionDTO> UpdateAccount(int id, BankTransactionDTO bankTransactionDTO)
        {
            var bankTransaction = await _context.BankTransactions.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(bankTransactionDTO, bankTransaction);
            await _context.SaveChangesAsync();
            return bankTransactionDTO;

        }
    }
}
