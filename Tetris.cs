using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tetris{

    static class Tetris{

        private static int cursorRow = 1;
        private static int cursorCol = 10;
        private static Random rng = new Random();
        private static IList<char> pieces = new List<char>{'o', 'o', 'l', 'l', 'j', 'j', 's', 's', 'z', 'z', 't', 't', 'i', 'i' };
        private static int[,] tetrisBoard = new int[10, 20];
        private static Tetrimo currentTetrimo;

        static void Main(string[] args){

            Console.WindowHeight = 35;
            Console.WindowWidth = 45;

            BoardDraw b1 = new BoardDraw(0, 0, ConsoleColor.White);
            b1.drawBorder();

            Console.SetCursorPosition(10, 1);

            pieces.Shuffle();

            Engine();
            //Console.ForegroundColor = ConsoleColor.Cyan;

        }

        private static void Engine(){
            int pieceCounter = 0;
            currentTetrimo = new Tetrimo(pieces[pieceCounter]);
            //Console.Write(currentTetrimo.type);
            //Console.Write(currentTetrimo.shape.GetLength(1));

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTick);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

            while (true) {

                if (Console.KeyAvailable) {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.LeftArrow) {
                        cursorCol -= 1;
                    }
                    if (keyPressed.Key == ConsoleKey.RightArrow) {
                        cursorCol += 1;
                    }
                    if (keyPressed.Key == ConsoleKey.DownArrow) {
                        cursorRow += 1;
                    }
                    if (keyPressed.Key == ConsoleKey.UpArrow) {
                        currentTetrimo.rotateTetrimo(currentTetrimo.shape);
                    }
                    if (keyPressed.Key == ConsoleKey.Spacebar) {
                        // TODO drop down
                    }

                    redraw();
                }
            }               
        }

        private static void OnTick(object source, ElapsedEventArgs e) {
            cursorRow += 1;
            
            redraw();
            
        }

        private static void redraw() {
            Console.Clear();

            BoardDraw b1 = new BoardDraw(0, 0, ConsoleColor.White);
            Console.SetCursorPosition(0, 0);
            b1.drawBorder();
            //b1.drawPlacedPieces(tetrisBoard);
            Console.SetCursorPosition(cursorCol, cursorRow);
            b1.drawCurrentPiece(currentTetrimo.shape);
            
            Console.SetCursorPosition(cursorCol, cursorRow);
            
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
