using System;
using System.Collections.ObjectModel;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Threading;
using System.Threading.Tasks;


namespace Sudoku.Solver
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(MainClass));
        }

        public static (bool, bool) Validate(int[,] board)
        {
            bool validSudoku = true, solvedSudoku = true;
            for (int h = 0; h < 3; h++)
            {
                for (int q = 0; q < 3; q++)
                {
                    HashSet<int> cube = new HashSet<int>();
                    for (int o = 0; o < 3; o++)
                    {
                        for (int p = 0; p < 3; p++)
                        {
                            int row = o + (3 * h),
                                column = p + (q * 3),
                                currentValue = board[row, column];

                            if (currentValue == 0)
                            {
                                solvedSudoku = false;
                                continue;
                            }

                            if (cube.Contains(currentValue))
                            {
                                return (false, false);
                            }
                            else
                            {
                                cube.Add(currentValue);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (Enumerable.Range(0, board.GetLength(0)).Select(x => board[i, x]).ToArray().GroupBy(x => x).Any(x => x.Key != 0 && x.Count() > 1) ||
                    Enumerable.Range(0, board.GetLength(0)).Select(x => board[x, i]).ToArray().GroupBy(x => x).Any(x => x.Key != 0 && x.Count() > 1))
                {
                    return (false, false);
                }
            }
            return (validSudoku, solvedSudoku);
        }

        public static (int[,], bool) Solve(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            board[i, j] = k;
                            (var validSudoku, var solvedSudoku) = Validate(board);
                            if (solvedSudoku)
                            {
                                return (board, true);
                            }
                            else if (validSudoku)
                            {
                                (board, var solved) = Solve(board);
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
            }
            return (board, false);
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

            (board, var solved) = Solve(board);
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

}
