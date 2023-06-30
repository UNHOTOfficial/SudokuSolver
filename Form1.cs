namespace SudokuSolver
{

    public partial class Form1 : Form
    {
        private int[,] grid = new int[9, 9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (Controls.Find("textBox" + row + col, true)[0] is TextBox textBox)
                    {

                        textBox.Font = new Font("Roboto", 9, FontStyle.Bold);
                        textBox.TextAlign = HorizontalAlignment.Center;
                    }
                    else
                    {
                        MessageBox.Show("Inputs Can't Be Empty.");
                    }
                }
            }
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            // Read the input grid from the text boxes
            ReadGrid();

            // Solve the Sudoku puzzle
            if (SolveSudoku(0, 0))
            {
                // If a solution is found, update the text boxes with the solved grid
                UpdateGrid();
                MessageBox.Show("Sudoku puzzle solved successfully!", "Sudoku Solver");
            }
            else
            {
                MessageBox.Show("No solution exists for the given puzzle.", "Sudoku Solver");
            }
        }

        private void ReadGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox? textBox = Controls.Find("textBox" + row + col, true)[0] as TextBox;
                    if (!string.IsNullOrEmpty(textBox?.Text))
                    {
                        grid[row, col] = int.Parse(textBox.Text);
                    }
                    else
                    {
                        grid[row, col] = 0;
                    }
                }
            }
        }

        private void UpdateGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (Controls.Find("textBox" + row + col, true)[0] is TextBox textBox)
                    {
                        textBox.Text = grid[row, col].ToString();
                        textBox.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Inputs Can't Be Empty.");
                    }
                }
            }
        }

        private bool SolveSudoku(int row, int col)
        {
            // Find the next empty cell
            if (!FindEmptyCell(ref row, ref col))
            {
                // If no empty cell found, puzzle is solved
                return true;
            }

            // Try values from 1 to 9
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(row, col, num))
                {
                    // Assign the number if it's safe
                    grid[row, col] = num;

                    // Recursively solve for the next cell
                    if (SolveSudoku(row, col))
                    {
                        return true;
                    }

                    // If the assignment doesn't lead to a solution, backtrack
                    grid[row, col] = 0;
                }
            }

            // No solution found
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
            // Check if the number already exists in the same row
            for (int i = 0; i < 9; i++)
            {
                if (grid[row, i] == num)
                {
                    return false;
                }
            }

            // Check if the number already exists in the same column
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, col] == num)
                {
                    return false;
                }
            }

            // Check if the number already exists in the same 3x3 sub-grid
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }
    }
}
