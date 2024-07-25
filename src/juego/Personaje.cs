using System;

namespace Proyecto
{
    public enum TipoPersonaje
    {
        Guerrero = 1,
        Caballero,
        Bandido,
        Clerigo,
        Marginado,
        Asesino,
        Hechicero
    }
    public class Personaje
    {
        public TipoPersonaje Tipo { get; set; }
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int Edad
        {
            get
            {
                DateTime hoy = DateTime.Today;
                int edad = hoy.Year - FechaDeNacimiento.Year;
                if (FechaDeNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }

        public int Velocidad { get; set; }
        public int Destreza { get; set; }
        public int Fuerza { get; set; }
        public int Nivel { get; set; }
        public int Armadura { get; set; }
        public int Salud { get; private set; } = 100;

        private static readonly Random random = new Random();

        public Personaje(TipoPersonaje tipo, string nombre, string apodo, DateTime fechaDeNacimiento)
        {
            Tipo = tipo;
            Nombre = nombre;
            Apodo = apodo;
            FechaDeNacimiento = fechaDeNacimiento;

            Velocidad = GenerarStats(1, 10);
            Destreza = GenerarStats(1, 10);
            Fuerza = GenerarStats(1, 10);
            Nivel = GenerarStats(1, 10);
            Armadura = GenerarStats(1, 10);
        }

        public static int GenerarStats(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}