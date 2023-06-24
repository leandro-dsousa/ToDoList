using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoListSQlite.Services.Interfaces;

namespace ToDoListSQlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListModelController : ControllerBase
    {
        private readonly IToDoListService _service;

        public ToDoListModelController(IToDoListService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListModel>>> GetToDoLists()
        {
          return await _service.GetToDoLists() ?? NotFound();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListModel>> GetToDoListModel(long id)
        {
          return await _service.GetToDoListModel(id) ?? NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoListModel(long id, ToDoListModel toDoListModel)
        {

            if (id != toDoListModel.Id)
            {
                return BadRequest();
            }

            var x = await _service.PutToDoListModel(id, toDoListModel);

            if (x.Value == null)
                return NotFound();
            else 
                return  NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoListModel>> PostToDoListModel(ToDoListModel toDoListModel)
        {
            try
            {
                var tag = await _service.PostToDoListModel(toDoListModel);

                return CreatedAtAction("GetToDoListModel", new { id = toDoListModel.Id }, toDoListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteToDoListModel(long id)
        {
            var x = await _service.DeleteToDoListModel(id);
            
            if (x == null)
                return NotFound();
            else
                return NoContent();
        }
    }
}
