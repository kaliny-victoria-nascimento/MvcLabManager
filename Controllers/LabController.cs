using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LabController : Controller 
{
    private readonly LabManagerContext _context;

    public LabController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Labs);
    }

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    public IActionResult Create ([FromForm] int id, [FromForm] int number, [FromForm] string name, [FromForm] string block)
    {
        if(id !=0) 
        {
             _context.Labs.Add(new Lab (id, number, name, block));
            _context.SaveChanges();
        }

        return View();
    }

     public IActionResult Update (int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    [HttpPost]

     public IActionResult Update (int id, [FromForm] int number, [FromForm] string name, [FromForm] string block)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        lab.Number = number;
        lab.Name = name;
        lab.Block = block;

        _context.Labs.Update(lab);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete (int id)
    {
       Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        _context.Labs.Remove(lab);
        _context.SaveChanges();

        return View(lab);
    }
}