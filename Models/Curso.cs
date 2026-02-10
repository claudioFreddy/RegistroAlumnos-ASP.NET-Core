using System.ComponentModel.DataAnnotations;

namespace RegistroAlumnos.Models
{
public class Curso
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

    public ICollection<Nota> Notas { get; set; } = new List<Nota>();
}
}