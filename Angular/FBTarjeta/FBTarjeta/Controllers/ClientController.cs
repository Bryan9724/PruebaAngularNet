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
    public class ClientController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public ClientController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listClient = await _context.Client.ToListAsync();
                return Ok(listClient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClientController>/5 Revisar---------------------
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            try
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Client client)
        {
            try
            {
                if (id != client.Id)
                {
                    return NotFound();
                }

                _context.Update(client);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El cliente fue modificada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.Client.FindAsync(id);
                if (tarjeta == null)
                {
                    return NotFound();
                }
                _context.Client.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "el cliente fue eliminada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
