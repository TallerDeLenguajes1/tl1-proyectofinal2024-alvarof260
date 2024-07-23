using System;

namespace Proyecto
{
  public class Program
  {

    public static void Main()
    {
      Inicio();
    }

    public static void Inicio()
    {

      int opcion;
      string input;
      bool seleccionado;
      do
      {
        Console.Clear();
        //! TODO: TRATAR DE HACER CONTROL DE PARTIDAS SIN TERMINAR  
        Console.WriteLine("Bienvenidos a Conquista y Triunfa");
        Console.WriteLine("1 - Nueva Partida");
        Console.WriteLine("2 - Historial");
        Console.WriteLine("3 - Salir");
        input = Console.ReadLine();
        seleccionado = int.TryParse(input, out opcion);
      } while (!seleccionado || (opcion < 1 || opcion > 3));

      switch (opcion)
      {
        case 1:
          CrearPartida();
          break;
        case 2:
          //! FALTA HACER EL CONTROL DE PARTIDAS
          break;
        case 3:
          Console.WriteLine("Saliendo del juego...");
          Environment.Exit(0);
          break;
      }
    }

    public static void CrearPartida()
    {
      Console.WriteLine("Ingrese un nombre: ");
      string nombre = Console.ReadLine();

      Console.WriteLine("Ingrese un apodo:");
      string apodo = Console.ReadLine();

      DateTime fechaDeNacimiento;
      bool fechaValida = false;
      do
      {
        Console.WriteLine("Ingrese la fecha de nacimiento (dd/mm/yyyy)");
        string fechaInput = Console.ReadLine();
        fechaValida = DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaDeNacimiento);
        if (!fechaValida)
        {
          Console.WriteLine("Fecha inválida, por favor intenta de nuevo.");
        }
      } while (!fechaValida);

      Console.WriteLine("Eliga un tipo:");
      foreach (var tipo in Enum.GetValues(typeof(TipoPersonaje)))
      {
        Console.WriteLine($"{(int)tipo} - {tipo}");
      }

      TipoPersonaje tipoSeleccionado;
      bool tipoValido = false;
      do
      {
        string input = Console.ReadLine();
        tipoValido = Enum.TryParse(input, out tipoSeleccionado) && Enum.IsDefined(typeof(TipoPersonaje), tipoSeleccionado);
        if (!tipoValido)
        {
          Console.WriteLine("Tipo inválido, por favor intenta de nuevo.");
        }
      } while (!tipoValido);

      Personaje nuevoPersonaje = new Personaje(tipoSeleccionado, nombre, apodo, fechaDeNacimiento);

      Console.Clear();

      nuevoPersonaje.MostrarPersonaje();
      Console.ReadKey();

      List<Personaje> personajes;

      if (PersonajesJson.Existe("personajes.json"))
      {
        personajes = PersonajesJson.LeerPersonajes("personajes.json");
      }
      else
      {
        personajes = FabricaDePersonajes.ListaDePersonajes(8);
        PersonajesJson.GuardarPersonajes(personajes, "personajes.json");
      }

      foreach (var personaje in personajes)
      {
        personaje.MostrarPersonaje();
      }



      //! hacer la logica del combate
    }
  }
}