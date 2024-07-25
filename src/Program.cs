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
      Console.Clear();
      //? MENU PRINCIPAL
      Menu.MenuPrincipal();
      int opcion = ManejoDeEntrada.LeerOpcionMenu();

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
      Mostrar.MostrarPersonaje(nuevoPersonaje);
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
        personajes = FabricaDePersonajes.ListaDePersonajes(1);
        PersonajesJson.GuardarPersonajes(personajes, "personajes.json");
      }

      foreach (var personaje in personajes)
      {
        Mostrar.MostrarPersonaje(personaje);
        Console.WriteLine();
      }

      //? TODO: hacer la logica del combate
      LogicaJuego.Partida(nuevoPersonaje, personajes);
    }
  }
}