namespace Proyecto
{
    public class LogicaJuego
    {
        public static void Partida(Personaje jugador, List<Personaje> rivales)
        {
            Console.Clear();
            foreach (var rival in rivales)
            {
                Combate(jugador, rival);

                if (jugador.Salud <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Has Perdido");
                    Console.WriteLine("Gracias por jugar");
                    Console.WriteLine("Pulsa cualquier tecla para salir");
                    Console.WriteLine("--------------------------");
                    Console.ReadKey();
                    break;
                }
            }
            if (jugador.Salud > 0)
            {
                Console.Clear();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Has Ganado");
                Console.WriteLine("Gracias por jugar");
                Console.WriteLine("Pulsa cualquier tecla para salir");
                Console.WriteLine("--------------------------");
                HistorialJson.GuardarGanador(jugador, "ganadores.json");
                Console.ReadKey();
            }
            PersonajesJson.BorrarArchivo("personajes.json");
        }

        public static void Combate(Personaje jugador, Personaje rival)
        {
            int saludInicial = jugador.Salud;
            int danio;
            Console.WriteLine("Combate entre " + jugador.Nombre + " y " + rival.Nombre);

            while (jugador.Salud > 0 && rival.Salud > 0)
            {
                jugador.Mostrar();
                Console.WriteLine("--------------------------");
                rival.Mostrar();
                Console.WriteLine("Turno de " + jugador.Nombre);

                danio = jugador.Atacar(rival.Armadura, rival.Velocidad);
                rival.RecibirDanio(danio);

                if (rival.Salud <= 0)
                {
                    Console.WriteLine($"{rival.Nombre} ha sido derrotado");
                    break;
                }
                Console.ReadKey();

                Console.WriteLine("Turno de " + rival.Nombre);

                danio = rival.Atacar(jugador.Armadura, jugador.Velocidad);
                jugador.RecibirDanio(danio);

                if (jugador.Salud <= 0)
                {
                    Console.WriteLine($"{jugador.Nombre} ha sido derrotado");
                    break;
                }

                Console.ReadKey();
                Console.Clear();
            }
            if (jugador.Salud > 0)
            {
                jugador.Salud = saludInicial;
                Console.WriteLine($"{jugador.Nombre} ha sobrevivido");
                Console.ReadKey();
                jugador.MejorarEstadisticas();
                jugador.Mostrar();
            }
        }


    }
}