﻿using System;

namespace Proyecto
{
  public class Program
  {

    public static void Main()
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
          NuevaPartida();
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

    public static void NuevaPartida()
    {
      // DATOS DEL PERSONAJE NUEVO
      Console.Clear();
      string nombre = ManejoDeEntrada.LeerEntrada("Ingrese un nombre: ");
      string apodo = ManejoDeEntrada.LeerEntrada("Ingrese un apodo: ");
      DateTime fechaDeNacimiento = ManejoDeEntrada.LeerFecha("Ingrese la Fecha de nacimiento: (dd/mm/yyyy)");
      TipoPersonaje tipoSeleccionado = Menu.MenuTipo();


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
        ganador.Mostrar();
      }
      Console.ReadKey();
    }
  }

}