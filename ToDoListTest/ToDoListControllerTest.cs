using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using ToDoList.Models;
using ToDoListSQlite.Controllers;
using ToDoListSQlite.Services.Interfaces;

namespace ToDoListTest
{
    public class ToDoListControllerTest
    {
        private readonly Mock<IToDoListService> toDoListService;
        public ToDoListControllerTest()
        {
            toDoListService = new Mock<IToDoListService>();
        }

        [Fact]
        public async void GetToDoListsTest()
        {
            var toDoLists = ToDoLists();
            toDoListService.Setup(x => x.GetToDoLists()).ReturnsAsync(toDoLists);
            var controller = new ToDoListModelController(toDoListService.Object);
            var res = await controller.GetToDoLists();
            Assert.True(toDoLists == res.Value);
        }

        [Fact]
        public async void GetToDoListModelByIdTest()
        {
            var toDoList = ToDoLists().Where(x => x.Id == 1).FirstOrDefault();
            toDoListService.Setup(x => x.GetToDoListModel(1)).ReturnsAsync(toDoList);
            var controller = new ToDoListModelController(toDoListService.Object);
            var res = await controller.GetToDoListModel(1);
            Assert.True(toDoList == res.Value);
        }

        [Fact]
        public async void PutToDoListModelTest_NoContent()
        {
            ToDoListModel model = new ToDoListModel()
            {
                Id = 1,
                Title = "Test1",
                Description = "Test2",
                AddedOn = DateTime.Now.ToShortDateString(),
                DueDate = DateTime.Now.ToShortDateString()
            };

            var toDoList = ToDoLists();

            toDoListService.Setup(x => x.PutToDoListModel(1, model)).ReturnsAsync(model);
            var controller = new ToDoListModelController(toDoListService.Object);
            var res = await controller.PutToDoListModel(1, model);
            Assert.True((int)res.GetType().GetProperty("StatusCode").GetValue(res) == 204);
        }

        [Fact]
        public async void PutToDoListModelTest_BadRequest()
        {
            ToDoListModel model = new ToDoListModel()
            {
                Id = 7,
                Title = "Test7",
                Description = "Test7",
                AddedOn = DateTime.Now.ToShortDateString(),
                DueDate = DateTime.Now.ToShortDateString()
            };

            var toDoList = ToDoLists();

            toDoListService.Setup(x => x.PutToDoListModel(4, model)).ReturnsAsync(new BadRequestResult());
            var controller = new ToDoListModelController(toDoListService.Object);
            var res = await controller.PutToDoListModel(4, model);
            Assert.True((int)res.GetType().GetProperty("StatusCode").GetValue(res) == 400);
        }

        [Fact]
        public async void PutToDoListModelTest_NotFound()
        {
            ToDoListModel model = new ToDoListModel()
            {
                Id = 7,
                Title = "Test7",
                Description = "Test7",
                AddedOn = DateTime.Now.ToShortDateString(),
                DueDate = DateTime.Now.ToShortDateString()
            };

            var toDoList = ToDoLists();

            toDoListService.Setup(x => x.PutToDoListModel(7, model)).ReturnsAsync(value: null as ToDoListModel);
            var controller = new ToDoListModelController(toDoListService.Object);
            var res = await controller.PutToDoListModel(7, model);
            Assert.True((int)res.GetType().GetProperty("StatusCode").GetValue(res) == 404);
        }

        [Fact]
        public async void PostToDoListModelTest()
        {
            ToDoListModel model = new ToDoListModel()
            {
                Id = 4,
                Title = "Test4",
                Description = "Test4",
                AddedOn = DateTime.Now.ToShortDateString(),
                DueDate = DateTime.Now.ToShortDateString()
            };

            var toDoList = ToDoLists();

            toDoListService.Setup(x => x.PostToDoListModel(model)).ReturnsAsync(model);
            var controller = new ToDoListModelController(toDoListService.Object);
            var res = await controller.PostToDoListModel(model);
            var x =(int)res.GetType().GetProperty("Result").GetValue(res).GetType().GetProperty("StatusCode").GetValue(res.GetType().GetProperty("Result").GetValue(res));
            Assert.True(x == 201);
        }

        [Fact]
        public async void DeleteToDoListModelTest()
        {
            ToDoListModel model = new ToDoListModel()
            {
                Id = 1,
                Title = "Test1",
                Description = "Test1",
                AddedOn = DateTime.Now.ToShortDateString(),
                DueDate = DateTime.Now.ToShortDateString()
            };

            toDoListService.Setup(x => x.DeleteToDoListModel(1)).ReturnsAsync(model);
            var controller = new ToDoListModelController(toDoListService.Object);
            var res = await controller.DeleteToDoListModel(1);
            Assert.True((int)res.GetType().GetProperty("StatusCode").GetValue(res) == 204);
        }

        private List<ToDoListModel> ToDoLists()
        {
            return new List<ToDoListModel>
            {
                new ToDoListModel {
                    Id = 1,
                    Title= "Test1",
                    Description = "Test1",
                    AddedOn = DateTime.Now.ToShortDateString(),
                    DueDate = DateTime.Now.ToShortDateString()
                },
                new ToDoListModel {
                    Id = 2,
                    Title= "Test2",
                    Description = "Test2",
                    AddedOn = DateTime.Now.ToShortDateString(),
                    DueDate = DateTime.Now.ToShortDateString()
                },
                new ToDoListModel {
                    Id = 3,
                    Title= "Test3",
                    Description = "Test3",
                    AddedOn = DateTime.Now.ToShortDateString(),
                    DueDate = DateTime.Now.ToShortDateString()
                }
            };
        }
    }
}