using System;

namespace Proyecto
{
    public enum TipoPersonaje
    {
        Guerrero,
        Caballero,
        Bandido,
        Clerigo,
        Marginado,
        Asesino,
        Hechicero
    }
    public class Personaje
    {
        public TipoPersonaje Tipo { get; }
        public string Nombre { get; }
        public string Apodo { get; }
        public DateTime FechaDeNacimiento { get; }
        public int Edad { get; }

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
            Edad = GenerarEdad(fechaDeNacimiento);

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

        public int GenerarEdad(DateTime FechaDeNacimiento)
        {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - FechaDeNacimiento.Year;
            if (FechaDeNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }

        // entero(salud restante del rival)
        public int Atacar(int armadura, int velocidad)
        {
            int ataque = Destreza * Fuerza * Nivel;
            int efectividad = random.Next(1, 101);
            int defensa = armadura * velocidad;
            const int constanteAjuste = 500;
            int danio = (ataque * efectividad - defensa) / constanteAjuste;

            if (danio < 0)
                danio = 0;

            return danio;
        }

        public void Mostrar()
        {
            Console.WriteLine($"{Nombre} ({Apodo})");
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


        public void RecibirDanio(int danio)
        {
            if (Salud - danio <= 0)
                Salud = 0;
            else
                Salud -= danio;
        }

        public void MejorarEstadisticas()
        {
            Console.Clear();
            Console.WriteLine($"{Nombre} ({Apodo}) puede mejorar tus habilidades");
            Console.WriteLine("¿Que habilidad quieres mejorar?");

            int opcion;
            bool seleccionado = false;
            do
            {
                opcion = Menu.Menuu(new string[] { "Velocidad", "Destreza", "Nivel", "Armadura", "Fuerza" });
                switch (opcion)
                {
                    case 1:
                        if (Destreza < 10)
                        {
                            Destreza++;
                            seleccionado = true;
                        }
                        else
                        {
                            Console.WriteLine("No puedes mejorar más");
                            seleccionado = false;
                        }
                        break;
                    case 2:
                        if (Fuerza < 10)
                        {
                            Fuerza++;
                            seleccionado = true;

                        }
                        else
                        {
                            Console.WriteLine("No puedes mejorar más");
                            seleccionado = false;
                        }
                        break;
                    case 3:
                        if (Nivel < 10)
                        {
                            Nivel++;
                            Salud += 15;
                            seleccionado = true;

                        }
                        else
                        {
                            Salud += 20;
                            seleccionado = true;

                        }
                        break;
                    case 4:
                        if (Armadura < 10)
                        {
                            Armadura++;
                            seleccionado = true;

                        }
                        else
                        {
                            Console.WriteLine("No puedes mejorar más");
                            seleccionado = false;
                        }
                        break;
                    case 5:
                        if (Velocidad < 10)
                        {
                            Velocidad++;
                            seleccionado = true;

                        }
                        else
                        {
                            Console.WriteLine("No puedes mejorar más");
                            seleccionado = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            } while (!seleccionado);
        }
    }
}