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
        public int Salud { get; set; } = 100;

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

        public void Atacar(Personaje rival)
        {
            int ataque = Destreza * Fuerza * Nivel;
            int efectividad = random.Next(1, 101);
            int defensa = rival.Armadura * rival.Velocidad;
            const int constanteAjuste = 450;
            int danio = (ataque * efectividad - defensa) / constanteAjuste;

            if (danio < 0)
                danio = 0;

            if (rival.Salud - danio < 0)
                rival.Salud = 0;
            else
                rival.Salud -= danio;

            Console.WriteLine($"{rival.Nombre} ha recibido {danio} de danio");
            Console.WriteLine($"{rival.Nombre} tiene {rival.Salud} de salud");
            Console.WriteLine("--------------------------");
            Console.ReadKey();
        }
    }
}