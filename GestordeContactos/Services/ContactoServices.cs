using GestordeContactos.Models;
using GestordeContactos.Repositories;

namespace GestordeContactos.Services;

public class ContactoService(ContactoRepository contactoRepository)
{
    private readonly ContactoRepository _contactoRepository = contactoRepository;

    public List<Contacto> ObtenerTodos()
    {
        return _contactoRepository.ObtenerTodos();
    }

    public List<Contacto> ObtenerFavoritos(bool esFavorito)
    {
        return _contactoRepository.ObtenerPorFavorito(esFavorito);
    }

    public List<Contacto> BuscarAvanzado(string query)
    {
        return _contactoRepository.Buscar(query);
    }

    public List<Categoria> ListarCategorias()
    {
        return _contactoRepository.ObtenerCategorias();
    }

    public int Crear(Contacto contacto)
    {
        return _contactoRepository.Insertar(contacto);
    }

    public int Eliminar(int id)
    {
        return _contactoRepository.Eliminar(id);
    }

    public int Actualizar(Contacto contacto)
    {
        return _contactoRepository.Actualizar(contacto);
    }
}



