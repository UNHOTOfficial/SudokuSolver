using System.Diagnostics;

namespace SudokuSolver
{

    public partial class Form1 : Form
    {
        private readonly string[,,] sudokuPuzzles = new string[5, 9, 9];
        private int sudokuLevel;

        private void LoadSudokuPuzzle(int puzzleIndex)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    string textBoxName = "textBox" + row + col;

                    if (Controls.Find(textBoxName, true).FirstOrDefault() is TextBox textBox)
                    {
                        textBox.Text = sudokuPuzzles[puzzleIndex, row, col];
                        textBox.ReadOnly = false;
                    }
                }
            }
        }

        private readonly Sudoku grid;

        public Form1()
        {
            InitializeComponent();

            //Easy
            sudokuPuzzles[0, 0, 0] = "5"; sudokuPuzzles[0, 0, 1] = "3"; sudokuPuzzles[0, 0, 2] = ""; sudokuPuzzles[0, 0, 3] = ""; sudokuPuzzles[0, 0, 4] = "7"; sudokuPuzzles[0, 0, 5] = ""; sudokuPuzzles[0, 0, 6] = ""; sudokuPuzzles[0, 0, 7] = ""; sudokuPuzzles[0, 0, 8] = "";
            sudokuPuzzles[0, 1, 0] = "6"; sudokuPuzzles[0, 1, 1] = ""; sudokuPuzzles[0, 1, 2] = ""; sudokuPuzzles[0, 1, 3] = "1"; sudokuPuzzles[0, 1, 4] = "9"; sudokuPuzzles[0, 1, 5] = "5"; sudokuPuzzles[0, 1, 6] = ""; sudokuPuzzles[0, 1, 7] = ""; sudokuPuzzles[0, 1, 8] = "";
            sudokuPuzzles[0, 2, 0] = ""; sudokuPuzzles[0, 2, 1] = "9"; sudokuPuzzles[0, 2, 2] = "8"; sudokuPuzzles[0, 2, 3] = ""; sudokuPuzzles[0, 2, 4] = ""; sudokuPuzzles[0, 2, 5] = ""; sudokuPuzzles[0, 2, 6] = ""; sudokuPuzzles[0, 2, 7] = "6"; sudokuPuzzles[0, 2, 8] = "";
            sudokuPuzzles[0, 3, 0] = "8"; sudokuPuzzles[0, 3, 1] = ""; sudokuPuzzles[0, 3, 2] = ""; sudokuPuzzles[0, 3, 3] = ""; sudokuPuzzles[0, 3, 4] = "6"; sudokuPuzzles[0, 3, 5] = ""; sudokuPuzzles[0, 3, 6] = ""; sudokuPuzzles[0, 3, 7] = ""; sudokuPuzzles[0, 3, 8] = "3";
            sudokuPuzzles[0, 4, 0] = "4"; sudokuPuzzles[0, 4, 1] = ""; sudokuPuzzles[0, 4, 2] = ""; sudokuPuzzles[0, 4, 3] = "8"; sudokuPuzzles[0, 4, 4] = ""; sudokuPuzzles[0, 4, 5] = "3"; sudokuPuzzles[0, 4, 6] = ""; sudokuPuzzles[0, 4, 7] = ""; sudokuPuzzles[0, 4, 8] = "1";
            sudokuPuzzles[0, 5, 0] = "7"; sudokuPuzzles[0, 5, 1] = ""; sudokuPuzzles[0, 5, 2] = ""; sudokuPuzzles[0, 5, 3] = ""; sudokuPuzzles[0, 5, 4] = "2"; sudokuPuzzles[0, 5, 5] = ""; sudokuPuzzles[0, 5, 6] = ""; sudokuPuzzles[0, 5, 7] = ""; sudokuPuzzles[0, 5, 8] = "6";
            sudokuPuzzles[0, 6, 0] = ""; sudokuPuzzles[0, 6, 1] = "6"; sudokuPuzzles[0, 6, 2] = ""; sudokuPuzzles[0, 6, 3] = ""; sudokuPuzzles[0, 6, 4] = ""; sudokuPuzzles[0, 6, 5] = ""; sudokuPuzzles[0, 6, 6] = "2"; sudokuPuzzles[0, 6, 7] = "8"; sudokuPuzzles[0, 6, 8] = "";
            sudokuPuzzles[0, 7, 0] = ""; sudokuPuzzles[0, 7, 1] = ""; sudokuPuzzles[0, 7, 2] = ""; sudokuPuzzles[0, 7, 3] = "4"; sudokuPuzzles[0, 7, 4] = "1"; sudokuPuzzles[0, 7, 5] = "9"; sudokuPuzzles[0, 7, 6] = ""; sudokuPuzzles[0, 7, 7] = ""; sudokuPuzzles[0, 7, 8] = "5";
            sudokuPuzzles[0, 8, 0] = ""; sudokuPuzzles[0, 8, 1] = ""; sudokuPuzzles[0, 8, 2] = ""; sudokuPuzzles[0, 8, 3] = ""; sudokuPuzzles[0, 8, 4] = "8"; sudokuPuzzles[0, 8, 5] = ""; sudokuPuzzles[0, 8, 6] = ""; sudokuPuzzles[0, 8, 7] = "7"; sudokuPuzzles[0, 8, 8] = "9";

            //Medium
            sudokuPuzzles[1, 0, 0] = ""; sudokuPuzzles[1, 0, 1] = "4"; sudokuPuzzles[1, 0, 2] = ""; sudokuPuzzles[1, 0, 3] = ""; sudokuPuzzles[1, 0, 4] = "9"; sudokuPuzzles[1, 0, 5] = ""; sudokuPuzzles[1, 0, 6] = ""; sudokuPuzzles[1, 0, 7] = "6"; sudokuPuzzles[1, 0, 8] = "";
            sudokuPuzzles[1, 1, 0] = "7"; sudokuPuzzles[1, 1, 1] = ""; sudokuPuzzles[1, 1, 2] = ""; sudokuPuzzles[1, 1, 3] = ""; sudokuPuzzles[1, 1, 4] = ""; sudokuPuzzles[1, 1, 5] = "1"; sudokuPuzzles[1, 1, 6] = "2"; sudokuPuzzles[1, 1, 7] = ""; sudokuPuzzles[1, 1, 8] = "5";
            sudokuPuzzles[1, 2, 0] = "6"; sudokuPuzzles[1, 2, 1] = ""; sudokuPuzzles[1, 2, 2] = ""; sudokuPuzzles[1, 2, 3] = ""; sudokuPuzzles[1, 2, 4] = ""; sudokuPuzzles[1, 2, 5] = "4"; sudokuPuzzles[1, 2, 6] = ""; sudokuPuzzles[1, 2, 7] = "3"; sudokuPuzzles[1, 2, 8] = "";
            sudokuPuzzles[1, 3, 0] = ""; sudokuPuzzles[1, 3, 1] = ""; sudokuPuzzles[1, 3, 2] = ""; sudokuPuzzles[1, 3, 3] = "5"; sudokuPuzzles[1, 3, 4] = ""; sudokuPuzzles[1, 3, 5] = "8"; sudokuPuzzles[1, 3, 6] = ""; sudokuPuzzles[1, 3, 7] = ""; sudokuPuzzles[1, 3, 8] = "";
            sudokuPuzzles[1, 4, 0] = "2"; sudokuPuzzles[1, 4, 1] = ""; sudokuPuzzles[1, 4, 2] = ""; sudokuPuzzles[1, 4, 3] = ""; sudokuPuzzles[1, 4, 4] = "7"; sudokuPuzzles[1, 4, 5] = ""; sudokuPuzzles[1, 4, 6] = ""; sudokuPuzzles[1, 4, 7] = ""; sudokuPuzzles[1, 4, 8] = "1";
            sudokuPuzzles[1, 5, 0] = ""; sudokuPuzzles[1, 5, 1] = ""; sudokuPuzzles[1, 5, 2] = ""; sudokuPuzzles[1, 5, 3] = "9"; sudokuPuzzles[1, 5, 4] = ""; sudokuPuzzles[1, 5, 5] = "6"; sudokuPuzzles[1, 5, 6] = ""; sudokuPuzzles[1, 5, 7] = ""; sudokuPuzzles[1, 5, 8] = "";
            sudokuPuzzles[1, 6, 0] = ""; sudokuPuzzles[1, 6, 1] = "3"; sudokuPuzzles[1, 6, 2] = ""; sudokuPuzzles[1, 6, 3] = "2"; sudokuPuzzles[1, 6, 4] = ""; sudokuPuzzles[1, 6, 5] = ""; sudokuPuzzles[1, 6, 6] = ""; sudokuPuzzles[1, 6, 7] = ""; sudokuPuzzles[1, 6, 8] = "9";
            sudokuPuzzles[1, 7, 0] = "9"; sudokuPuzzles[1, 7, 1] = ""; sudokuPuzzles[1, 7, 2] = "5"; sudokuPuzzles[1, 7, 3] = "6"; sudokuPuzzles[1, 7, 4] = ""; sudokuPuzzles[1, 7, 5] = ""; sudokuPuzzles[1, 7, 6] = ""; sudokuPuzzles[1, 7, 7] = ""; sudokuPuzzles[1, 7, 8] = "";
            sudokuPuzzles[1, 8, 0] = ""; sudokuPuzzles[1, 8, 1] = "7"; sudokuPuzzles[1, 8, 2] = ""; sudokuPuzzles[1, 8, 3] = ""; sudokuPuzzles[1, 8, 4] = "3"; sudokuPuzzles[1, 8, 5] = ""; sudokuPuzzles[1, 8, 6] = ""; sudokuPuzzles[1, 8, 7] = "5"; sudokuPuzzles[1, 8, 8] = "";

            //Hard
            sudokuPuzzles[2, 0, 0] = ""; sudokuPuzzles[2, 0, 1] = ""; sudokuPuzzles[2, 0, 2] = ""; sudokuPuzzles[2, 0, 3] = ""; sudokuPuzzles[2, 0, 4] = ""; sudokuPuzzles[2, 0, 5] = "9"; sudokuPuzzles[2, 0, 6] = ""; sudokuPuzzles[2, 0, 7] = ""; sudokuPuzzles[2, 0, 8] = "";
            sudokuPuzzles[2, 1, 0] = "1"; sudokuPuzzles[2, 1, 1] = ""; sudokuPuzzles[2, 1, 2] = ""; sudokuPuzzles[2, 1, 3] = "6"; sudokuPuzzles[2, 1, 4] = ""; sudokuPuzzles[2, 1, 5] = ""; sudokuPuzzles[2, 1, 6] = "4"; sudokuPuzzles[2, 1, 7] = ""; sudokuPuzzles[2, 1, 8] = "";
            sudokuPuzzles[2, 2, 0] = ""; sudokuPuzzles[2, 2, 1] = ""; sudokuPuzzles[2, 2, 2] = ""; sudokuPuzzles[2, 2, 3] = "5"; sudokuPuzzles[2, 2, 4] = ""; sudokuPuzzles[2, 2, 5] = ""; sudokuPuzzles[2, 2, 6] = "2"; sudokuPuzzles[2, 2, 7] = ""; sudokuPuzzles[2, 2, 8] = "";
            sudokuPuzzles[2, 3, 0] = "4"; sudokuPuzzles[2, 3, 1] = ""; sudokuPuzzles[2, 3, 2] = ""; sudokuPuzzles[2, 3, 3] = ""; sudokuPuzzles[2, 3, 4] = ""; sudokuPuzzles[2, 3, 5] = "2"; sudokuPuzzles[2, 3, 6] = ""; sudokuPuzzles[2, 3, 7] = ""; sudokuPuzzles[2, 3, 8] = "6";
            sudokuPuzzles[2, 4, 0] = ""; sudokuPuzzles[2, 4, 1] = "6"; sudokuPuzzles[2, 4, 2] = ""; sudokuPuzzles[2, 4, 3] = ""; sudokuPuzzles[2, 4, 4] = ""; sudokuPuzzles[2, 4, 5] = ""; sudokuPuzzles[2, 4, 6] = ""; sudokuPuzzles[2, 4, 7] = "1"; sudokuPuzzles[2, 4, 8] = "";
            sudokuPuzzles[2, 5, 0] = "8"; sudokuPuzzles[2, 5, 1] = ""; sudokuPuzzles[2, 5, 2] = ""; sudokuPuzzles[2, 5, 3] = "7"; sudokuPuzzles[2, 5, 4] = ""; sudokuPuzzles[2, 5, 5] = ""; sudokuPuzzles[2, 5, 6] = ""; sudokuPuzzles[2, 5, 7] = ""; sudokuPuzzles[2, 5, 8] = "9";
            sudokuPuzzles[2, 6, 0] = ""; sudokuPuzzles[2, 6, 1] = ""; sudokuPuzzles[2, 6, 2] = "9"; sudokuPuzzles[2, 6, 3] = ""; sudokuPuzzles[2, 6, 4] = ""; sudokuPuzzles[2, 6, 5] = "5"; sudokuPuzzles[2, 6, 6] = ""; sudokuPuzzles[2, 6, 7] = ""; sudokuPuzzles[2, 6, 8] = "";
            sudokuPuzzles[2, 7, 0] = ""; sudokuPuzzles[2, 7, 1] = ""; sudokuPuzzles[2, 7, 2] = "2"; sudokuPuzzles[2, 7, 3] = ""; sudokuPuzzles[2, 7, 4] = ""; sudokuPuzzles[2, 7, 5] = "4"; sudokuPuzzles[2, 7, 6] = ""; sudokuPuzzles[2, 7, 7] = ""; sudokuPuzzles[2, 7, 8] = "7";
            sudokuPuzzles[2, 8, 0] = ""; sudokuPuzzles[2, 8, 1] = ""; sudokuPuzzles[2, 8, 2] = ""; sudokuPuzzles[2, 8, 3] = "9"; sudokuPuzzles[2, 8, 4] = ""; sudokuPuzzles[2, 8, 5] = ""; sudokuPuzzles[2, 8, 6] = ""; sudokuPuzzles[2, 8, 7] = ""; sudokuPuzzles[2, 8, 8] = "";

            //Expert
            sudokuPuzzles[3, 0, 0] = ""; sudokuPuzzles[3, 0, 1] = ""; sudokuPuzzles[3, 0, 2] = ""; sudokuPuzzles[3, 0, 3] = "1"; sudokuPuzzles[3, 0, 4] = ""; sudokuPuzzles[3, 0, 5] = ""; sudokuPuzzles[3, 0, 6] = ""; sudokuPuzzles[3, 0, 7] = ""; sudokuPuzzles[3, 0, 8] = "";
            sudokuPuzzles[3, 1, 0] = ""; sudokuPuzzles[3, 1, 1] = "1"; sudokuPuzzles[3, 1, 2] = ""; sudokuPuzzles[3, 1, 3] = ""; sudokuPuzzles[3, 1, 4] = "6"; sudokuPuzzles[3, 1, 5] = ""; sudokuPuzzles[3, 1, 6] = ""; sudokuPuzzles[3, 1, 7] = ""; sudokuPuzzles[3, 1, 8] = "4";
            sudokuPuzzles[3, 2, 0] = ""; sudokuPuzzles[3, 2, 1] = ""; sudokuPuzzles[3, 2, 2] = ""; sudokuPuzzles[3, 2, 3] = ""; sudokuPuzzles[3, 2, 4] = ""; sudokuPuzzles[3, 2, 5] = "7"; sudokuPuzzles[3, 2, 6] = ""; sudokuPuzzles[3, 2, 7] = "6"; sudokuPuzzles[3, 2, 8] = "";
            sudokuPuzzles[3, 3, 0] = "7"; sudokuPuzzles[3, 3, 1] = ""; sudokuPuzzles[3, 3, 2] = ""; sudokuPuzzles[3, 3, 3] = ""; sudokuPuzzles[3, 3, 4] = ""; sudokuPuzzles[3, 3, 5] = ""; sudokuPuzzles[3, 3, 6] = ""; sudokuPuzzles[3, 3, 7] = "2"; sudokuPuzzles[3, 3, 8] = "";
            sudokuPuzzles[3, 4, 0] = ""; sudokuPuzzles[3, 4, 1] = ""; sudokuPuzzles[3, 4, 2] = "3"; sudokuPuzzles[3, 4, 3] = ""; sudokuPuzzles[3, 4, 4] = ""; sudokuPuzzles[3, 4, 5] = ""; sudokuPuzzles[3, 4, 6] = "5"; sudokuPuzzles[3, 4, 7] = ""; sudokuPuzzles[3, 4, 8] = "";
            sudokuPuzzles[3, 5, 0] = ""; sudokuPuzzles[3, 5, 1] = "9"; sudokuPuzzles[3, 5, 2] = ""; sudokuPuzzles[3, 5, 3] = ""; sudokuPuzzles[3, 5, 4] = ""; sudokuPuzzles[3, 5, 5] = ""; sudokuPuzzles[3, 5, 6] = ""; sudokuPuzzles[3, 5, 7] = ""; sudokuPuzzles[3, 5, 8] = "6";
            sudokuPuzzles[3, 6, 0] = ""; sudokuPuzzles[3, 6, 1] = "2"; sudokuPuzzles[3, 6, 2] = ""; sudokuPuzzles[3, 6, 3] = "4"; sudokuPuzzles[3, 6, 4] = ""; sudokuPuzzles[3, 6, 5] = ""; sudokuPuzzles[3, 6, 6] = ""; sudokuPuzzles[3, 6, 7] = ""; sudokuPuzzles[3, 6, 8] = "";
            sudokuPuzzles[3, 7, 0] = "4"; sudokuPuzzles[3, 7, 1] = ""; sudokuPuzzles[3, 7, 2] = ""; sudokuPuzzles[3, 7, 3] = ""; sudokuPuzzles[3, 7, 4] = "2"; sudokuPuzzles[3, 7, 5] = ""; sudokuPuzzles[3, 7, 6] = ""; sudokuPuzzles[3, 7, 7] = "9"; sudokuPuzzles[3, 7, 8] = "";
            sudokuPuzzles[3, 8, 0] = ""; sudokuPuzzles[3, 8, 1] = ""; sudokuPuzzles[3, 8, 2] = ""; sudokuPuzzles[3, 8, 3] = ""; sudokuPuzzles[3, 8, 4] = ""; sudokuPuzzles[3, 8, 5] = "3"; sudokuPuzzles[3, 8, 6] = ""; sudokuPuzzles[3, 8, 7] = ""; sudokuPuzzles[3, 8, 8] = "";

            //Evil
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
                    string textBoxName = "textBox" + row + col;

                    if (Controls.Find(textBoxName, true).FirstOrDefault() is TextBox textBox)
                    {
                        // Set the font style and size for the TextBox
                        textBox.Font = new Font("Roboto", 9, FontStyle.Bold);

                        // Set the text alignment to center for the TextBox
                        textBox.TextAlign = HorizontalAlignment.Center;
                    }
                }
            }
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            // Check if inputs are valid
            bool inputsValid = CheckInputs();

            if (inputsValid)
            {
                // Read the input grid from the text boxes
                ReadGrid();

                // Solve the Sudoku puzzle
                bool puzzleSolved = grid.Solve();

                if (puzzleSolved)
                {
                    // Update the grid with the solved puzzle
                    UpdateGrid();

                    MessageBox.Show("Sudoku puzzle solved successfully!", "Sudoku Solver");
                }
                else
                {
                    MessageBox.Show("No solution exists for the given puzzle.", "Sudoku Solver");
                }
            }
            else
            {
                MessageBox.Show("Inputs must be a number between 1 and 9.");
            }
        }


        private bool CheckInputs()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox? textBox = Controls.Find("textBox" + row + col, true)[0] as TextBox;
                    if (textBox?.Text != null && textBox.Text != "")
                    {
                        if (!int.TryParse(textBox.Text, out int value) || value > 9)
                        {
                            return false;
                        }
                        else if (string.IsNullOrEmpty(textBox.Text))
                        {
                            return false;
                        }
                    }
                }
            }

            return true; // No invalid inputs found
        }



        private void ReadGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox? textBox = Controls.Find("textBox" + row + col, true)[0] as TextBox;

                    // Check if the textBox is not null or empty
                    if (!string.IsNullOrEmpty(textBox?.Text))
                    {
                        // Parse the value from the textBox and set it in the grid
                        grid.SetCell(row, col, int.Parse(textBox.Text));
                    }
                    else
                    {
                        // If the textBox is null or empty, set the cell value to 0
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
                    TextBox? textBox = Controls.Find("textBox" + row + col, true)[0] as TextBox;

                    // Check if textBox is not null
                    if (textBox != null)
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


        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Load the appropriate puzzle based on the Sudoku level
            int puzzleIndex = sudokuLevel;
            LoadSudokuPuzzle(puzzleIndex);

            // Reset the text boxes to be editable
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (Controls.Find("textBox" + row + col, true)[0] is TextBox textBox)
                    {
                        textBox.ReadOnly = false;
                    }
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Determine the selected puzzle level and load the corresponding puzzle
            int selectedLevel = comboBox1.SelectedIndex;
            LoadSudokuPuzzle(selectedLevel);

            // Update the sudokuLevel variable to reflect the selected level
            sudokuLevel = selectedLevel;
        }


        private void MenuItemSolver_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            // Specify the URL to open
            string url = "https://github.com/UNHOTOfficial/SudokuSolver";

            // Start a new process to open the URL in a web browser
            System.Diagnostics.Process.Start(url);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/UNHOTOfficial/SudokuSolver";

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo = psi;
                process.Start();
            }
        }
    }
}
