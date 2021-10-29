using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCallApi.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The name is less 50")]
        public string name { get; set; }
        public string email { get; set; }

    }
}
