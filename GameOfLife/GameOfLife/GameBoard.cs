using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameBoard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Cell[,] Board { get; set; }

        public GameBoard(int r, int c)
        {
            this.Rows = r;
            this.Columns = c;
            Board = new Cell[Rows, Columns];
        }
        
        public void PopulateBoardCells(CellState s)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Board[i, j] = new Cell(s);
                }
            }
        }

        public void SetAllBoardCellsToDead()
        {
            for (int i = 0; i < Rows - 1; i++)
            {
                for (int j = 0; j < Columns - 1; j++)
                {
                    Board[i, j].CState.Equals(CellState.Dead);
                }
            }
        }

        public bool EdgeCase(int r, int c)
        {
            return (r < 0 || c < 0 || r >= Rows || c >= Columns);
        }

        public bool CellAlive(int r, int c)
        {
            if (EdgeCase(r, c))
                return false;
            else
                return Board[r, c].CState.Equals(CellState.Alive);
        }

        public int CountNeighbors(int r, int c)
        {
            int n = 0;
            if (CellAlive(r, c - 1))
                n += 1;
            if (CellAlive(r - 1, c))
                n += 1;
            if (CellAlive(r, c + 1))
                n += 1;
            if (CellAlive(r + 1, c))
                n += 1;
            if (CellAlive(r + 1, c + 1))
                n += 1;
            if (CellAlive(r + 1, c - 1))
                n += 1;
            if (CellAlive(r - 1, c + 1))
                n += 1;
            if (CellAlive(r - 1, c - 1))
                n += 1;
            return n;
        }

        public void DrawBoard()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Board[i, j].CState.Equals(CellState.Alive))
                        sb.Append("X");
                    else
                        sb.Append(" ");
                }
                Console.WriteLine(sb);
                sb.Clear();
            }
        }

        public void CreateRandomSeed(int n)
        {
            Random random = new Random();
            for (int j = 0; j < n * 4; j++)
            {
                Board[random.Next(0, n), random.Next(0, n)].FlipState();
            }
        }
    }
}
