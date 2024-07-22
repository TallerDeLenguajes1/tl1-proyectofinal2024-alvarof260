using System;

namespace Proyecto
{
    public class FabricaDePersonajes
    {
        private static readonly Random random = new Random();

        public static List<Jugador> ListaDePersonajes(int cantidad)
        {
            List<Jugador> personajes = new List<Jugador>();
            for (int i = 0; i < cantidad; i++)
            {
                personajes.Add(CrearPersonaje());
            }
            return personajes;
        }

        public static Jugador CrearPersonaje()
        {
            var tipos = Enum.GetValues(typeof(TipoJugador));
            TipoJugador tipo = (TipoJugador)tipos.GetValue(random.Next(tipos.Length));
            string nombre = GenerarNombre();
            string apodo = GenerarApodo();
            DateTime fecha = GenerarFecha();

            Jugador personaje = new Jugador(tipo, nombre, apodo, fecha);
            return personaje;
        }

        public static string GenerarNombre()
        {
            string[] nombres = { "Pedro", "Radamel", "Fausto", "Maximiliano", "Hades", "Leonel", "Lucio", "Gerard" };
            return nombres[random.Next(nombres.Length)];
        }


        public static string GenerarApodo()
        {
            string[] apodo = { "El Bravo", "El Elfo", "El Enano", "El Portador", "El Gris", "La cobra", "El Toro", "El Rayo" };
            return apodo[random.Next(apodo.Length)];
        }

        public static DateTime GenerarFecha()
        {
            DateTime start = new DateTime(1950, 1, 1);
            DateTime end = new DateTime(1999, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}