using AutoMapperLayer.DTOs.BankAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Crud_Separate_DLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountRepo _repo;
        public BankAccountController(IBankAccountRepo repo)
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
        public async Task<IActionResult> CreateAccount(BankAccountDTO bankAccountDTO)
        {
            await _repo.Create(bankAccountDTO);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAccount(int id, BankAccountDTO bankAccountDTO)
        {
            var result = await _repo.UpdateAccount(id, bankAccountDTO);
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
