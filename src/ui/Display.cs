namespace Proyecto
{
    public class Mostrar
    {
        // ! cambiar este metodo
        public static void MostrarPersonaje(Personaje personaje)
        {
            Console.WriteLine($"{personaje.Nombre} ({personaje.Apodo})");
            Console.WriteLine($"Fecha de Nacimiento: {personaje.FechaDeNacimiento.ToShortDateString()}");
            Console.WriteLine($"Edad: {personaje.Edad}");
            Console.WriteLine($"Tipo: {personaje.Tipo}");
            Console.WriteLine($"Velocidad: {personaje.Velocidad}");
            Console.WriteLine($"Destreza: {personaje.Destreza}");
            Console.WriteLine($"Fuerza: {personaje.Fuerza}");
            Console.WriteLine($"Nivel: {personaje.Nivel}");
            Console.WriteLine($"Armadura: {personaje.Armadura}");
            Console.WriteLine($"Salud: {personaje.Salud}");
        }

        public static void MostrarTipos()
        {
            Console.WriteLine("Eliga un tipo:");
            foreach (var tipo in Enum.GetValues(typeof(TipoPersonaje)))
            {
                Console.WriteLine($"{(int)tipo} - {tipo}");
            }
        }
    }
}