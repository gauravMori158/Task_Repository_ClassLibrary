using AutoMapperLayer.DTOs;
using AutoMapperLayer.DTOs.BankTransaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;

namespace Crud_Separate_DLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodRepo _repo;
        public PaymentMethodController(IPaymentMethodRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts(int? id)
        {
            if (id == null)
            {
                var list = await _repo.GetAllMethod();
                return Ok(list);
            }

            var account = await _repo.GetMethod(id);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMethod(PaymentMethodDTO paymentMethodDTO)
        {
            await _repo.Create(paymentMethodDTO);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateMethod(int id, PaymentMethodDTO paymentMethodDTO)
        {
            var result = await _repo.UpdateMethod(id, paymentMethodDTO);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMethod(int id)
        {
            await _repo.DeleteMethod(id);
            return Ok();
        }
    }
}
