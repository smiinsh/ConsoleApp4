using System;

namespace ConsoleApp4
{
    public class sudoku
    {
        private int[,] box;
        public sudoku(int[,] grid)
        {
            this.box = box;
        }
        public sudoku() { }
        public bool result()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (box[i, j] == 0)
                    {
                        for (int x = 1; x <= 9; x++)
                        {
                            if (IsSafe(i, j, x))
                            {
                                box[i, j] = x;
                                if (result())
                                    return true;
                                box[i, j] = 0;
                            }
                        }
                        return false;
                        Console.WriteLine("riddle is not solved!");
                    }
                }
            }
            return true;
        }
        private bool IsSafe(int row, int col, int x)
        {
            for (int i = 0; i < 9; i++)
            {
                if (box[row, i] == x)
                    return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (box[i, col] == x)
                    return false;
            }
            int blockRow = row / 3;
            int blockCol = col / 3;
            for (int i = blockRow * 3; i < blockRow * 3 + 3; i++)
            {
                for (int j = blockCol * 3; j < blockCol * 3 + 3; j++)
                {
                    if (box[i, j] == x)
                        return false;
                }
            }
            return true;
        }
        public static void Main()
        {
            int[,] grid = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 0; j++)
                {
                    Console.WriteLine("enter number: ", j + 1, i + 1);
                    string input = Console.ReadLine();
                    if (input == " ")
                    {
                        input = "0";
                    }
                    grid[i, j] = Convert.ToInt32(input);
                }
            }
            sudoku th = new sudoku(grid);
            bool solved = th.result();
            if (solved)
            {
                Console.WriteLine('\n');
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(th.box[i, j] + " | ");
                    }
                    Console.WriteLine("\n----------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("the riddle is not solvable.");
            }
        }

    }
}

