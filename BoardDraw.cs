using System;
using System.Diagnostics;

public class BoardDraw
{
    public ConsoleColor color;
    public bool isSelected;
    public bool isCursorPosition;
    private static int[,] tetrisBoard = new int[10, 20];
    //3d array detailing how to map from cursor to board space.
    //TODO swap this out for a K1,K2,V1 style hash map
    public int[,,] relationalPlacement = new int[4, 4, 2] { { {-1,-4}, {-1,-2}, {-1,0}, {-1,2}},
                                                         { { 0,-4},{0,-2}, {0,0}, {0,2} },
                                                         { { 1,-4}, {1,-2}, {1,0}, {1,2} },
                                                         { { 2,-4}, {2,-2}, {2,0}, {2,2} } };

    public BoardDraw(ConsoleColor color) {
        this.color = color;
        this.isSelected = false;
        this.isCursorPosition = false;
    }

    public void drawBorder() {
        Console.WriteLine("╒════════════════════╕");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("│                    │");
        Console.WriteLine("╘════════════════════╛");
    }

    public void drawPlacedPieces(int[,] tetrisBoard) {
        for(int i = 0; i < tetrisBoard.GetLength(0); i++) {
            for (int j = 0; j < tetrisBoard.GetLength(1); j++) {
                if (tetrisBoard[i,j] == 1) {
                    Console.SetCursorPosition((2*i) + 1, (j) + 1);
                    Console.Write("██");
                }
            }
        }
    }

    public void drawCurrentPiece(int[,] tetrisPiece) {
        int cursorRow = Console.CursorTop;
        int cursorCol = Console.CursorLeft;

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                if (tetrisPiece[i, j] == 1) {
                    //Debug.WriteLine(relationalPlacement[i, j, 1]);
                    Console.SetCursorPosition(cursorCol + relationalPlacement[i, j, 1], cursorRow + relationalPlacement[i, j, 0]);
                    Console.Write("██");
                }
            }
        }
    }
}
