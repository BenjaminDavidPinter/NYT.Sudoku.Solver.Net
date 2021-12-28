using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;


namespace Sudoku.Solver
{
    public class MainClass
    {
        [Params(9)]
        public static int cacheSize;

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(MainClass));
            /*var board = new int[,] {
                { 0, 3, 0, 8, 0, 7, 0, 0, 5 },
                { 0, 0, 0, 0, 0, 5, 0, 0, 3 },
                { 0, 0, 0, 6, 0, 0, 1, 0, 0 },
                { 6, 0, 0, 4, 0, 0, 2, 0, 0 },
                { 2, 0, 0, 0, 0, 0, 4, 8, 9 },
                { 0, 8, 0, 0, 0, 0, 0, 3, 0 },
                { 0, 0, 2, 7, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 6, 0, 0, 0 },
                { 0, 9, 7, 0, 0, 0, 0, 4, 2 } };
            (board, _) = Solve(board, 0, 0, new List<int>(9));
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

        public static bool Validate(int[,] board, int rowPos, int colPos)
        {
            int row,
                column,
                currentValue,
                boardValue;

            boardValue = board[rowPos, colPos];

            for (int j = 0; j < 9; j++)
            {
                if ((j != colPos && boardValue == board[rowPos, j]) ||
                    j != rowPos && boardValue == board[j, colPos])
                {
                    return false;
                }
            }

            for (int o = 0; o < 3; o++)
            {
                for (int p = 0; p < 3; p++)
                {
                    row = o + (3 * (rowPos / 3));
                    column = p + ((colPos / 3) * 3);
                    if (row == rowPos && column == colPos)
                    {
                        continue;
                    }
                    currentValue = board[row, column];

                    if (boardValue == currentValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static (int[,], bool) Solve(int[,] board, int startRow, int startCol, List<int> ExcludedRowValues)
        {
            bool solved = false;
            List<int> excludedColVals = new List<int>(cacheSize);
            for (int i = startRow; i < 9; i++)
            {
                for (int j = startCol; j < 9; j++)
                {
                    var currentBoardValue = board[i, j];
                    for(int q = 0; q < 9; q++)
                    {
                        var colValue = board[q, j];
                        if (colValue != 0)
                        {
                            excludedColVals.Add(colValue);
                        }
                    }
                    if (currentBoardValue == 0)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            if (!ExcludedRowValues.Contains(k) && !excludedColVals.Contains(k))
                            {
                                board[i, j] = k;
                                if (Validate(board, i, j))
                                {
                                    ExcludedRowValues.Add(k);
                                    (board, solved) = Solve(board, i, j, ExcludedRowValues);

                                    if (solved)
                                    {
                                        return (board, solved);
                                    }
                                    else
                                    {
                                        ExcludedRowValues.Remove(k);
                                    }
                                }
                            }
                        }
                        board[i, j] = 0;

                        return (board, false);
                    }
                    else
                    {
                        if (!ExcludedRowValues.Contains(currentBoardValue))
                        {
                            ExcludedRowValues.Add(currentBoardValue);
                        }
                    }
                    excludedColVals.Clear();
                }
                ExcludedRowValues.Clear();
                startCol = 0;
            }
            return (board, true);
        }

        [Benchmark]
        public void Easy_Puzzle()
        {
            var board = new int[,] {
                { 1, 5, 4, 0, 0, 6, 2, 7, 0 },
                { 0, 0, 8, 1, 7, 0, 0, 4, 5 },
                { 0, 0, 6, 4, 9, 0, 0, 1, 0 },
                { 0, 0, 9, 6, 8, 3, 0, 0, 0 },
                { 3, 2, 1, 0, 0, 0, 8, 6, 0 },
                { 6, 0, 0, 0, 0, 1, 9, 3, 0 },
                { 5, 0, 0, 9, 0, 0, 0, 0, 3 },
                { 0, 9, 7, 0, 0, 0, 1, 0, 2 },
                { 8, 0, 0, 0, 5, 4, 0, 0, 0 } };
            (board, _) = Solve(board, 0, 0, new List<int>(cacheSize));


            /*for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
            */
        }

        [Benchmark]
        public void Medium_Puzzle()
        {
            var board = new int[,] {
                { 0, 2, 0, 0, 7, 0, 0, 0, 5 },
                { 0, 0, 1, 0, 0, 0, 8, 7, 0 },
                { 0, 6, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 5, 3, 0, 0 },
                { 0, 0, 4, 0, 0, 6, 0, 5, 0 },
                { 0, 0, 6, 1, 4, 3, 0, 0, 8 },
                { 0, 0, 0, 4, 0, 0, 0, 0, 1 },
                { 0, 0, 8, 0, 0, 1, 0, 0, 0 },
                { 0, 5, 0, 0, 0, 2, 0, 0, 3 } };
            (board, _) = Solve(board, 0, 0, new List<int>(cacheSize));


            /*for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
            */
        }

        [Benchmark]
        public void Hard_Puzzle()
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
            (board, _) = Solve(board, 0, 0, new List<int>(cacheSize));


            /*for (int i = 0; i < 9; i++)
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
