using System;

public class Border
{
    public int x;
    public int y;
    public ConsoleColor color;
    public bool isSelected;
    public bool isCursorPosition;
    char[,] symbols = new char[3, 3];

    public Border(int x, int y, ConsoleColor color) {
        this.x = x;
        this.y = y;
        this.color = color;
        this.isSelected = false;
        this.isCursorPosition = false;
    }

    public void drawBorder() {
        Console.WriteLine("╒════════════════════════════════════════╕");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("│                                        │");
        Console.WriteLine("╘════════════════════════════════════════╛");
    }
}
