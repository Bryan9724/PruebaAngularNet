using FBTarjeta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBTarjeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaClienteController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public CuentaClienteController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TarjetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCuentaClient = await _context.CuentaCliente.Select(x => new { x.Id, x.Cuenta.NumeroCuenta, x.Cliente.FistName, x.Cliente.LastName, x.Dinero }).ToListAsync();
                return Ok(listCuentaClient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> Nombre()
        //{
        //    try
        //    {
        //        //
        //        var listCuentaClient = await _context.CuentaCliente.ToListAsync();
        //        return Ok(listCuentaClient);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // GET api/<TarjetaController>/5
        [HttpGet("{id},{password}")]
        public async Task<IActionResult> Get(int id, int password)
        {
            try
            {
                var cuentaClienteDB = await _context.CuentaCliente.FindAsync(id);
                if (cuentaClienteDB.Passwrod != password)
                {
                    return BadRequest(new { message = "Password invalido" });
                }
                return Ok(cuentaClienteDB);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CuentaCliente cuentaCliente)
        {
            try
            {
                _context.Add(cuentaCliente);
                await _context.SaveChangesAsync();
                return Ok(cuentaCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id},{operacion}")]
        public async Task<IActionResult> Put(int id, [FromBody] CuentaCliente cuentaCliente, int operacion)
        {
            try
            {
                var cuentaClienteDB = await _context.CuentaCliente.FindAsync(id);
                if (cuentaClienteDB == null)
                {
                    return NotFound();
                }

                if (cuentaClienteDB.Passwrod != cuentaCliente.Passwrod)
                {
                    return BadRequest(new { message = "Password invalido"});
                }
                if (operacion == 0)
                {
                    cuentaClienteDB.Dinero = cuentaCliente.Dinero + cuentaClienteDB.Dinero;
                }
                else
                {
                    if (cuentaClienteDB.Dinero < cuentaCliente.Dinero)
                    {
                        return BadRequest(new { message = "No puedes retirar mas de lo que tienes" });
                    }
                    cuentaClienteDB.Dinero =  cuentaClienteDB.Dinero - cuentaCliente.Dinero ;
                }
                
                _context.Update(cuentaClienteDB);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La cuenta cliente fue modificada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cuentaCliente = await _context.CuentaCliente.FindAsync(id);
                if (cuentaCliente == null)
                {
                    return NotFound();
                }
                _context.CuentaCliente.Remove(cuentaCliente);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La cuenta cliente fue eliminada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
