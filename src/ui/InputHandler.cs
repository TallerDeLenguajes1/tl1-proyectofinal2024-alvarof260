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

        public static DateTime LeerFecha(string mensaje)
        {
            DateTime fechaDeNacimiento;
            bool fechaValida = false;
            do
            {
                Console.WriteLine(mensaje);
                string fechaInput = Console.ReadLine();
                fechaValida = DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaDeNacimiento);
                if (!fechaValida)
                {
                    Console.WriteLine("Fecha inválida, por favor intenta de nuevo.");
                }
            } while (!fechaValida);
            return fechaDeNacimiento;
        }

        public static string LeerEntrada(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }

        public static TipoPersonaje LeerTipo()
        {
            TipoPersonaje tipoSeleccionado;
            bool tipoValido = false;
            do
            {
                string input = Console.ReadLine();
                tipoValido = Enum.TryParse(input, out tipoSeleccionado) && Enum.IsDefined(typeof(TipoPersonaje), tipoSeleccionado);
                if (!tipoValido)
                {
                    Console.WriteLine("Tipo inválido, por favor intenta de nuevo.");
                }
            } while (!tipoValido);
            return tipoSeleccionado;
        }
    }
}