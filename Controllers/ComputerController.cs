using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class ComputerController : Controller 
{
    private readonly LabManagerContext _context;

    public ComputerController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Computers);
    }

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }

    public IActionResult Create ([FromForm] int id, [FromForm] string ram, [FromForm] string processor)
    {
        if(id !=0) 
        {
             _context.Computers.Add(new Computer (id, ram, processor));
            _context.SaveChanges();
        }
       
        return View();
    }

    public IActionResult Update (int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }

    [HttpPost]
     public IActionResult Update (int id, [FromForm] string ram, [FromForm] string processor)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        computer.Ram = ram;
        computer.Processor = processor;
    
        _context.Computers.Update(computer);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete (int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        _context.Computers.Remove(computer);
        _context.SaveChanges();

        return View(computer);
    }
}