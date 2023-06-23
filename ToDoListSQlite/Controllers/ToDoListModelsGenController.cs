using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoListSQlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListModelsGenController : ControllerBase
    {
        private readonly ToDoListContext _context;

        public ToDoListModelsGenController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: api/ToDoListModelsGen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListModel>>> GetToDoLists()
        {
          if (_context.ToDoLists == null)
          {
              return NotFound();
          }
            return await _context.ToDoLists.ToListAsync();
        }

        // GET: api/ToDoListModelsGen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListModel>> GetToDoListModel(long id)
        {
          if (_context.ToDoLists == null)
          {
              return NotFound();
          }
            var toDoListModel = await _context.ToDoLists.FindAsync(id);

            if (toDoListModel == null)
            {
                return NotFound();
            }

            return toDoListModel;
        }

        // PUT: api/ToDoListModelsGen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoListModel(long id, ToDoListModel toDoListModel)
        {
            if (id != toDoListModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoListModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoListModelsGen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoListModel>> PostToDoListModel(ToDoListModel toDoListModel)
        {
          if (_context.ToDoLists == null)
          {
              return Problem("Entity set 'ToDoListContext.ToDoLists'  is null.");
          }
            _context.ToDoLists.Add(toDoListModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoListModel", new { id = toDoListModel.Id }, toDoListModel);
        }

        // DELETE: api/ToDoListModelsGen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoListModel(long id)
        {
            if (_context.ToDoLists == null)
            {
                return NotFound();
            }
            var toDoListModel = await _context.ToDoLists.FindAsync(id);
            if (toDoListModel == null)
            {
                return NotFound();
            }

            _context.ToDoLists.Remove(toDoListModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoListModelExists(long id)
        {
            return (_context.ToDoLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
