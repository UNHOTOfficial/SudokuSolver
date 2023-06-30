namespace SudokuSolver
{

    public partial class Form1 : Form
    {
        private string[,,] sudokuPuzzles = new string[5, 9, 9];
        private int sudokuLevel;

        private void LoadSudokuPuzzle(int puzzleIndex)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox? textBox = Controls.Find("textBox" + row + col, true)[0] as TextBox;
                    textBox.Text = sudokuPuzzles[puzzleIndex, row, col].ToString();
                }
            }
        }

        private Sudoku grid;

        public Form1()
        {
            InitializeComponent();

 

            sudokuPuzzles[0, 0, 0] = "5"; sudokuPuzzles[0, 0, 1] = "3"; sudokuPuzzles[0, 0, 2] = ""; sudokuPuzzles[0, 0, 3] = ""; sudokuPuzzles[0, 0, 4] = "7"; sudokuPuzzles[0, 0, 5] = ""; sudokuPuzzles[0, 0, 6] = ""; sudokuPuzzles[0, 0, 7] = ""; sudokuPuzzles[0, 0, 8] = "";
            sudokuPuzzles[0, 1, 0] = "6"; sudokuPuzzles[0, 1, 1] = ""; sudokuPuzzles[0, 1, 2] = ""; sudokuPuzzles[0, 1, 3] = "1"; sudokuPuzzles[0, 1, 4] = "9"; sudokuPuzzles[0, 1, 5] = "5"; sudokuPuzzles[0, 1, 6] = ""; sudokuPuzzles[0, 1, 7] = ""; sudokuPuzzles[0, 1, 8] = "";
            sudokuPuzzles[0, 2, 0] = ""; sudokuPuzzles[0, 2, 1] = "9"; sudokuPuzzles[0, 2, 2] = "8"; sudokuPuzzles[0, 2, 3] = ""; sudokuPuzzles[0, 2, 4] = ""; sudokuPuzzles[0, 2, 5] = ""; sudokuPuzzles[0, 2, 6] = ""; sudokuPuzzles[0, 2, 7] = "6"; sudokuPuzzles[0, 2, 8] = "";
            sudokuPuzzles[0, 3, 0] = "8"; sudokuPuzzles[0, 3, 1] = ""; sudokuPuzzles[0, 3, 2] = ""; sudokuPuzzles[0, 3, 3] = ""; sudokuPuzzles[0, 3, 4] = "6"; sudokuPuzzles[0, 3, 5] = ""; sudokuPuzzles[0, 3, 6] = ""; sudokuPuzzles[0, 3, 7] = ""; sudokuPuzzles[0, 3, 8] = "3";
            sudokuPuzzles[0, 4, 0] = "4"; sudokuPuzzles[0, 4, 1] = ""; sudokuPuzzles[0, 4, 2] = ""; sudokuPuzzles[0, 4, 3] = "8"; sudokuPuzzles[0, 4, 4] = ""; sudokuPuzzles[0, 4, 5] = "3"; sudokuPuzzles[0, 4, 6] = ""; sudokuPuzzles[0, 4, 7] = ""; sudokuPuzzles[0, 4, 8] = "1";
            sudokuPuzzles[0, 5, 0] = "7"; sudokuPuzzles[0, 5, 1] = ""; sudokuPuzzles[0, 5, 2] = ""; sudokuPuzzles[0, 5, 3] = ""; sudokuPuzzles[0, 5, 4] = "2"; sudokuPuzzles[0, 5, 5] = ""; sudokuPuzzles[0, 5, 6] = ""; sudokuPuzzles[0, 5, 7] = ""; sudokuPuzzles[0, 5, 8] = "6";
            sudokuPuzzles[0, 6, 0] = ""; sudokuPuzzles[0, 6, 1] = "6"; sudokuPuzzles[0, 6, 2] = ""; sudokuPuzzles[0, 6, 3] = ""; sudokuPuzzles[0, 6, 4] = ""; sudokuPuzzles[0, 6, 5] = ""; sudokuPuzzles[0, 6, 6] = "2"; sudokuPuzzles[0, 6, 7] = "8"; sudokuPuzzles[0, 6, 8] = "";
            sudokuPuzzles[0, 7, 0] = ""; sudokuPuzzles[0, 7, 1] = ""; sudokuPuzzles[0, 7, 2] = ""; sudokuPuzzles[0, 7, 3] = "4"; sudokuPuzzles[0, 7, 4] = "1"; sudokuPuzzles[0, 7, 5] = "9"; sudokuPuzzles[0, 7, 6] = ""; sudokuPuzzles[0, 7, 7] = ""; sudokuPuzzles[0, 7, 8] = "5";
            sudokuPuzzles[0, 8, 0] = ""; sudokuPuzzles[0, 8, 1] = ""; sudokuPuzzles[0, 8, 2] = ""; sudokuPuzzles[0, 8, 3] = ""; sudokuPuzzles[0, 8, 4] = "8"; sudokuPuzzles[0, 8, 5] = ""; sudokuPuzzles[0, 8, 6] = ""; sudokuPuzzles[0, 8, 7] = "7"; sudokuPuzzles[0, 8, 8] = "9";


            sudokuPuzzles[1, 0, 0] = ""; sudokuPuzzles[1, 0, 1] = "4"; sudokuPuzzles[1, 0, 2] = ""; sudokuPuzzles[1, 0, 3] = ""; sudokuPuzzles[1, 0, 4] = "9"; sudokuPuzzles[1, 0, 5] = ""; sudokuPuzzles[1, 0, 6] = ""; sudokuPuzzles[1, 0, 7] = "6"; sudokuPuzzles[1, 0, 8] = "";
            sudokuPuzzles[1, 1, 0] = "7"; sudokuPuzzles[1, 1, 1] = ""; sudokuPuzzles[1, 1, 2] = ""; sudokuPuzzles[1, 1, 3] = ""; sudokuPuzzles[1, 1, 4] = ""; sudokuPuzzles[1, 1, 5] = "1"; sudokuPuzzles[1, 1, 6] = "2"; sudokuPuzzles[1, 1, 7] = ""; sudokuPuzzles[1, 1, 8] = "5";
            sudokuPuzzles[1, 2, 0] = "6"; sudokuPuzzles[1, 2, 1] = ""; sudokuPuzzles[1, 2, 2] = ""; sudokuPuzzles[1, 2, 3] = ""; sudokuPuzzles[1, 2, 4] = ""; sudokuPuzzles[1, 2, 5] = "4"; sudokuPuzzles[1, 2, 6] = ""; sudokuPuzzles[1, 2, 7] = "3"; sudokuPuzzles[1, 2, 8] = "";
            sudokuPuzzles[1, 3, 0] = ""; sudokuPuzzles[1, 3, 1] = ""; sudokuPuzzles[1, 3, 2] = ""; sudokuPuzzles[1, 3, 3] = "5"; sudokuPuzzles[1, 3, 4] = ""; sudokuPuzzles[1, 3, 5] = "8"; sudokuPuzzles[1, 3, 6] = ""; sudokuPuzzles[1, 3, 7] = ""; sudokuPuzzles[1, 3, 8] = "";
            sudokuPuzzles[1, 4, 0] = "2"; sudokuPuzzles[1, 4, 1] = ""; sudokuPuzzles[1, 4, 2] = ""; sudokuPuzzles[1, 4, 3] = ""; sudokuPuzzles[1, 4, 4] = "7"; sudokuPuzzles[1, 4, 5] = ""; sudokuPuzzles[1, 4, 6] = ""; sudokuPuzzles[1, 4, 7] = ""; sudokuPuzzles[1, 4, 8] = "1";
            sudokuPuzzles[1, 5, 0] = ""; sudokuPuzzles[1, 5, 1] = ""; sudokuPuzzles[1, 5, 2] = ""; sudokuPuzzles[1, 5, 3] = "9"; sudokuPuzzles[1, 5, 4] = ""; sudokuPuzzles[1, 5, 5] = "6"; sudokuPuzzles[1, 5, 6] = ""; sudokuPuzzles[1, 5, 7] = ""; sudokuPuzzles[1, 5, 8] = "";
            sudokuPuzzles[1, 6, 0] = ""; sudokuPuzzles[1, 6, 1] = "3"; sudokuPuzzles[1, 6, 2] = ""; sudokuPuzzles[1, 6, 3] = "2"; sudokuPuzzles[1, 6, 4] = ""; sudokuPuzzles[1, 6, 5] = ""; sudokuPuzzles[1, 6, 6] = ""; sudokuPuzzles[1, 6, 7] = ""; sudokuPuzzles[1, 6, 8] = "9";
            sudokuPuzzles[1, 7, 0] = "9"; sudokuPuzzles[1, 7, 1] = ""; sudokuPuzzles[1, 7, 2] = "5"; sudokuPuzzles[1, 7, 3] = "6"; sudokuPuzzles[1, 7, 4] = ""; sudokuPuzzles[1, 7, 5] = ""; sudokuPuzzles[1, 7, 6] = ""; sudokuPuzzles[1, 7, 7] = ""; sudokuPuzzles[1, 7, 8] = "";
            sudokuPuzzles[1, 8, 0] = ""; sudokuPuzzles[1, 8, 1] = "7"; sudokuPuzzles[1, 8, 2] = ""; sudokuPuzzles[1, 8, 3] = ""; sudokuPuzzles[1, 8, 4] = "3"; sudokuPuzzles[1, 8, 5] = ""; sudokuPuzzles[1, 8, 6] = ""; sudokuPuzzles[1, 8, 7] = "5"; sudokuPuzzles[1, 8, 8] = "";


            sudokuPuzzles[2, 0, 0] = ""; sudokuPuzzles[2, 0, 1] = ""; sudokuPuzzles[2, 0, 2] = ""; sudokuPuzzles[2, 0, 3] = ""; sudokuPuzzles[2, 0, 4] = ""; sudokuPuzzles[2, 0, 5] = "9"; sudokuPuzzles[2, 0, 6] = ""; sudokuPuzzles[2, 0, 7] = ""; sudokuPuzzles[2, 0, 8] = "";
            sudokuPuzzles[2, 1, 0] = "1"; sudokuPuzzles[2, 1, 1] = ""; sudokuPuzzles[2, 1, 2] = ""; sudokuPuzzles[2, 1, 3] = "6"; sudokuPuzzles[2, 1, 4] = ""; sudokuPuzzles[2, 1, 5] = ""; sudokuPuzzles[2, 1, 6] = "4"; sudokuPuzzles[2, 1, 7] = ""; sudokuPuzzles[2, 1, 8] = "";
            sudokuPuzzles[2, 2, 0] = ""; sudokuPuzzles[2, 2, 1] = ""; sudokuPuzzles[2, 2, 2] = ""; sudokuPuzzles[2, 2, 3] = "5"; sudokuPuzzles[2, 2, 4] = ""; sudokuPuzzles[2, 2, 5] = ""; sudokuPuzzles[2, 2, 6] = "2"; sudokuPuzzles[2, 2, 7] = ""; sudokuPuzzles[2, 2, 8] = "";
            sudokuPuzzles[2, 3, 0] = "4"; sudokuPuzzles[2, 3, 1] = ""; sudokuPuzzles[2, 3, 2] = ""; sudokuPuzzles[2, 3, 3] = ""; sudokuPuzzles[2, 3, 4] = ""; sudokuPuzzles[2, 3, 5] = "2"; sudokuPuzzles[2, 3, 6] = ""; sudokuPuzzles[2, 3, 7] = ""; sudokuPuzzles[2, 3, 8] = "6";
            sudokuPuzzles[2, 4, 0] = ""; sudokuPuzzles[2, 4, 1] = "6"; sudokuPuzzles[2, 4, 2] = ""; sudokuPuzzles[2, 4, 3] = ""; sudokuPuzzles[2, 4, 4] = ""; sudokuPuzzles[2, 4, 5] = ""; sudokuPuzzles[2, 4, 6] = ""; sudokuPuzzles[2, 4, 7] = "1"; sudokuPuzzles[2, 4, 8] = "";
            sudokuPuzzles[2, 5, 0] = "8"; sudokuPuzzles[2, 5, 1] = ""; sudokuPuzzles[2, 5, 2] = ""; sudokuPuzzles[2, 5, 3] = "7"; sudokuPuzzles[2, 5, 4] = ""; sudokuPuzzles[2, 5, 5] = ""; sudokuPuzzles[2, 5, 6] = ""; sudokuPuzzles[2, 5, 7] = ""; sudokuPuzzles[2, 5, 8] = "9";
            sudokuPuzzles[2, 6, 0] = ""; sudokuPuzzles[2, 6, 1] = ""; sudokuPuzzles[2, 6, 2] = "9"; sudokuPuzzles[2, 6, 3] = ""; sudokuPuzzles[2, 6, 4] = ""; sudokuPuzzles[2, 6, 5] = "5"; sudokuPuzzles[2, 6, 6] = ""; sudokuPuzzles[2, 6, 7] = ""; sudokuPuzzles[2, 6, 8] = "";
            sudokuPuzzles[2, 7, 0] = ""; sudokuPuzzles[2, 7, 1] = ""; sudokuPuzzles[2, 7, 2] = "2"; sudokuPuzzles[2, 7, 3] = ""; sudokuPuzzles[2, 7, 4] = ""; sudokuPuzzles[2, 7, 5] = "4"; sudokuPuzzles[2, 7, 6] = ""; sudokuPuzzles[2, 7, 7] = ""; sudokuPuzzles[2, 7, 8] = "7";
            sudokuPuzzles[2, 8, 0] = ""; sudokuPuzzles[2, 8, 1] = ""; sudokuPuzzles[2, 8, 2] = ""; sudokuPuzzles[2, 8, 3] = "9"; sudokuPuzzles[2, 8, 4] = ""; sudokuPuzzles[2, 8, 5] = ""; sudokuPuzzles[2, 8, 6] = ""; sudokuPuzzles[2, 8, 7] = ""; sudokuPuzzles[2, 8, 8] = "";


            sudokuPuzzles[3, 0, 0] = ""; sudokuPuzzles[3, 0, 1] = ""; sudokuPuzzles[3, 0, 2] = ""; sudokuPuzzles[3, 0, 3] = "1"; sudokuPuzzles[3, 0, 4] = ""; sudokuPuzzles[3, 0, 5] = ""; sudokuPuzzles[3, 0, 6] = ""; sudokuPuzzles[3, 0, 7] = ""; sudokuPuzzles[3, 0, 8] = "";
            sudokuPuzzles[3, 1, 0] = ""; sudokuPuzzles[3, 1, 1] = "1"; sudokuPuzzles[3, 1, 2] = ""; sudokuPuzzles[3, 1, 3] = ""; sudokuPuzzles[3, 1, 4] = "6"; sudokuPuzzles[3, 1, 5] = ""; sudokuPuzzles[3, 1, 6] = ""; sudokuPuzzles[3, 1, 7] = ""; sudokuPuzzles[3, 1, 8] = "4";
            sudokuPuzzles[3, 2, 0] = ""; sudokuPuzzles[3, 2, 1] = ""; sudokuPuzzles[3, 2, 2] = ""; sudokuPuzzles[3, 2, 3] = ""; sudokuPuzzles[3, 2, 4] = ""; sudokuPuzzles[3, 2, 5] = "7"; sudokuPuzzles[3, 2, 6] = ""; sudokuPuzzles[3, 2, 7] = "6"; sudokuPuzzles[3, 2, 8] = "";
            sudokuPuzzles[3, 3, 0] = "7"; sudokuPuzzles[3, 3, 1] = ""; sudokuPuzzles[3, 3, 2] = ""; sudokuPuzzles[3, 3, 3] = ""; sudokuPuzzles[3, 3, 4] = ""; sudokuPuzzles[3, 3, 5] = ""; sudokuPuzzles[3, 3, 6] = ""; sudokuPuzzles[3, 3, 7] = "2"; sudokuPuzzles[3, 3, 8] = "";
            sudokuPuzzles[3, 4, 0] = ""; sudokuPuzzles[3, 4, 1] = ""; sudokuPuzzles[3, 4, 2] = "3"; sudokuPuzzles[3, 4, 3] = ""; sudokuPuzzles[3, 4, 4] = ""; sudokuPuzzles[3, 4, 5] = ""; sudokuPuzzles[3, 4, 6] = "5"; sudokuPuzzles[3, 4, 7] = ""; sudokuPuzzles[3, 4, 8] = "";
            sudokuPuzzles[3, 5, 0] = ""; sudokuPuzzles[3, 5, 1] = "9"; sudokuPuzzles[3, 5, 2] = ""; sudokuPuzzles[3, 5, 3] = ""; sudokuPuzzles[3, 5, 4] = ""; sudokuPuzzles[3, 5, 5] = ""; sudokuPuzzles[3, 5, 6] = ""; sudokuPuzzles[3, 5, 7] = ""; sudokuPuzzles[3, 5, 8] = "6";
            sudokuPuzzles[3, 6, 0] = ""; sudokuPuzzles[3, 6, 1] = "2"; sudokuPuzzles[3, 6, 2] = ""; sudokuPuzzles[3, 6, 3] = "4"; sudokuPuzzles[3, 6, 4] = ""; sudokuPuzzles[3, 6, 5] = ""; sudokuPuzzles[3, 6, 6] = ""; sudokuPuzzles[3, 6, 7] = ""; sudokuPuzzles[3, 6, 8] = "";
            sudokuPuzzles[3, 7, 0] = "4"; sudokuPuzzles[3, 7, 1] = ""; sudokuPuzzles[3, 7, 2] = ""; sudokuPuzzles[3, 7, 3] = ""; sudokuPuzzles[3, 7, 4] = "2"; sudokuPuzzles[3, 7, 5] = ""; sudokuPuzzles[3, 7, 6] = ""; sudokuPuzzles[3, 7, 7] = "9"; sudokuPuzzles[3, 7, 8] = "";
            sudokuPuzzles[3, 8, 0] = ""; sudokuPuzzles[3, 8, 1] = ""; sudokuPuzzles[3, 8, 2] = ""; sudokuPuzzles[3, 8, 3] = ""; sudokuPuzzles[3, 8, 4] = ""; sudokuPuzzles[3, 8, 5] = "3"; sudokuPuzzles[3, 8, 6] = ""; sudokuPuzzles[3, 8, 7] = ""; sudokuPuzzles[3, 8, 8] = "";


            sudokuPuzzles[4, 0, 0] = "8"; sudokuPuzzles[4, 0, 1] = ""; sudokuPuzzles[4, 0, 2] = ""; sudokuPuzzles[4, 0, 3] = ""; sudokuPuzzles[4, 0, 4] = ""; sudokuPuzzles[4, 0, 5] = ""; sudokuPuzzles[4, 0, 6] = ""; sudokuPuzzles[4, 0, 7] = ""; sudokuPuzzles[4, 0, 8] = "";
            sudokuPuzzles[4, 1, 0] = ""; sudokuPuzzles[4, 1, 1] = ""; sudokuPuzzles[4, 1, 2] = "3"; sudokuPuzzles[4, 1, 3] = ""; sudokuPuzzles[4, 1, 4] = ""; sudokuPuzzles[4, 1, 5] = ""; sudokuPuzzles[4, 1, 6] = ""; sudokuPuzzles[4, 1, 7] = ""; sudokuPuzzles[4, 1, 8] = "";
            sudokuPuzzles[4, 2, 0] = ""; sudokuPuzzles[4, 2, 1] = "7"; sudokuPuzzles[4, 2, 2] = ""; sudokuPuzzles[4, 2, 3] = ""; sudokuPuzzles[4, 2, 4] = ""; sudokuPuzzles[4, 2, 5] = ""; sudokuPuzzles[4, 2, 6] = "4"; sudokuPuzzles[4, 2, 7] = ""; sudokuPuzzles[4, 2, 8] = "";
            sudokuPuzzles[4, 3, 0] = ""; sudokuPuzzles[4, 3, 1] = ""; sudokuPuzzles[4, 3, 2] = ""; sudokuPuzzles[4, 3, 3] = ""; sudokuPuzzles[4, 3, 4] = ""; sudokuPuzzles[4, 3, 5] = "5"; sudokuPuzzles[4, 3, 6] = ""; sudokuPuzzles[4, 3, 7] = ""; sudokuPuzzles[4, 3, 8] = "";
            sudokuPuzzles[4, 4, 0] = ""; sudokuPuzzles[4, 4, 1] = ""; sudokuPuzzles[4, 4, 2] = ""; sudokuPuzzles[4, 4, 3] = "6"; sudokuPuzzles[4, 4, 4] = ""; sudokuPuzzles[4, 4, 5] = ""; sudokuPuzzles[4, 4, 6] = ""; sudokuPuzzles[4, 4, 7] = ""; sudokuPuzzles[4, 4, 8] = "";
            sudokuPuzzles[4, 5, 0] = ""; sudokuPuzzles[4, 5, 1] = ""; sudokuPuzzles[4, 5, 2] = ""; sudokuPuzzles[4, 5, 3] = ""; sudokuPuzzles[4, 5, 4] = ""; sudokuPuzzles[4, 5, 5] = ""; sudokuPuzzles[4, 5, 6] = "9"; sudokuPuzzles[4, 5, 7] = ""; sudokuPuzzles[4, 5, 8] = "2";
            sudokuPuzzles[4, 6, 0] = ""; sudokuPuzzles[4, 6, 1] = ""; sudokuPuzzles[4, 6, 2] = "1"; sudokuPuzzles[4, 6, 3] = ""; sudokuPuzzles[4, 6, 4] = ""; sudokuPuzzles[4, 6, 5] = "4"; sudokuPuzzles[4, 6, 6] = ""; sudokuPuzzles[4, 6, 7] = "5"; sudokuPuzzles[4, 6, 8] = "";
            sudokuPuzzles[4, 7, 0] = ""; sudokuPuzzles[4, 7, 1] = ""; sudokuPuzzles[4, 7, 2] = ""; sudokuPuzzles[4, 7, 3] = ""; sudokuPuzzles[4, 7, 4] = ""; sudokuPuzzles[4, 7, 5] = ""; sudokuPuzzles[4, 7, 6] = ""; sudokuPuzzles[4, 7, 7] = "3"; sudokuPuzzles[4, 7, 8] = "1";
            sudokuPuzzles[4, 8, 0] = ""; sudokuPuzzles[4, 8, 1] = ""; sudokuPuzzles[4, 8, 2] = ""; sudokuPuzzles[4, 8, 3] = ""; sudokuPuzzles[4, 8, 4] = "8"; sudokuPuzzles[4, 8, 5] = ""; sudokuPuzzles[4, 8, 6] = ""; sudokuPuzzles[4, 8, 7] = ""; sudokuPuzzles[4, 8, 8] = "";



            LoadSudokuPuzzle(0);

            comboBox1.SelectedIndex = 0;

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
            switch (sudokuLevel)
            {
                case 1:
                    LoadSudokuPuzzle(0);
                    break;
                case 2:
                    LoadSudokuPuzzle(2);
                    break;
                case 3:
                    LoadSudokuPuzzle(3);
                    break;
                case 4:
                    LoadSudokuPuzzle(4);
                    break;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    LoadSudokuPuzzle(0);
                    sudokuLevel = 0;
                    break;
                case 1:
                    LoadSudokuPuzzle(1);
                    sudokuLevel = 1;
                    break;
                case 2:
                    LoadSudokuPuzzle(2);
                    sudokuLevel = 2;
                    break;
                case 3:
                    LoadSudokuPuzzle(3);
                    sudokuLevel = 3;
                    break;
                case 4:
                    LoadSudokuPuzzle(4);
                    sudokuLevel = 4;
                    break;

            }
        }
    }
}
