using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBTarjeta.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string FistName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime brithDate { get; set; }
    }
}
