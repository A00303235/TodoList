using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoList.Models;

[ApiController]
[Route("[controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly DataContext _context;

    public ToDoItemsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItem>> GetAll()
    {
        return _context.ToDoItems.Where(t => t.FinishDate == null).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<ToDoItem> GetById(int id)
    {
        var item = _context.ToDoItems.Find(id);
        if (item == null) return NotFound();
        return item;
    }


    [HttpPost]
    public ActionResult<ToDoItem> Create(ToDoItem todoItem)
    {
        _context.ToDoItems.Add(todoItem);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = todoItem.TaskId }, todoItem);
    }

    [HttpPost("{id}/complete")]
    public IActionResult Complete(int id)
    {
        var item = _context.ToDoItems.Find(id);
        if (item == null) return NotFound();
        item.FinishDate = DateTime.Now;
        _context.SaveChanges();
        return NoContent();
    }


}
