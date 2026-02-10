using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RegistroAlumnos.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }

        public int AlumnoId { get; set; }

        [ValidateNever]
        public Alumno Alumno { get; set; } = null!;

        public int CursoId { get; set; }

        [ValidateNever]
        public Curso Curso { get; set; } = null!;

        public DateTime FechaInscripcion { get; set; } = DateTime.Now;
    }
}
