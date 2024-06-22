namespace utils
{
  public static class Utils
  {
    public static void TextCenter(int width, string text)
    {
      int position = (width - text.Length) / 2;
      Console.WriteLine(text.PadLeft(position + text.Length));
    }
  }
}
