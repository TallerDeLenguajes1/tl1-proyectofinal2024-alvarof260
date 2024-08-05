using System;

namespace Proyecto
{
  public class Program
  {

    public static string[] tipos = { "Guerrero", "Caballero", "Clerigo", "Asesino", "Hechicero", "Marginado", "Bandido", "Ladron" };
    public static async Task Main()
    {
      while (true)
      {

        //? todo: hacer que cuando termine la partida vuelva al menu.
        Console.Clear();
        // MENU PRINCIPAL
        Console.ForegroundColor = ConsoleColor.Magenta;
        string LogoAscii = @"
░█████╗░░█████╗░███╗░░██╗░██████╗░██╗░░░██╗██╗░██████╗████████╗░█████╗░  ██╗░░░██╗
██╔══██╗██╔══██╗████╗░██║██╔═══██╗██║░░░██║██║██╔════╝╚══██╔══╝██╔══██╗  ╚██╗░██╔╝
██║░░╚═╝██║░░██║██╔██╗██║██║██╗██║██║░░░██║██║╚█████╗░░░░██║░░░███████║  ░╚████╔╝░
██║░░██╗██║░░██║██║╚████║╚██████╔╝██║░░░██║██║░╚═══██╗░░░██║░░░██╔══██║  ░░╚██╔╝░░
╚█████╔╝╚█████╔╝██║░╚███║░╚═██╔═╝░╚██████╔╝██║██████╔╝░░░██║░░░██║░░██║  ░░░██║░░░
░╚════╝░░╚════╝░╚═╝░░╚══╝░░░╚═╝░░░░╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝  ░░░╚═╝░░░

████████╗██████╗░██╗██╗░░░██╗███╗░░██╗███████╗░█████╗░
╚══██╔══╝██╔══██╗██║██║░░░██║████╗░██║██╔════╝██╔══██╗
░░░██║░░░██████╔╝██║██║░░░██║██╔██╗██║█████╗░░███████║
░░░██║░░░██╔══██╗██║██║░░░██║██║╚████║██╔══╝░░██╔══██║
░░░██║░░░██║░░██║██║╚██████╔╝██║░╚███║██║░░░░░██║░░██║
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░╚═════╝░╚═╝░░╚══╝╚═╝░░░░░╚═╝░░╚═╝";

        Menu.LogoCentrado(LogoAscii);
        Console.ResetColor();
        int opcion = Menu.Menuu(["Jugar", "Ganadores", "Salir"]);

        // CONTROL DE OPCIONES
        switch (opcion)
        {
          case 1:
            await NuevaPartida();
            break;
          case 2:
            MostrarGanadores();
            break;
          case 3:
            Console.WriteLine("Saliendo del juego...");
            Environment.Exit(0);
            break;
        }
      }
    }

    public static async Task NuevaPartida()
    {
      // DATOS DEL PERSONAJE NUEVO
      Console.Clear();
      string nombre = ManejoDeEntrada.LeerEntrada("Ingrese un nombre: ");
      try
      {
        Genero genero = await ConsumirApi.GetGenderByNameAsync(nombre);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Probabilidad: {genero.Probability}");
        Console.WriteLine($"Genero:" + (genero.Gender == "male" ? "Masculino" : "Femenino"));
        Console.ResetColor();
      }
      catch (System.Exception)
      {
        Console.WriteLine("Error al consumir la API de Genderize.");
      }

      string apodo = ManejoDeEntrada.LeerEntrada("Ingrese un apodo: ");
      DateTime fechaDeNacimiento = ManejoDeEntrada.LeerFecha("Ingrese la Fecha de nacimiento: (dd/mm/yyyy)");
      int opcion = Menu.Menuu(tipos);

      string tipoSeleccionado = tipos[opcion];


      // CREAR PERSONAJE
      Personaje nuevoPersonaje = new Personaje(tipoSeleccionado, nombre, apodo, fechaDeNacimiento);

      Console.Clear();
      // metodo de personaje
      nuevoPersonaje.Mostrar();
      Console.ReadKey();

      // PERSONAJES RIVALES
      List<Personaje> personajes;

      // VERIFICAR SI EXISTE PERSONAJE RIVALES
      if (PersonajesJson.Existe("personajes.json"))
      {
        personajes = PersonajesJson.LeerPersonajes("personajes.json");
      }
      else
      {
        personajes = FabricaDePersonajes.ListaDePersonajes(8);
        PersonajesJson.GuardarPersonajes(personajes, "personajes.json");
      }

      Console.Clear();
      Console.WriteLine("Muestra de rivales:");
      foreach (var personaje in personajes)
      {
        personaje.Mostrar();
        Console.WriteLine("------------------------------");
        Console.ReadKey();
      }

      LogicaJuego.Partida(nuevoPersonaje, personajes);
    }

    public static void MostrarGanadores()
    {
      Console.Clear();
      List<Personaje> ganadores = HistorialJson.LeerGanadores("ganadores.json");
      if (ganadores.Count == 0)
      {
        Console.WriteLine("No hay ganadores aún.");
        Console.ReadKey();
        return;
      }

      Console.WriteLine("Ganadores:");
      foreach (var ganador in ganadores)
      {
        Console.WriteLine("------------------------------");
        ganador.Mostrar();
        Console.WriteLine("------------------------------");
      }
      Console.ReadKey();
    }
  }

}