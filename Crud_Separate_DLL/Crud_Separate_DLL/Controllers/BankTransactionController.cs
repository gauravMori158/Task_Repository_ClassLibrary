using AutoMapperLayer.DTOs.BankAccount;
using AutoMapperLayer.DTOs.BankTransaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;

namespace Crud_Separate_DLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankTransactionController : ControllerBase
    {
        private readonly IBankTransactionRepo _repo;
        public BankTransactionController(IBankTransactionRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts(int? id)
        {
            if (id == null)
            {
                var list = await _repo.GetAllAccount();
                return Ok(list);
            }

            var account = await _repo.GetAccount(id);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(BankTransactionDTO bankTransactionDTO)
        {
            await _repo.Create(bankTransactionDTO);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAccount(int id, BankTransactionDTO bankTransactionDTO)
        {
            var result = await _repo.UpdateAccount(id, bankTransactionDTO);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _repo.DeleteAccount(id);
            return Ok();
        }
    }
}
