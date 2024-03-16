using System;
using System.Net.NetworkInformation;

namespace SnakeGame
{
    internal class HelpPage
    {
        public static void Display()
        {
            Console.Clear();
            Print.CenterScreen("==============================================");
            Print.CenterScreen("Bantuan - Permainan Ular");
            Print.CenterScreen("==============================================");
            Print.CenterScreen("Gunakan tombol panah untuk mengontrol ular.");
            Print.CenterScreen("Makan makanan (@) untuk meningkatkan skor Anda.");
            Print.CenterScreen("Hindari menabrak dinding atau tubuh ular sendiri.\n");
            Print.CenterScreen("Tekan Enter untuk kembali ke menu utama.");

            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    var menu = new MainMenu();
                    menu.Display();
                    break;
                }
            }
        }
    }
}
