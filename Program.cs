using utils;
using System.Text;

class Program
{
  /*Encapsular la logica y hacerlo reutilizable*/

  static void Main(string[] args)
  {
    Console.Clear();
    Console.OutputEncoding = Encoding.UTF8;
    Console.CursorVisible = false;
    Console.ForegroundColor = ConsoleColor.Red;
    Utils.TextCenter(Console.WindowWidth, "🏹🗡️ Bienvenido al juego 'Mundo Clash' 🗡️🏹");
    Console.ResetColor();
    Utils.TextCenter(Console.WindowWidth, "     Moverse con \u001b[32mW ⬆️  y S ⬇️  \u001b[0m en el Menu");
    (int left, int top) = Console.GetCursorPosition();
    bool isSelected = false;
    ConsoleKeyInfo key;
    int option = 1;
    string decorator = "\u001b[32m";

    while (!isSelected)
    {
      // Guardar la posición actual del cursor
      int currentTop = top;

      // Borrar las líneas de las opciones antes de volver a imprimirlas
      ClearLine(left, currentTop);
      ClearLine(left, currentTop + 1);
      Console.SetCursorPosition(left, top);
      Utils.TextCenter(Console.WindowWidth, $"{(option == 1 ? decorator : " ")}1 - Jugar 👾\u001b[0m");
      Utils.TextCenter(Console.WindowWidth, $"{(option == 2 ? decorator : " ")}2 - Salir 👋\u001b[0m");

      key = Console.ReadKey(false);

      switch (key.Key)
      {
        case ConsoleKey.UpArrow:
          if (option > 1) option--;
          break;
        case ConsoleKey.DownArrow:
          if (option < 2) option++;
          break;
        case ConsoleKey.Enter:
          isSelected = true;
          break;
        case ConsoleKey.Escape:
          Environment.Exit(0);
          break;
      }
    }

    Console.WriteLine("Seleccionaste la opcion " + option);

  }

  private static void ClearLine(int left, int top)
  {
    Console.SetCursorPosition(left, top);
    Console.WriteLine(new string(' ', Console.WindowWidth));
  }
}

