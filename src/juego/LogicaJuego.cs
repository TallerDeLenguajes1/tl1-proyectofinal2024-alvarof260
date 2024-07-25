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
            while (jugador.Salud > 0 && rival.Salud > 0)
            {
                Console.WriteLine("Turno de " + jugador.Nombre);

                jugador.Atacar(rival);

                if (rival.Salud <= 0)
                {
                    Console.WriteLine($"{rival.Nombre} ha sido derrotado");
                    break;
                }

                Console.WriteLine("Turno de " + rival.Nombre);

                rival.Atacar(jugador);

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
                MejorarPersonaje(jugador);
                Mostrar.MostrarPersonaje(jugador);
            }
        }

        public static void MejorarPersonaje(Personaje personaje)
        {
            Console.WriteLine($"{personaje.Nombre} ({personaje.Apodo}) puede mejorar tus habilidades");
            Console.WriteLine("¿Que habilidad quieres mejorar?");
            Console.ReadKey();
            Console.WriteLine("1. Destreza");
            Console.WriteLine("2. Fuerza");
            Console.WriteLine("3. Nivel");
            Console.WriteLine("4. Armadura");
            Console.WriteLine("5. Velocidad");

            int opcion;
            string input;
            bool seleccionado;
            do
            {
                input = Console.ReadLine();
                seleccionado = int.TryParse(input, out opcion);
                switch (opcion)
                {
                    case 1:
                        if (personaje.Destreza < 10)
                        {
                            personaje.Destreza++;
                        }
                        else
                        {
                            Console.WriteLine("No puedes mejorar más");
                            seleccionado = false;
                        }
                        break;
                    case 2:
                        if (personaje.Fuerza < 10)
                        {
                            personaje.Fuerza++;
                        }
                        else
                        {
                            Console.WriteLine("No puedes mejorar más");
                            seleccionado = false;
                        }
                        break;
                    case 3:
                        if (personaje.Nivel < 10)
                        {
                            personaje.Nivel++;
                            personaje.Salud += 15;
                        }
                        else
                        {
                            personaje.Salud += 20;
                        }
                        break;
                    case 4:
                        if (personaje.Armadura < 10)
                        {
                            personaje.Armadura++;
                        }
                        else
                        {
                            Console.WriteLine("No puedes mejorar más");
                            seleccionado = false;
                        }
                        break;
                    case 5:
                        if (personaje.Velocidad < 10)
                        {
                            personaje.Velocidad++;
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
            } while (!seleccionado || (opcion < 1 || opcion > 5));

        }
    }
}