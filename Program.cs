using System;

namespace EldenRing
{
  class Program
  {
    static void Main()
    {
      Start();
    }

    static void Start()
    {
      Console.WriteLine("Bienvenido a Elden Ring RPG Console");
      Console.WriteLine("Elija su personaje");
      Estadisticas stats = new Estadisticas(
                Nivel: "10",
                Vigor: "20",
                Mente: "15",
                Aguante: "18",
                Fuerza: "22",
                Destreza: "19",
                Inteligencia: "14",
                Fe: "12",
                Arcano: "16"
            );

      Datos datos = new Datos(
          Id: "001",
          Nombre: "Guerrero",
          Descripcion: "Un valiente guerrero con gran fuerza y Aguante.",
          Estadisticas: stats
      );

      Personaje personaje = new Personaje(datos);

      Console.WriteLine($"Nombre: {personaje.Datos.Nombre}");
      Console.WriteLine($"Descripción: {personaje.Datos.Descripcion}");
      Console.WriteLine("Estadísticas:");
      Console.WriteLine($"  Nivel: {personaje.Datos.Estadisticas.Nivel}");
      Console.WriteLine($"  Vigor: {personaje.Datos.Estadisticas.Vigor}");
      Console.WriteLine($"  Mente: {personaje.Datos.Estadisticas.Mente}");
      Console.WriteLine($"  Aguante: {personaje.Datos.Estadisticas.Aguante}");
      Console.WriteLine($"  Fuerza: {personaje.Datos.Estadisticas.Fuerza}");
      Console.WriteLine($"  Destreza: {personaje.Datos.Estadisticas.Destreza}");
      Console.WriteLine($"  Inteligencia: {personaje.Datos.Estadisticas.Inteligencia}");
      Console.WriteLine($"  Fe: {personaje.Datos.Estadisticas.Fe}");
      Console.WriteLine($"  Arcano: {personaje.Datos.Estadisticas.Arcano}");
    }
  }
}