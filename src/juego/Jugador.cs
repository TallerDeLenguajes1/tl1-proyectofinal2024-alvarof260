using System;

namespace Proyecto
{
    public class Jugador
    {
        public string Tipo { get; set; }
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

        public Jugador(string tipo, string nombre, string apodo, DateTime fechaDeNacimiento)
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

        public void MostrarJugador()
        {
            Console.WriteLine($"Bienvenido, {Nombre} ({Apodo})! Tu partida ha comenzado.");
            Console.WriteLine($"Fecha de Nacimiento: {FechaDeNacimiento.ToShortDateString()}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Velocidad: {Velocidad}");
            Console.WriteLine($"Destreza: {Destreza}");
            Console.WriteLine($"Fuerza: {Fuerza}");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Armadura: {Armadura}");
            Console.WriteLine($"Salud: {Salud}");
        }
    }
}