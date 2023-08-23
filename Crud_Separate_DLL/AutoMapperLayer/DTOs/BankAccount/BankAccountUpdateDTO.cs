﻿using System.ComponentModel.DataAnnotations;

namespace AutoMapperLayer.DTOs.BankAccount
{
    public class BankAccountUpdateDTO
    {
        public PersonDTO Person { get; set; }

        public int AccountTypeId { get; set; }
        DateTime ClosingDate { get; set; }

    }
}
