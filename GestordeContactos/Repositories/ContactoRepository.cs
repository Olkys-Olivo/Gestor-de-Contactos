using GestordeContactos.Data;
using GestordeContactos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestordeContactos.Repositories;

public class ContactoRepository
{
    public List<Contacto> ObtenerTodos()
    {
        using var db = new AppDbContext();
        return db.Contactos.Include(c => c.Categoria).ToList();
    }

    public List<Contacto> ObtenerPorFavorito(bool esFavorito)
    {
        using var db = new AppDbContext();
        return db.Contactos
            .Include(c => c.Categoria)
            .Where(c => c.EsFavorito == esFavorito)
            .ToList();
    }

    public List<Contacto> Buscar(string query)
    {
        using var db = new AppDbContext();
        if (string.IsNullOrWhiteSpace(query))
        {
            return ObtenerTodos();
        }

        query = query.Trim().ToLowerInvariant();

        return db.Contactos
            .Include(c => c.Categoria)
            .Where(c => c.Nombre.ToLower().Contains(query)
                     || c.Apellido.ToLower().Contains(query)
                     || c.Telefono.ToLower().Contains(query)
                     || c.Email != null && c.Email.ToLower().Contains(query)
                     || c.Puesto != null && c.Puesto.ToLower().Contains(query)
                     || c.Empresa != null && c.Empresa.ToLower().Contains(query)
                     || c.Categoria.Nombre.ToLower().Contains(query))
            .ToList();
    }

    public List<Categoria> ObtenerCategorias()
    {
        using var db = new AppDbContext();

        if (!db.Categorias.Any())
        {
            db.Categorias.AddRange(
                new Categoria { Nombre = "Personal", Descripcion = "Contactos personales" },
                new Categoria { Nombre = "Trabajo", Descripcion = "Contactos laborales" },
                new Categoria { Nombre = "Familia", Descripcion = "Contactos familiares" }
            );
            db.SaveChanges();
        }

        return db.Categorias.ToList();
    }

    public int Insertar(Contacto contacto)
    {
        using var db = new AppDbContext();
        db.Contactos.Add(contacto);
        return db.SaveChanges();
    }

    public int Eliminar(int id)
    {
        using var db = new AppDbContext();
        var contacto = db.Contactos.Find(id);
        if (contacto == null)
        {
            return 0;
        }

        db.Contactos.Remove(contacto);
        return db.SaveChanges();
    }

    public int Actualizar(Contacto contacto)
    {
        using var db = new AppDbContext();
        var existente = db.Contactos.Find(contacto.Id);
        if (existente == null)
        {
            return 0;
        }

        existente.Nombre = contacto.Nombre;
        existente.Apellido = contacto.Apellido;
        existente.Empresa = contacto.Empresa;
        existente.Telefono = contacto.Telefono;
        existente.Puesto = contacto.Puesto;
        existente.Email = contacto.Email;
        existente.EsFavorito = contacto.EsFavorito;
        existente.Nota = contacto.Nota;
        existente.CategoriaId = contacto.CategoriaId;

        return db.SaveChanges();
    }
}
