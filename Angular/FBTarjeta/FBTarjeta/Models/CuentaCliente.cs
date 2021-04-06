using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBTarjeta.Models
{
    public class CuentaCliente
    {
        public int Id { get; set; }
        [Required]
        public Cuenta Cuenta { get; set; }
        [Required]
        public Client Cliente { get; set; }
        [Required]
        public int Passwrod { get; set; }
        [Required]
        public int Dinero { get; set; } 
    }
}
