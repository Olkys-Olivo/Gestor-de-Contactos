using GestordeContactos.Models;
using GestordeContactos.Services;

namespace GestordeContactos.Screens;

public class MainScreen
{
    private readonly ContactoService _service;

    public MainScreen() => _service = new ContactoService();

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("CONTACTOS").Color(Color.DarkOrange));

            var opcion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[DarkOrange3]Seleccione una opción:[/]")
                    .AddChoices("Listar Todos", "Listar Favoritos", "Listar NO Favoritos", 
                                "Crear Contacto", "Buscar", "Eliminar", "Salir"));

            if (opcion == "Salir") break;

            ProcesarOpcion(opcion);
        }
    }

    private void ProcesarOpcion(string opcion)
    {
        switch (opcion)
        {
            case "Listar Todos":
                RenderTable(_service.ObtenerTodos(), "TODOS LOS CONTACTOS");
                break;
            case "Listar Favoritos":
                RenderTable(_service.ObtenerFavoritos(true), "MIS FAVORITOS ⭐");
                break;
            case "Listar NO Favoritos":
                RenderTable(_service.ObtenerFavoritos(false), "CONTACTOS REGULARES");
                break;
            case "Buscar":
                var query = AnsiConsole.Ask<string>("Ingrese nombre, tel o categoría:");
                RenderTable(_service.BuscarAvanzado(query), $"RESULTADOS PARA: {query}");
                break;
            case "Crear Contacto":
                MenuCrear();
                break;
            case "Eliminar":
                var id = AnsiConsole.Ask<int>("ID del contacto a eliminar:");
                _service.Eliminar(id);
                AnsiConsole.MarkupLine("[red]Contacto eliminado.[/]");
                Thread.Sleep(1000);
                break;
        }
    }

    private void RenderTable(IEnumerable<Contacto> contactos, string titulo)
    {
        var table = new Table().Title($"[DarkOrange3]{titulo}[/]");
        table.AddColumn("ID");
        table.AddColumn("Nombre");
        table.AddColumn("Teléfono");
        table.AddColumn("Categoría");
        table.AddColumn("Fav");

        foreach (var c in contactos)
        {
            table.AddRow(c.Id.ToString(), $"{c.Nombre} {c.Apellido}", c.Telefono, c.Categoria.Nombre, c.EsFavorito ? "[yellow]⭐[/]" : "");
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("\n[grey]Presione ENTER para volver al menú...[/]");
        Console.ReadLine();
    }

    private void MenuCrear()
    {
        var nombre = AnsiConsole.Ask<string>("Nombre:");
        var apellido = AnsiConsole.Ask<string>("Apellido:");
        var tel = AnsiConsole.Ask<string>("Teléfono:");
        
        var cats = _service.ListarCategorias().ToList();
        var cat = AnsiConsole.Prompt(
            new SelectionPrompt<Categoria>()
                .Title("Categoría:")
                .UseConverter(x => x.Nombre)
                .AddChoices(cats));

        _service.Crear(new Contacto { 
            Nombre = nombre, 
            Apellido = apellido, 
            Telefono = tel, 
            CategoriaId = cat.Id,
            EsFavorito = AnsiConsole.Confirm("¿Es favorito?")
        });
    }
}