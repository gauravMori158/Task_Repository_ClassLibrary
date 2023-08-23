using AutoMapper;
using AutoMapperLayer.DTOs;
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
    public class PaymentMethodRepo : IPaymentMethodRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PaymentMethodRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(PaymentMethodDTO paymentMethodDTO)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodDTO);
            await _context.PaymentMethods.AddAsync(paymentMethod);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMethod(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == id);
            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();
        }

        public async Task<PaymentMethodDTO> GetMethod(int? id)
        {
            var paymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == id);
            var mappedMethod = _mapper.Map<PaymentMethodDTO>(paymentMethod);
            return mappedMethod;

        }

        public async Task<IList<PaymentMethodDTO>> GetAllMethod()
        {
            var paymentList = await _context.PaymentMethods.ToListAsync();
            var mappedList = _mapper.Map<List<PaymentMethodDTO>>(paymentList);
            return mappedList;
        }

        public async Task<PaymentMethodDTO> UpdateMethod(int id, PaymentMethodDTO paymentMethodDto )
        {
            var paymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(paymentMethodDto, paymentMethod);
            await _context.SaveChangesAsync();
            return paymentMethodDto;

        }
    }
}
