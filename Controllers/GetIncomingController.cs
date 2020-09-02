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
    public class GetIncomingController: ControllerBase
    {
        private readonly TodoDbContext _context;

        public GetIncomingController(TodoDbContext context)
        {
            _context = context;
        }

        //Get Incoming ToDo(for today/next day/current week)
        // GET: api/Todo/5
        [HttpGet()]
        public async Task<IActionResult> GetIncomingTodo([FromQuery] DateTime sDate, [FromQuery] DateTime eDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.Todos.Where(a=> a.Complete < 100 && sDate.Date >= a.CreatedOn.Date  && eDate.Date <= a.CreatedOn.Date).ToListAsync();

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

    }
}