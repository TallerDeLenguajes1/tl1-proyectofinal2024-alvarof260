namespace Proyecto
{
    public class ManejoDeEntrada
    {
        public static int LeerOpcionMenu()
        {
            int opcion;
            string input;
            bool seleccionado;
            do
            {
                input = Console.ReadLine();
                seleccionado = int.TryParse(input, out opcion);
                if (!seleccionado || (opcion < 1 || opcion > 3))
                {
                    Console.WriteLine("Opción no válida. Por favor, intenta de nuevo.");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu.MenuPrincipal();
                }
            } while (!seleccionado || (opcion < 1 || opcion > 3));
            return opcion;
        }
    }
}