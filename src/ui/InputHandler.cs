namespace Proyecto
{
    public class ManejoDeEntrada
    {
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

    }
}