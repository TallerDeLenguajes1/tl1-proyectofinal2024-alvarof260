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
                    Console.WriteLine("Has Perdido");
                    break;
                }
            }
            if (jugador.Salud > 0)
            {
                Console.WriteLine("Has Ganado");
                HistorialJson.GuardarGanador(jugador, "ganadores.json");
            }
            PersonajesJson.BorrarArchivo("personajes.json");
        }

        public static void Combate(Personaje jugador, Personaje rival)
        {
            int saludInicial = jugador.Salud;
            int danio;
            while (jugador.Salud > 0 && rival.Salud > 0)
            {
                Console.WriteLine("Turno de " + jugador.Nombre);

                danio = jugador.Atacar(rival.Armadura, rival.Velocidad);
                rival.RecibirDanio(danio);

                if (rival.Salud <= 0)
                {
                    Console.WriteLine($"{rival.Nombre} ha sido derrotado");
                    break;
                }

                Console.WriteLine("Turno de " + rival.Nombre);

                danio = rival.Atacar(jugador.Armadura, jugador.Velocidad);
                jugador.RecibirDanio(danio);

                if (jugador.Salud <= 0)
                {
                    Console.WriteLine($"{jugador.Nombre} ha sido derrotado");
                    break;
                }
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