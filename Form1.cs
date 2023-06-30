namespace SudokuSolver
{

    public partial class Form1 : Form
    {
        private Sudoku grid;

        public Form1()
        {
            InitializeComponent();
            grid = new Sudoku();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTextBoxes();
           
        }

        private void InitializeTextBoxes()
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
            if (grid.Solve())
            {
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
                        grid.SetCell(row, col, int.Parse(textBox.Text));
                    }
                    else
                    {
                        grid.SetCell(row, col, 0);
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
                        textBox.Text = grid.GetCell(row, col).ToString();
                        textBox.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Inputs Can't Be Empty.");
                    }
                }
            }
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
