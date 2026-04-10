using Contactocase.Models;
using Contactocase.Database;

class ContactoRepository(AppDbContext context)
{
  private readonly AppDbContext _context = context;

  public List<ContactoModel> SelectAll()
  {
    return _context.Contactos.ToList();
  }

  public int Delete(int ID_Contacto)
  {
    var contacto = _context.Contactos.Find(ID_Contacto);

    if (contacto is null) return 0;

    _context.Contactos.Remove(contacto);
    return _context.SaveChanges();
  }

  public int Insert(string Nombre, string Apellido, string? Empresa, string Telefono, string? Puesto, string? Gmail, bool Es_Favorito, string? Nota)
  {
    var contacto = new ContactoModel
    {
      Nombre = Nombre,
      Apellido = Apellido,
      Empresa = Empresa,
      Telefono = Telefono,
      Puesto = Puesto,
      Gmail = Gmail,
      Es_Favorito = Es_Favorito,
      Nota = Nota
    };

    _context.Contactos.Add(contacto);
    return _context.SaveChanges();
  }

  public int Update(string Nombre, string Apellido, string? Empresa, string Telefono, string? Puesto, string? Gmail, bool Es_Favorito, string Fecha_Creacion, string? Nota, int ID_Contacto)
  {
    var contacto = _context.Contactos.Find(ID_Contacto);

    if (contacto is null) return 0;

    contacto.Nombre = Nombre;
    contacto.Apellido = Apellido;
    contacto.Empresa = Empresa;
    contacto.Telefono = Telefono;
    contacto.Puesto = Puesto;
    contacto.Gmail = Gmail;
    contacto.Es_Favorito = Es_Favorito;
    contacto.Fecha_Creacion = Fecha_Creacion;
    contacto.Nota = Nota;

    return _context.SaveChanges();
  }
   public List<ContactoModel> Buscarnombre(string Nombre) {
    return _context.Contactos
      .Where(c => c.Nombre.Contains(Nombre))
      .ToList();
  }

  public List<ContactoModel> GetFavoritos() {
    return _context.Contactos
      .Where(c => c.Es_Favorito)
      .ToList();
  }

  public List<ContactoModel> GetNoFavoritos() {
    return _context.Contactos
      .Where(c => !c.Es_Favorito)
      .ToList();
  }
}