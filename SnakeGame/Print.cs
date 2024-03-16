using System;

namespace SnakeGame
{
    internal class Print
    {
        public static void CenterScreen(string input)
        {
            var screenSize = GetScreenSize();
            var padding = new string(' ', Math.Max(screenSize.Item1 - input.Length, 0) / 2);
            Console.WriteLine($"{padding}{input}");
        }
        public static (int, int) GetScreenSize()
        {
            return (Console.BufferWidth, Console.BufferHeight);
        }
    }
}
