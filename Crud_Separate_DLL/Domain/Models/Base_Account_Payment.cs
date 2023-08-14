using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Base_Account_Payment : CommonEntity
    {

        [Required]
        public string Name { get; set; }
    }
}
