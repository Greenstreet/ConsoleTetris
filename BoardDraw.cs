using System;

public class BoardDraw
{
    public int x;
    public int y;
    public ConsoleColor color;
    public bool isSelected;
    public bool isCursorPosition;
    //TODO swap this out for a K1,K2,V1 style hash map
    
    public BoardDraw(int x, int y, ConsoleColor color) {
        this.x = x;
        this.y = y;
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
        //3d array detailing how to map from cursor to board space.
        int[,,] relationalPlacement = new int[4, 4, 2] { { {-1,-4}, {-1,-2}, {-1,0}, {-1,2}},
                                                         { { 0,-4},{0,-2}, {0,0}, {0,2} },
                                                         { { 1,-4}, {1,-2}, {1,0}, {1,2} },
                                                         { { 2,-4}, {2,-2}, {2,0}, {2,2} } };

        //Console.Write(cursorRow + " " + cursorCol);

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                if (tetrisPiece[i, j] == 1) {
                    Console.SetCursorPosition(cursorCol + relationalPlacement[i, j, 1], cursorRow + relationalPlacement[i, j, 0]);
                    Console.Write("██");
                }
            }
        }
    }
}
