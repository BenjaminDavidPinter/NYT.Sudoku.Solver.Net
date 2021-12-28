using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;


namespace Sudoku.Solver
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(MainClass));
        }

        public static bool Validate(int[,] board, int rowPos, int colPos)
        {
            List<int> cube = new List<int>(7);
            int row,
                column,
                currentValue;

            for (int o = 0; o < 3; o++)
            {
                for (int p = 0; p < 3; p++)
                {
                    row = o + (3 * (rowPos / 3));
                    column = p + ((colPos / 3) * 3);
                    currentValue = board[row, column];

                    if (cube.Contains(currentValue))
                    {
                        return false;
                    }
                    else
                    {
                        if (currentValue != 0)
                        {
                            cube.Add(currentValue);
                        }
                    }
                }
            }


            List<int> rowValues = new List<int>(9);
            int rowValue;


            for (int j = 0; j < 9; j++)
            {
                rowValue = board[rowPos, j];
                if (rowValues.Contains(rowValue))
                {
                    return false;
                }
                else
                {
                    if (rowValue != 0)
                    {
                        rowValues.Add(rowValue);
                    }
                }
            }


            List<int> columnValues = new List<int>(9);
            int columnValue;


            for (int j = 0; j < 9; j++)
            {
                columnValue = board[j, colPos];
                if (columnValues.Contains(columnValue))
                {
                    return false;
                }
                else
                {
                    if (columnValue != 0)
                    {
                        columnValues.Add(columnValue);
                    }
                }
            }

            return true;
        }

        public static (int[,], bool) Solve(int[,] board, int startRow, int startCol)
        {
            bool validSudoku = false,
                 solved = false;
            for (int i = startRow; i < 9; i++)
            {
                for (int j = startCol; j < 9; j++)
                {
                    if (board[i, j] == 0)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            board[i, j] = k;
                            validSudoku = Validate(board, i, j);
                            if (validSudoku)
                            {
                                (board, solved) = Solve(board, i, j);

                                if (solved)
                                {
                                    return (board, solved);
                                }
                            }
                        }
                        board[i, j] = 0;

                        return (board, false);
                    }
                }
                startCol = 0;
            }
            return (board, true);
        }

        [Benchmark]
        public void Solve_A_Puzzle()
        {
            var board = new int[,] {
                { 0, 3, 0, 8, 0, 7, 0, 0, 5 },
                { 0, 0, 0, 0, 0, 5, 0, 0, 3 },
                { 0, 0, 0, 6, 0, 0, 1, 0, 0 },
                { 6, 0, 0, 4, 0, 0, 2, 0, 0 },
                { 2, 0, 0, 0, 0, 0, 4, 8, 9 },
                { 0, 8, 0, 0, 0, 0, 0, 3, 0 },
                { 0, 0, 2, 7, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 6, 0, 0, 0 },
                { 0, 9, 7, 0, 0, 0, 0, 4, 2 } };
            (board, _) = Solve(board, 0, 0);

            /*
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
            */
        }

    }
}
