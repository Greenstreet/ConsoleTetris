using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris {
    class Tetrimo {

        public char type;
        public int[,] shape;

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
    }
}
