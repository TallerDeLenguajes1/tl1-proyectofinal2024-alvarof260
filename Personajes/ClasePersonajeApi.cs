using System.Text.Json.Serialization;

namespace EldenRing
{
    public class Datos
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Nombre { get; set; }
        [JsonPropertyName("description")]
        public string Descripcion { get; set; }
        [JsonPropertyName("stats")]
        public Estadisticas Estadisticas { get; set; }
        public Datos(string Id, string Nombre, string Descripcion, Estadisticas Estadisticas)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Estadisticas = Estadisticas;
        }
    }

    public class Root
    {
        [JsonPropertyName("data")]
        public List<Datos> Datos { get; set; }
        public Root(List<Datos> Datos)
        {
            this.Datos = Datos;
        }
    }

    public class Estadisticas
    {
        [JsonPropertyName("level")]
        public string Nivel { get; set; }
        [JsonPropertyName("vigor")]
        public string Vigor { get; set; }
        [JsonPropertyName("mind")]
        public string Mente { get; set; }
        [JsonPropertyName("endurance")]
        public string Aguante { get; set; }
        [JsonPropertyName("strength")]
        public string Fuerza { get; set; }
        [JsonPropertyName("dexterity")]
        public string Destreza { get; set; }
        [JsonPropertyName("intelligence")]
        public string Inteligencia { get; set; }
        [JsonPropertyName("faith")]
        public string Fe { get; set; }
        [JsonPropertyName("arcane")]
        public string Arcano { get; set; }
        public Estadisticas(string Nivel, string Vigor, string Mente, string Aguante,
        string Fuerza, string Destreza, string Inteligencia, string Fe, string Arcano)
        {
            this.Nivel = Nivel;
            this.Vigor = Vigor;
            this.Mente = Mente;
            this.Aguante = Aguante;
            this.Fuerza = Fuerza;
            this.Destreza = Destreza;
            this.Inteligencia = Inteligencia;
            this.Fe = Fe;
            this.Arcano = Arcano;
        }
    }
}