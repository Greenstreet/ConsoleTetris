using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tetris {
    class Tetrimo {

        public char type;
        public int[,] shape;
        public int[,,] relationalPlacement = new int[4, 4, 2] { { {-1,-4}, {-1,-2}, {-1,0}, {-1,2}},
                                                         { { 0,-4},{0,-2}, {0,0}, {0,2} },
                                                         { { 1,-4}, {1,-2}, {1,0}, {1,2} },
                                                         { { 2,-4}, {2,-2}, {2,0}, {2,2} } };

        public Tetrimo(char type) {
            this.type = type;
            this.shape = getShapeDirective(type); 
        }

        private int[,] getShapeDirective(char type) {
            int[,] drawInstruction;

            switch (type) {
                case 'o':
                    return drawInstruction = new int[,] { { 0, 0, 0, 0 }, { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 } };
                case 'z':
                    return drawInstruction = new int[,] { { 0, 0, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 } };
                case 't':
                    return drawInstruction = new int[,] { { 0, 0, 0, 0 }, { 0, 1, 1, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } };
                case 'i':
                    return drawInstruction = new int[,] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
                case 's':
                    return drawInstruction = new int[,] { { 0, 0, 0, 0 }, { 0, 0, 1, 1 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 } };
                case 'l':
                    return drawInstruction = new int[,] { { 0, 0, 0, 0 }, { 0, 1, 1, 1 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } };
                case 'j':
                    return drawInstruction = new int[,] { { 0, 0, 0, 0 }, { 0, 1, 1, 1 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 } };
                default:
                    return null;
            }
        }

        public void rotateTetrimo(int[,] matrix) {
            int[,] newShape = new int[4, 4];

            for (int i = 0; i < 4; ++i) {
                for (int j = 0; j < 4; ++j) {
                    newShape[i, j] = matrix[4 - j - 1, i];
                }
            }

            this.shape = newShape;
        }

        //move method to terimo class, rename to canStrafe
        //direction flag: 1 = left, 0 = right
        public bool canStrafe(int[,] shape, int direction) {
            int colBorder = 5 * direction;
            int rowBlock = 0;
            int cursorPos = Console.CursorLeft;

            //finding position of left most block of current piece.
            if (direction == 1) {
                for (int i = 0; i < 4; i++) {
                    for (int j = 0; j < 4; j++) {
                        if (shape[i, j] == 1 && j < colBorder) {
                            colBorder = j;
                            rowBlock = i;
                        }
                    }
                }
            }

            //finding position of right most block of current tetrimo.
            if (direction == 0) {
                for (int i = 3; i >= 0; i--) {
                    for (int j = 3; j >= 0; j--) {
                        if (shape[i, j] == 1 && j > colBorder) {
                            colBorder = j;
                            rowBlock = i;
                        }
                    }
                }
            }

            //checks if can move to left or right
            if ((cursorPos + (relationalPlacement[rowBlock, colBorder, 1])) <= 1 && direction == 1) {
                return false;
            }
            else if ((cursorPos + (relationalPlacement[rowBlock, colBorder, 1])) >= 19 && direction == 0) {
                return false;
            }
            else
                return true;
        }
        
        //Returns an int denoting the amount, if at all the cursor needs to be shifted upon rotation.
        //Used for handling rotations surrounding upper/lower limits of border.
        public int postRotationAdjust(int[,] matrix) {

            int cursorPos = Console.CursorLeft;
            int colPos = 5;
            int rowPos = 0;

            //finding which columb of matrix, far most left piece is in.
            for (int i = 3; i >= 0; i--) {
                for (int j = 3; j >= 0; j--) {
                    if (shape[i, j] == 1 && j < colPos) {
                        colPos = j;
                        rowPos = i;
                    }
                }
            }

            Debug.WriteLine("CursorPos: " + cursorPos);
            //Debug.WriteLine("ColPos: " + colPos);
            Debug.WriteLine("If: " + (relationalPlacement[rowPos, colPos, 1]) / 2);

            //denote correct cursor adjustment
            if ((cursorPos + (relationalPlacement[rowPos,colPos,1]) / 2) <= 1) {
                Debug.WriteLine("Returned: " + (relationalPlacement[rowPos, colPos, 1] * -1) / 2);
                
                return (relationalPlacement[rowPos, colPos, 1] * -1) / 2;
            }
            else if(cursorPos > 100) {
                return -2;
            }
            else {
                return 0;
            }
            
        }
    }
}