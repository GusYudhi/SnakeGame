using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;

namespace SnakeGame
{
    internal class Game
    {
        private const int FieldWidth = 40;
        private const int FieldHeight = 20;
        private const int InitialSnakeLength = 3;
        private const int InitialSpeed = 150;

        private List<Point> snake;
        private Point food;
        private Direction direction;
        private int speed;
        private int score;

        public void Start()
        {
            InitGame();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = Direction.Down;
                            break;
                        case ConsoleKey.LeftArrow:
                            direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            direction = Direction.Right;
                            break;
                    }
                }

                if (IsGameOver())
                {
                    Console.Clear();
                    Print.CenterScreen("==============================================");
                    Print.CenterScreen("Game Over");
                    Print.CenterScreen("==============================================");
                    Print.CenterScreen($"Score Kamu : {score}");
                    Print.CenterScreen("Tekan Tombol Sembarang untuk kembali ke Menu");
                    Console.ReadKey(true);
                    return;
                }

                Update();
                Draw();

                Thread.Sleep(speed);
            }
        }

        private void InitGame()
        {
            snake = new List<Point>();
            direction = Direction.Right;
            speed = InitialSpeed;
            score = 0;

            // Initialize snake
            var startX = FieldWidth / 2;
            var startY = FieldHeight / 2;
            for (int i = 0; i < InitialSnakeLength; i++)
            {
                snake.Add(new Point(startX - i, startY));
            }

            food = GetRandomPosition();
        }

        private void Update()
        {
            var newHead = snake[0].Move(direction);

            if (newHead.Equals(food))
            {
                score++;
                snake.Insert(0, newHead);
                food = GetRandomPosition();
                speed -= 5;
            }
            else
            {
                snake.Insert(0, newHead);
                snake.RemoveAt(snake.Count - 1);
            }
        }

        private void Draw()
        {
            Console.Clear();

            for (int y = 0; y < FieldHeight; y++)
            {
                for (int x = 0; x < FieldWidth; x++)
                {
                    if (x == 0 || x == FieldWidth - 1 || y == 0 || y == FieldHeight - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("#");
                        Console.ResetColor();
                    }
                    else if (snake.Any(p => p.Equals(new Point(x, y))))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("*");
                        Console.ResetColor();
                    }
                    else if (food.Equals(new Point(x, y)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(FieldWidth + 2, 2);
            Console.WriteLine($"Score: {score}");
        }

        private Point GetRandomPosition()
        {
            var rand = new Random();
            int x = rand.Next(1, FieldWidth - 1);
            int y = rand.Next(1, FieldHeight - 1);
            return new Point(x, y);
        }

        private bool IsGameOver()
        {
            var head = snake[0];
            if (head.X == 0 || head.X == FieldWidth - 1 || head.Y == 0 || head.Y == FieldHeight - 1)
                return true;

            if (snake.Any(p => p.Equals(head) && !p.Equals(head)))
                return true;

            return false;
        }
    }
}
