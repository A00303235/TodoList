using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Tests
{
    public class ToDoItemTests
    {
        [Fact]
        public void Test_If_ToDoItem_Can_Be_Created()
        {
            var item = new ToDoItem { TaskId = 1, Description = "Test Task" };
            Assert.NotNull(item);
        }

        [Fact]
        public void Test_If_ToDoItem_Properties_Work()
        {
            var item = new ToDoItem { TaskId = 1, Description = "Test Task", DueDate = DateTime.Now };
            Assert.Equal("Test Task", item.Description);
            Assert.NotNull(item.DueDate);
        }

      
    }
}
