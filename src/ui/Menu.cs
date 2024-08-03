namespace Proyecto
{
    public class Menu
    {
        const string LogoAscii = @"
░█████╗░░█████╗░███╗░░██╗░██████╗░██╗░░░██╗██╗░██████╗████████╗░█████╗░  ██╗░░░██╗
██╔══██╗██╔══██╗████╗░██║██╔═══██╗██║░░░██║██║██╔════╝╚══██╔══╝██╔══██╗  ╚██╗░██╔╝
██║░░╚═╝██║░░██║██╔██╗██║██║██╗██║██║░░░██║██║╚█████╗░░░░██║░░░███████║  ░╚████╔╝░
██║░░██╗██║░░██║██║╚████║╚██████╔╝██║░░░██║██║░╚═══██╗░░░██║░░░██╔══██║  ░░╚██╔╝░░
╚█████╔╝╚█████╔╝██║░╚███║░╚═██╔═╝░╚██████╔╝██║██████╔╝░░░██║░░░██║░░██║  ░░░██║░░░
░╚════╝░░╚════╝░╚═╝░░╚══╝░░░╚═╝░░░░╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝  ░░░╚═╝░░░

████████╗██████╗░██╗██╗░░░██╗███╗░░██╗███████╗░█████╗░
╚══██╔══╝██╔══██╗██║██║░░░██║████╗░██║██╔════╝██╔══██╗
░░░██║░░░██████╔╝██║██║░░░██║██╔██╗██║█████╗░░███████║
░░░██║░░░██╔══██╗██║██║░░░██║██║╚████║██╔══╝░░██╔══██║
░░░██║░░░██║░░██║██║╚██████╔╝██║░╚███║██║░░░░░██║░░██║
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░╚═════╝░╚═╝░░╚══╝╚═╝░░░░░╚═╝░░╚═╝";

        static void LogoCentrado(string text)
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

        public static int MenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            LogoCentrado(LogoAscii);
            Console.ResetColor();
            (int left, int top) = Console.GetCursorPosition();
            bool esSeleccionado = false;
            ConsoleKeyInfo tecla;
            int opcion = 1;
            while (!esSeleccionado)
            {
                int currentTop = top;

                ClearLine(left, currentTop);
                ClearLine(left, currentTop + 1);
                ClearLine(left, currentTop + 2);
                Console.SetCursorPosition(left, top);

                MostrarOpcion(Console.WindowWidth, "Nueva Partida", opcion == 1);
                MostrarOpcion(Console.WindowWidth, "Cargar Partida", opcion == 2);
                MostrarOpcion(Console.WindowWidth, "Salir", opcion == 3);

                tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (opcion > 1) opcion--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (opcion < 3) opcion++;
                        break;
                    case ConsoleKey.Enter:
                        esSeleccionado = true;
                        break;
                }
                Console.WriteLine("Seleccionaste la opcion " + opcion);
            }
            return opcion;
        }

        public static void TextoCentrado(int width, string text)
        {
            int position = (width - text.Length) / 2;
            Console.WriteLine(text.PadLeft(position + text.Length));
        }

        private static void ClearLine(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }

        public static void MostrarOpcion(int width, string text, bool esSeleccionado)
        {
            string textWithArrow = esSeleccionado ? "-> " + text : "   " + text;
            if (esSeleccionado)
            {
                Console.ForegroundColor = ConsoleColor.Magenta; // Cambiar el color de la opción seleccionada
            }

            TextoCentrado(width, textWithArrow);

            if (esSeleccionado)
            {
                Console.ResetColor(); // Restablecer el color después de pintar la opción seleccionada
            }
        }
    }
}