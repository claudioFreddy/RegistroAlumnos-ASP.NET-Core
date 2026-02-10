using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistroAlumnos.Data;
using RegistroAlumnos.Models;

namespace RegistroAlumnos.Controllers
{
    public class InscripcionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscripcionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inscripciones/Create
        public IActionResult Create(int cursoId)
        {
            var inscripcion = new Inscripcion
            {
                CursoId = cursoId
            };

            ViewData["AlumnoId"] = new SelectList(
            _context.Alumnos,
            "Id",
            "Nombre"
            );

            ViewData["CursoId"] = new SelectList(
            _context.Cursos.Where(c => c.Id == cursoId),
            "Id",
            "Nombre"
            );

            return View(inscripcion);
        }


        // POST: Inscripciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inscripcion inscripcion)
        {
            bool existe = await _context.Inscripciones
                .AnyAsync(i =>
                    i.AlumnoId == inscripcion.AlumnoId &&
                    i.CursoId == inscripcion.CursoId);

            if (existe)
            {
                ModelState.AddModelError("", "El alumno ya está inscrito en este curso.");
            }

            if (!ModelState.IsValid)
            {
                ViewData["AlumnoId"] = new SelectList(
                    _context.Alumnos,
                    "Id",
                    "Nombre",
                    inscripcion.AlumnoId
                );

                ViewData["CursoId"] = new SelectList(
                    _context.Cursos,
                    "Id",
                    "Nombre",
                    inscripcion.CursoId
                );

                return View(inscripcion);
            }

            _context.Inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Cursos", new { id = inscripcion.CursoId });
        }
    }
}
