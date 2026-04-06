global using Spectre.Console;
using GestordeContactos.Data;

using (var db = new AppDbContext())
{
    db.Database.EnsureCreated();
}

var screen = new MainScreen();
screen.Show();