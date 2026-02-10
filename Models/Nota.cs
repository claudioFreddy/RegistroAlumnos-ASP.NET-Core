using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RegistroAlumnos.Models
{
public class Nota
{
    public int Id { get; set; }

    [Range(1, 7)]
    public decimal Valor { get; set; }

    public int AlumnoId { get; set; }

    [ValidateNever]
    public Alumno Alumno { get; set; } = null!;

    public int CursoId { get; set; }
    [ValidateNever]
    public Curso Curso { get; set; } = null!;
}
}