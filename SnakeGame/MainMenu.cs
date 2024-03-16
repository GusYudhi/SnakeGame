using System;
using System.Net.NetworkInformation;

namespace SnakeGame
{
    internal class MainMenu
    {
        private int selectedOption;

        public MainMenu()
        {
            selectedOption = 0;
        }

        public void Display()
        {
            Console.Clear();
            Print.CenterScreen("==============================================");
            Print.CenterScreen("Welcome in Snake Game");
            Print.CenterScreen("==============================================");

            string[] options = { "Play Game", "Help", "Quit Game" };

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedOption)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Print.CenterScreen(options[i]);

                Console.ResetColor();
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            HandleInput(key);
        }

        private void HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption - 1 + 3) % 3;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption + 1) % 3;
                    break;
                case ConsoleKey.Enter:
                    ExecuteOption();
                    break;
            }

            Display();
        }

        private void ExecuteOption()
        {
            switch (selectedOption)
            {
                case 0:
                    var game = new Game();
                    game.Start();
                    Display();
                    break;
                case 1:
                    Console.WriteLine("Displaying help...");
                    HelpPage.Display();
                    break;
                case 2:
                    Console.WriteLine("Quitting game...");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
