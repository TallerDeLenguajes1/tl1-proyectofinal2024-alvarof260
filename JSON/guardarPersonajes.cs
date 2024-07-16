using System;
using System.IO;
using System.Text.Json;

namespace EldenRing
{
    public static class JsonDB
    {
        public static void GuardanEnJson(List<Datos> personajes, string archivoJson)
        {
            string json = JsonSerializer.Serialize<List<Datos>>(personajes);
            File.WriteAllText(archivoJson, json);
        }

        public static List<Datos> LeerEnJson(string archivoJson)
        {
            string json = File.ReadAllText(archivoJson);
            return JsonSerializer.Deserialize<List<Datos>>(json);
        }
    }
}