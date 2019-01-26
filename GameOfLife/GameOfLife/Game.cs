using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Game
    {
        private Cell[,] CreateTempBoard(GameBoard b)
        {
            Cell[,] tempBoard = new Cell[b.Rows, b.Columns];
            for (int i = 0; i < b.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    tempBoard[i, j] = new Cell(CellState.Dead);
                    tempBoard[i, j].CState = b.Board[i, j].CState;
                }
            }
            return tempBoard;
        }

        public Cell[,] SingleGameIteration(GameBoard b)
        {
            Cell[,] tempBoard = CreateTempBoard(b);
            for (int i = 0; i < b.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    int n = b.CountNeighbors(i, j);
                    bool c = b.CellAlive(i, j);
                    if (((n < 2) || (n > 3)) && c)
                        tempBoard[i, j].FlipState();
                    else if ((n == 3) && !c)
                        tempBoard[i, j].FlipState();
                }
            }
            return tempBoard;
        }

        public GameBoard SetupBoard(int r, int c)
        {
            GameBoard b = new GameBoard(r, c);
            b.PopulateBoardCells(CellState.Dead);
            return b;
        }

        public void RunGame(GameBoard b, int n)
        {
            for (int i = 0; i < n; i++)
            {
                b.DrawBoard();
                b.Board = SingleGameIteration(b);
                System.Threading.Thread.Sleep(200);
                Console.Clear();
            }
        }
    }
}
