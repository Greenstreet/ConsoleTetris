using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tetris{

    class Tetris{

        public static int cursorX = 1;
        public static int cursorY = 1;

        static void Main(string[] args){

            Console.WindowHeight = 35;
            Console.WindowWidth = 45;

            Border b1 = new Border(0, 0, ConsoleColor.White);
            b1.drawBorder();

            Engine();
            //Console.ForegroundColor = ConsoleColor.Cyan;

        }

        private static void Engine(){
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTick);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            int[,] tetrisBoard = new int[10, 20];
            

            while (true){

                if (Console.KeyAvailable){
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.LeftArrow){
                        //Console.SetCursorPosition(4, 2);
                        Console.WriteLine("██");
                    }
                    if (keyPressed.Key == ConsoleKey.RightArrow) {
                        //Console.SetCursorPosition(4, 2);
                        Console.WriteLine("██");
                    }
                    if (keyPressed.Key == ConsoleKey.DownArrow) {
                        //Console.SetCursorPosition(4, 2);
                        Console.WriteLine("██");
                    }
                    if (keyPressed.Key == ConsoleKey.UpArrow) {
                        //Console.SetCursorPosition(4, 2);
                        Console.WriteLine("██");
                    }
                }
            }
        }

        private void adjustCursorLocation(int cursorX, int cursorY) {

        }

        private static void OnTick(object source, ElapsedEventArgs e) {
            Console.WriteLine("Hello World!");
        }
    }
}
