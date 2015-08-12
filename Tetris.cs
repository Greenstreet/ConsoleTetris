using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tetris{

    static class Tetris{

        public static int cursorX = 1;
        public static int cursorY = 1;
        private static Random rng = new Random();
        public static IList<char> pieces = new List<char>{'o', 'o', 'l', 'l', 'j', 'j', 's', 's', 'z', 'z', 't', 't', 'i', 'i' };

        static void Main(string[] args){

            Console.WindowHeight = 35;
            Console.WindowWidth = 45;

            Border b1 = new Border(0, 0, ConsoleColor.White);
            b1.drawBorder();

            Console.SetCursorPosition(1, 1);

            pieces.Shuffle();

            Engine();
            //Console.ForegroundColor = ConsoleColor.Cyan;

        }

        private static void Engine(){
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTick);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
            int[,] tetrisBoard = new int[10, 20];
            Tetrimo currentTetrimo = new Tetrimo(pieces[0]);

            while (true){
                if (Console.KeyAvailable){
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.LeftArrow){
                        Console.WriteLine("██");
                    }
                    if (keyPressed.Key == ConsoleKey.RightArrow) {
                        Console.WriteLine("██");
                    }
                    if (keyPressed.Key == ConsoleKey.DownArrow) {
                        Console.WriteLine("██");
                    }
                    if (keyPressed.Key == ConsoleKey.UpArrow) {
                        Console.WriteLine("██");
                        Console.Write("██");
                    }
                    if (keyPressed.Key == ConsoleKey.Spacebar) {  
                     
                    }
                }
            }
        }

        private static void adjustCursorLocation(int cursorX, int cursorY) {

        }

        private static void OnTick(object source, ElapsedEventArgs e) {
            Console.Clear();

            Border b1 = new Border(0, 0, ConsoleColor.White);
            b1.drawBorder();

            Console.SetCursorPosition(5, 1);


        }

        private static void Shuffle<T>(this IList<T> list) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
