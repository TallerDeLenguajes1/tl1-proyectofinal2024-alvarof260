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
      Console.WriteLine(personajes.ElementAt(1).Nombre);
    }
  }
}