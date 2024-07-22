using System;

namespace Proyecto
{
    public class FabricaDePersonajes
    {
        private static readonly Random random = new Random();
        private static string[] nombresDisponibles = { "Pedro", "Radamel", "Fausto", "Maximiliano", "Hades", "Leonel", "Lucio", "Gerard" };
        private static string[] apodosDisponibles = { "El Bravo", "El Elfo", "El Enano", "El Portador", "El Gris", "La cobra", "El Toro", "El Rayo" };
        private static List<string> nombresUsados = new List<string>();
        private static List<string> apodosUsados = new List<string>();

        public static List<Jugador> ListaDePersonajes(int cantidad)
        {
            if (cantidad > nombresDisponibles.Length || cantidad > apodosDisponibles.Length)
            {
                throw new ArgumentException("La cantidad de personajes solicitados excede la cantidad de nombres, apodos o tipos disponibles.");
            }

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

            string nombre;
            do
            {
                nombre = nombresDisponibles[random.Next(nombresDisponibles.Length)];
            } while (nombresUsados.Contains(nombre));
            nombresUsados.Add(nombre);

            string apodo;
            do
            {
                apodo = apodosDisponibles[random.Next(apodosDisponibles.Length)];
            } while (apodosUsados.Contains(apodo));
            apodosUsados.Add(apodo);

            DateTime fechaDeNacimiento = GenerarFecha();
            return new Jugador(tipo, nombre, apodo, fechaDeNacimiento);
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