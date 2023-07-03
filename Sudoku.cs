using System;

namespace SudokuSolver
{
    internal class Sudoku
    {
        private int[,] grid;

        public Sudoku()
        {
            grid = new int[9, 9]; // Initialize the Sudoku grid as a 9x9 array
        }

        public void SetCell(int row, int col, int value)
        {
            grid[row, col] = value; // Set the value of a cell in the grid
        }

        public int GetCell(int row, int col)
        {
            return grid[row, col]; // Get the value of a cell in the grid
        }

        public bool Solve()
        {
            return SolveSudoku(0, 0); // Solve the Sudoku puzzle
        }

        private bool SolveSudoku(int row, int col)
        {
            // Find the next empty cell in the grid
            if (!FindEmptyCell(ref row, ref col))// ref makes original row and col change
            {
                return true; // If no empty cell found, the puzzle is solved
            }

            // Try different numbers from 1 to 9 in the empty cell
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(row, col, num))
                {
                    grid[row, col] = num; // Place the number in the cell

                    if (SolveSudoku(row, col))
                    {
                        return true; // solve the puzzle
                    }

                    grid[row, col] = 0; // reset the cell if the solution is not valid
                }
            }

            return false; // If no valid number can be placed, try a different number
        }

        private bool FindEmptyCell(ref int row, ref int col)
        {
            // Find the first empty cell in the grid
            for (row = 0; row < 9; row++)
            {
                for (col = 0; col < 9; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        return true; // Found an empty cell
                    }
                }
            }

            return false; // No empty cell found
        }

        private bool IsSafe(int row, int col, int num)
        {
            // Check if it is safe to place the number in the given cell

            // Check row and column for the same number
            for (int i = 0; i < 9; i++)
            {
                if (grid[row, i] == num || grid[i, col] == num)
                {
                    return false; // Number already exists in the row or column
                }
            }

            // Check the 3x3 subgrid for the same number
            int subGridRow = row - row % 3;
            int subGridCol = col - col % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[subGridRow + i, subGridCol + j] == num)
                    {
                        return false; // Number already exists in the subgrid
                    }
                }
            }

            return true; // Number can be safely placed in the cell
        }
    }
}
