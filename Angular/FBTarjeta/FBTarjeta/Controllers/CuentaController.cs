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
    public class CuentaController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public CuentaController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CuentaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCuentas = await _context.Cuenta.ToListAsync();
                return Ok(listCuentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// GET api/<CuentaController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CuentaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cuenta cuenta)
        {
            try
            {
                _context.Add(cuenta);
                await _context.SaveChangesAsync();
                return Ok(cuenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cuenta cuenta)
        {
            try
            {
                if (id != cuenta.Id)
                {
                    return NotFound();
                }

                _context.Update(cuenta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La cuenta fue modificada con exito" });
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
                var tarjeta = await _context.Cuenta.FindAsync(id);
                if (tarjeta == null)
                {
                    return NotFound();
                }
                _context.Cuenta.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La cuenta fue eliminada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
