using System;

namespace EldenRing
{
  class Program
  {
    static void Main()
    {
      Task.Run(Start).GetAwaiter().GetResult();
    }

    static async Task Start()
    {
      Console.WriteLine("Bienvenido a Elden Ring RPG Console");
      // URL de la API de Elden Ring
      string apiUrl = "https://eldenring.fanapis.com/api/classes";

      // Crear una instancia de ApiClient
      var apiClient = new ApiClient(apiUrl);

      // Obtener datos de la API
      List<Datos> personajes = await apiClient.GetPersonajesAsync();
      string archivoJson = "personajes.json";
      JsonDB.GuardanEnJson(personajes, archivoJson);

      List<Datos> personajesGuardado = JsonDB.LeerEnJson(archivoJson);

      foreach (var personaje in personajesGuardado)
      {
        Console.WriteLine(personaje.Nombre);
      }

    }
  }
}