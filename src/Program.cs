using System;

namespace Proyecto
{
  public class Program
  {

    public static void Main()
    {
      //? todo: hacer que cuando termine la partida vuelva al menu.
      Console.Clear();
      //? MENU PRINCIPAL
      int opcion = Menu.MenuPrincipal();

      //? CONTROL DE OPCIONES
      switch (opcion)
      {
        case 1:
          NuevaPartida();
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

    public static void NuevaPartida()
    {
      //? DATOS DEL PERSONAJE NUEVO
      string nombre = ManejoDeEntrada.LeerEntrada("Ingrese un nombre: ");
      string apodo = ManejoDeEntrada.LeerEntrada("Ingrese un apodo: ");
      DateTime fechaDeNacimiento = ManejoDeEntrada.LeerFecha("Ingrese la Fecha de nacimiento: (dd/mm/yyyy)");
      Mostrar.MostrarTipos();
      TipoPersonaje tipoSeleccionado = ManejoDeEntrada.LeerTipo();

      //? CREAR PERSONAJE
      Personaje nuevoPersonaje = new Personaje(tipoSeleccionado, nombre, apodo, fechaDeNacimiento);

      Console.Clear();
      // metodo de personaje
      nuevoPersonaje.Mostrar();
      Console.ReadKey();

      //? PERSONAJES RIVALES
      List<Personaje> personajes;

      //? VERIFICAR SI EXISTE PERSONAJE RIVALES
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
        personaje.Mostrar();
        Console.WriteLine();
      }

      //? TODO: hacer la logica del combate
      LogicaJuego.Partida(nuevoPersonaje, personajes);
    }
  }
}