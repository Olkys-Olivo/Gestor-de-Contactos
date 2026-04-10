global using Spectre.Console;
using GestordeContactos.Data;
using GestordeContactos.Screens;

using (var db = new AppDbContext())
{
    db.Database.EnsureCreated();
}

var screen = new MainScreen();
screen.Show();