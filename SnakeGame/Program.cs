using System;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var menu = new MainMenu();
            menu.Display();
        }
    }
}
