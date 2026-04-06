namespace GestordeContactos.Models;

public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string? Empresa { get; set; }
    public string Telefono { get; set; } = string.Empty;
    public string? Puesto { get; set; }
    public string? Email { get; set; }
    public bool EsFavorito { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public string? Nota { get; set; }

    // Clave foránea
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = null!;
}