using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistroAlumnos.Data;
using RegistroAlumnos.Models;

namespace RegistroAlumnos.Controllers
{
    public class NotasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notas/Create
        public async Task<IActionResult> Create(int cursoId, int alumnoId)
        {
            var existe = await _context.Notas
                .AnyAsync(n => n.CursoId == cursoId && n.AlumnoId == alumnoId);

            if (existe)
            {
                return BadRequest("Este alumno ya tiene nota en este curso.");
            }

            var nota = new Nota
            {
                CursoId = cursoId,
                AlumnoId = alumnoId
            };

            ViewData["Alumno"] = await _context.Alumnos.FindAsync(alumnoId);
            ViewData["Curso"] = await _context.Cursos.FindAsync(cursoId);

            return View(nota);
        }

        // POST: Notas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nota nota)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Alumno"] = await _context.Alumnos.FindAsync(nota.AlumnoId);
                ViewData["Curso"] = await _context.Cursos.FindAsync(nota.CursoId);
                return View(nota);
            }

            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();

            return RedirectToAction(
                "Details",
                "Cursos",
                new { id = nota.CursoId }
            );
        }

        public async Task<IActionResult> Edit(int id)
        {
            var nota = await _context.Notas.FindAsync(id);
            if (nota == null) return NotFound();
            return View(nota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Nota nota)
        {
            if (id != nota.Id) return NotFound();

            if (!ModelState.IsValid)
            return View(nota);

            _context.Update(nota);
            await _context.SaveChangesAsync();

            return RedirectToAction(
            "Details",
            "Cursos",
            new { id = nota.CursoId }
            );
        }
    }
}

