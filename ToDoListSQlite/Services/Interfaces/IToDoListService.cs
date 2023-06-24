using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoListSQlite.Services.Interfaces
{
    public interface IToDoListService
    {

        Task<ActionResult<IEnumerable<ToDoListModel>>> GetToDoLists();


        Task<ActionResult<ToDoListModel>> GetToDoListModel(long id);

        Task<ActionResult<ToDoListModel>> PutToDoListModel(long id, ToDoListModel toDoListModel);

        Task<ActionResult<ToDoListModel>> PostToDoListModel(ToDoListModel toDoListModel);

        Task<ActionResult<ToDoListModel>> DeleteToDoListModel(long id);

    }
}
