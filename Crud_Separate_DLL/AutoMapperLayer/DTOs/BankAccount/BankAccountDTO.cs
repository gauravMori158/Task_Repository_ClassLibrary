using AutoMapperLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperLayer.DTOs.BankAccount
{
    public class BankAccountDTO
    {
        public PersonDTO Person { get; set; }

        public int AccountTypeId { get; set; }  


        public long AccountNumber { get; set; }

        public DateTime OpeningDate { get; set; }


    }
}
