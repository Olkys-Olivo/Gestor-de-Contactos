using Contaccase.Models;
using Contaccase.Database;

class ContacRepository(AppDbContext context) {
  private readonly AppDbContext _context = context;

  public List<ContacModel> SelectAll() {
    return _context.Contacts.ToList();
  }

  public int Delete(int ID_Contacto) {
    var contac = _context.Contacts.Find(ID_Contacto);

    if (contac is null) return 0;
    _context.Contacts.Remove(contac);
    return _context.SaveChanges();
  }

  public int Insert(string title, string year, string isbn) {
    var book = new BookModel { Title = title, Year = year, Isbn = isbn };
    _context.Books.Add(book);
    return _context.SaveChanges();
  }

  public int Update(string title, string year, string isbn, int id) {
    var book = _context.Books.Find(id);

    // Es porque el libro existe
    if (book is null) return 0;

    book.Title = title;
    book.Year = year;
    book.Isbn = isbn;

    return _context.SaveChanges();
  }
}
