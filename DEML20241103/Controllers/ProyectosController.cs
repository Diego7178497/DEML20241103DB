using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DEML20241103.Models;

namespace DEML20241103.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly DEML20241103Context _context;

        public ProyectosController(DEML20241103Context context)
        {
            _context = context;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index()
        {
              return _context.Proyectos != null ? 
                          View(await _context.Proyectos.ToListAsync()) :
                          Problem("Entity set 'DEML20241103Context.Proyectos'  is null.");
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .Include(s => s.DetProyectos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            var proyecto = new Proyecto();
            proyecto.FechaInicial = DateTime.Now;
            proyecto.DetProyectos = new List<DetProyecto>();
            proyecto.DetProyectos.Add(new DetProyecto
            {

                Orden = 1,
                
            });
            ViewBag.Accion = "Create";
            return View (proyecto);
        }

        // POST: Proyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,FechaInicial,DetProyectos")] Proyecto proyecto)
        {
             _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          
        }
        [HttpPost]
        public ActionResult AgregarDetalles([Bind("Id,Nombre,Descripcion,FechaInicial,DetProyectos")] Proyecto proyecto, string accion)
        {
            proyecto.DetProyectos.Add(new DetProyecto { Orden = 1 });
            ViewBag.Accion = accion;
            return View(accion, proyecto);
        }
        public ActionResult EliminarDetalles([Bind("Id,Nombre,Descripcion,FechaInicial,DetProyectos")] Proyecto proyecto,
            int index, string accion)
        {
            var det = proyecto.DetProyectos[index];
            if (accion == "Edit" && det.Id > 0)
            {
                det.Id = det.Id * -1;
            }
            else
            {
                proyecto.DetProyectos.RemoveAt(index);
            }

            ViewBag.Accion = accion;
            return View(accion, proyecto);
        }

        // GET: Proyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
             .Include(s => s.DetProyectos)
              .FirstAsync(s => s.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FechaInicial,DetProyecto")] Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var proyectoUpdate = await _context.Proyectos
                       .Include(s => s.DetProyectos)
                       .FirstAsync(s => s.Id == proyecto.Id);
                    var detNew = proyecto.DetProyectos.Where(s => s.Id == 0);
                    foreach (var d in detNew)
                    {
                        proyectoUpdate.DetProyectos.Add(d);
                    }
                    var detUpdate = proyecto.DetProyectos.Where(s => s.Id > 0);
                    foreach (var d in detUpdate)
                    {
                        var det = proyectoUpdate.DetProyectos.FirstOrDefault(s => s.Id == d.Id);
                        det.Tarea = d.Tarea;
                        det.Orden = d.Orden;
                    }
                    var delDet = proyecto.DetProyectos.Where(s => s.Id < 0);
                    foreach (var d in delDet)
                    {
                        d.Id = d.Id * -1;
                        var det = proyectoUpdate.DetProyectos.FirstOrDefault(s => s.Id == d.Id);
                        proyectoUpdate.DetProyectos.Remove(det);
                    }
                    _context.Update(proyectoUpdate);
                    await _context.SaveChangesAsync();
                
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectoExists(proyecto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // GET: Proyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proyectos == null)
            {
                return Problem("Entity set 'DEML20241103Context.Proyectos'  is null.");
            }
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(int id)
        {
          return (_context.Proyectos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
