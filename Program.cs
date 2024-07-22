using System;

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
      //! TODO: TRATAR DE HACER CONTROL DE PARTIDAS SIN TERMINAR  
      Console.WriteLine("Bienvenidos a Conquista y Triunfa");
      Console.WriteLine("1 - Nueva Partida");
      Console.WriteLine("2 - Historial");
      Console.WriteLine("3 - Salir");
      input = Console.ReadLine();
      seleccionado = int.TryParse(input, out opcion);
      if (opcion < 1 || opcion > 3 || !seleccionado)
      {
        Console.WriteLine("Opcion no Valida!");
      }
    } while (!seleccionado || (opcion < 1 || opcion > 3));

    switch (opcion)
    {
      case 1:
        //! FALTA HACER EL JUEGO
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
}