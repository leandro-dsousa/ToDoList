using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using ToDoList.Models;

namespace ToDoList.Controllers.ToDoLists
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {

        private readonly ILogger<ToDoListController> _logger;

        public ToDoListController(ILogger<ToDoListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetToDoList")]
        public IEnumerable<ToDoListModel> GetToDoList()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("GetToDoListFromId/{id}")]

        public ToDoListDTO GetToDoListFromId([FromBody] string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("AddToDoListItem")]
        public int AddToDoListItem([FromBody] ToDoListModel toDoListItem)
        {
            return (int)toDoListItem.Id;
        }

        [HttpPost]
        [Route("EditToDoListItem")]
        public ToDoListModel EditToDoListItem([FromBody] string id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("DeleteToDoListItem/{id}")]
        public IEnumerable<ToDoListModel> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}