using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CustomerDT
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="The name is less 50")]
        public string name { get; set; }
        public string email { get; set; }
    }
}