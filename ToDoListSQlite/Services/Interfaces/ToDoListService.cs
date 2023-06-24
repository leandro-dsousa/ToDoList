using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoListSQlite.Services.Interfaces
{
    public class ToDoListService : IToDoListService
    {

        private readonly ToDoListContext _context;

        public ToDoListService(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<ToDoListModel>?> DeleteToDoListModel(long id)
        {
            if (_context.ToDoLists == null)
            {
                return null;
            }
            var toDoListModel = await _context.ToDoLists.FindAsync(id);
            if (toDoListModel == null)
            {
                return null;
            }

            _context.ToDoLists.Remove(toDoListModel);
            await _context.SaveChangesAsync();

            return toDoListModel;
        }

        public async Task<ActionResult<ToDoListModel>> GetToDoListModel(long id)
        {

            var toDoListModel = await _context.ToDoLists.FindAsync(id);

            return toDoListModel;
        }

        public async Task<ActionResult<IEnumerable<ToDoListModel>>> GetToDoLists()
        {
            return await _context.ToDoLists.ToListAsync();
        }

        public async Task<ActionResult<ToDoListModel>> PostToDoListModel(ToDoListModel toDoListModel)
        {
            
            _context.ToDoLists.Add(toDoListModel);
            await _context.SaveChangesAsync();

            return toDoListModel;
        }

        public async Task<ActionResult<ToDoListModel>?> PutToDoListModel(long id, ToDoListModel toDoListModel)
        {
            
            _context.Entry(toDoListModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return toDoListModel;
        }

        private bool ToDoListModelExists(long id)
        {
            return (_context.ToDoLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
