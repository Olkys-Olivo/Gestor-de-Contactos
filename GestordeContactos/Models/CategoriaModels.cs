namespace GestordeContactos.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    
    // Una categoría tiene muchos contactos
    public List<Contacto> Contactos { get; set; } = new();
}