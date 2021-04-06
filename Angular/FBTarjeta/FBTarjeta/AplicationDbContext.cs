using FBTarjeta.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBTarjeta
{
    public class AplicationDbContext:DbContext
    {
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<CuentaCliente> CuentaCliente { get; set; }
        
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
