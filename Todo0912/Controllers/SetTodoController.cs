using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo0912.Data;
using Todo0912.Models;

namespace Todo0912.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetTodoController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public SetTodoController(TodoDbContext context)
        {
            _context = context;
        }

        //Set Percent Complete
        [HttpPut("{id}")]
        public async Task<IActionResult> SetPercent([FromRoute] int id, [FromQuery] int Percent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var setpercent = _context.Todos.Find(id);
            setpercent.Complete = Percent;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}