using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class Sudoku
    {
        private int[,] grid;

        public Sudoku()
        {
            grid = new int[9, 9];
        }

        public void SetCell(int row, int col, int value)
        {
            grid[row, col] = value;
        }

        public int GetCell(int row, int col)
        {
            return grid[row, col];
        }

        public bool Solve()
        {
            return SolveSudoku(0, 0);
        }

        private bool SolveSudoku(int row, int col)
        {
            if (!FindEmptyCell(ref row, ref col))
            {
                return true;
            }

            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(row, col, num))
                {
                    grid[row, col] = num;

                    if (SolveSudoku(row, col))
                    {
                        return true;
                    }

                    grid[row, col] = 0;
                }
            }

            return false;
        }

        private bool FindEmptyCell(ref int row, ref int col)
        {
            for (row = 0; row < 9; row++)
            {
                for (col = 0; col < 9; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsSafe(int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[row, i] == num)
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (grid[i, col] == num)
                {
                    return false;
                }
            }

            int subGridRow = row - row % 3;
            int subGridCol = col - col % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[subGridRow + i, subGridCol + j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
