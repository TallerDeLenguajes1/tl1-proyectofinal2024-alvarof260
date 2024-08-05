namespace Proyecto
{
    public class Menu
    {
        public static void LogoCentrado(string text)
        {
            string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.None);
            int windowWidth = Console.WindowWidth;

            foreach (var line in lines)
            {
                int textLength = line.Length;
                int spaces = (windowWidth - textLength) / 2;
                if (spaces > 0)
                {
                    Console.WriteLine(new string(' ', spaces) + line);
                }
                else
                {
                    Console.WriteLine(line);
                }
            }
        }

        /*Console.ForegroundColor = ConsoleColor.Cyan;
                   LogoCentrado(LogoAscii);
                   Console.ResetColor(); */
        public static int Menuu(string[] opciones)
        {
            (int left, int top) = Console.GetCursorPosition();
            bool esSeleccionado = false;
            ConsoleKeyInfo tecla;
            int opcion = 1;
            while (!esSeleccionado)
            {
                int currentTop = top;

                ClearLine(left, currentTop, opciones.Length);
                Console.SetCursorPosition(left, top);

                for (int i = 0; i < opciones.Length; i++)
                {
                    MostrarOpcion(Console.WindowWidth, opciones[i], opcion == i + 1);
                }

                tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (opcion > 1) opcion--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (opcion < opciones.Length) opcion++;
                        break;
                    case ConsoleKey.Enter:
                        esSeleccionado = true;
                        break;
                }
                Console.WriteLine(opcion);
            }
            return opcion;
        }

        public static void TextoCentrado(int width, string text)
        {
            int position = (width - text.Length) / 2;
            Console.WriteLine(text.PadLeft(position + text.Length));
        }

        private static void MostrarOpcion(int anchoVentana, string opcion, bool seleccionada)
        {
            string texto = seleccionada ? $"> {opcion} <" : opcion;
            int padding = (anchoVentana - texto.Length) / 2;
            string linea = texto.PadLeft(padding + texto.Length).PadRight(anchoVentana);
            Console.WriteLine(linea);
        }

        private static void ClearLine(int left, int top, int numLines)
        {
            for (int i = 0; i < numLines; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }
    }
}