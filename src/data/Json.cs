using System.IO;
using System.Text.Json;

namespace Proyecto
{
    public class PersonajesJson
    {
        public static void GuardarPersonajes(List<Personaje> ListaPersonaje, string nombreArchivo)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize<List<Personaje>>(ListaPersonaje);
                File.WriteAllText(nombreArchivo, jsonString);
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error al guardar personajes: {e.Message}");
                throw e;
            }
        }

        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            try
            {
                string jsonString = File.ReadAllText(nombreArchivo);
                return JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error al leer personajes: {e.Message}");
                throw e;
            }
        }

        public static bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }
}