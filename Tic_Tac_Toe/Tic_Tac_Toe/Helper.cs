using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public static class Helper
    {
        public static void PrintMatrix(char[,] _matrix)
        {
            Console.WriteLine($" {_matrix[0, 0]} | {_matrix[0, 1]} | {_matrix[0, 2]}");
            Console.WriteLine($"-----------");
            Console.WriteLine($" {_matrix[1, 0]} | {_matrix[1, 1]} | {_matrix[1, 2]}");
            Console.WriteLine($"-----------");
            Console.WriteLine($" {_matrix[2, 0]} | {_matrix[2, 1]} | {_matrix[2, 2]}");
        }

        public static bool CheckForWinnerAxis_X(char[,] _matrix)
        {
            if (_matrix[0, 0] == 'X' && _matrix[0, 1] == 'X' && _matrix[0, 2] == 'X' ||
                _matrix[1, 0] == 'X' && _matrix[1, 1] == 'X' && _matrix[1, 2] == 'X' ||
                _matrix[2, 0] == 'X' && _matrix[2, 1] == 'X' && _matrix[2, 2] == 'X')
            {
                PrintMatrix(_matrix);
                Console.WriteLine("Player \"X\" wins!");
                return true;
            }

            if (_matrix[0, 0] == 'O' && _matrix[0, 1] == 'O' && _matrix[0, 2] == 'O' ||
                _matrix[1, 0] == 'O' && _matrix[1, 1] == 'O' && _matrix[1, 2] == 'O' ||
                _matrix[2, 0] == 'O' && _matrix[2, 1] == 'O' && _matrix[2, 2] == 'O')
            {
                PrintMatrix(_matrix);
                Console.WriteLine("Player \"O\" wins!");
                return true;
            }

            return false;
        }

        public static bool CheckForWinnerAxis_Y(char[,] _matrix)
        {
            if (_matrix[0, 0] == 'X' && _matrix[1, 0] == 'X' && _matrix[2, 0] == 'X' ||
                _matrix[0, 1] == 'X' && _matrix[1, 1] == 'X' && _matrix[2, 1] == 'X' ||
                _matrix[0, 2] == 'X' && _matrix[1, 2] == 'X' && _matrix[2, 2] == 'X')
            {
                PrintMatrix(_matrix);
                Console.WriteLine("Player \"X\" wins!");
                return true;
            }

            if (_matrix[0, 0] == 'O' && _matrix[1, 0] == 'O' && _matrix[2, 0] == 'O' ||
                _matrix[0, 1] == 'O' && _matrix[1, 1] == 'O' && _matrix[2, 1] == 'O' ||
                _matrix[0, 2] == 'O' && _matrix[1, 2] == 'O' && _matrix[2, 2] == 'O')
            {
                PrintMatrix(_matrix);
                Console.WriteLine("Player \"O\" wins!");
                return true;
            }

            return false;
        }

        public static bool CheckForWinnerAxis_Z(char[,] _matrix)
        {
            if (_matrix[0, 0] == 'X' && _matrix[1, 1] == 'X' && _matrix[2, 2] == 'X' ||
                _matrix[0, 2] == 'X' && _matrix[1, 1] == 'X' && _matrix[2, 0] == 'X')
            {
                PrintMatrix(_matrix);
                Console.WriteLine("Player \"X\" wins!");
                return true;
            }

            if (_matrix[0, 0] == 'O' && _matrix[1, 1] == 'O' && _matrix[2, 2] == 'O' ||
                _matrix[0, 2] == 'O' && _matrix[1, 1] == 'O' && _matrix[2, 0] == 'O')
            {
                PrintMatrix(_matrix);
                Console.WriteLine("Player \"O\" wins!");
                return true;
            }

            return false;
        }

        public static bool CheckForTie(char[,] _matrix)
        {
            bool hasFoundEmptyCell = false;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (_matrix[row, col] == ' ')
                    {
                        hasFoundEmptyCell = true;
                    }
                }
            }

            if (hasFoundEmptyCell == false)
            {
                return true;
            }

            return false;
        }

        private static void CheckForFreeCells(char[,] _matrix, ref List<int> _freeRows, ref List<int> _freeCols)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (_matrix[row, col] == ' ')
                    {
                        _freeRows.Add(row);
                        _freeCols.Add(col);
                    }
                }
            }
        }

        public static void PCSelectPoint(ref char[,] _matrix, char _pcChar)
        {
            List<int> freeRows = new List<int>();
            List<int> freeCols = new List<int>();

            CheckForFreeCells(_matrix, ref freeRows, ref freeCols);

            int freeRowsLen = freeRows.Count;

            int randomPosition = new Random().Next(freeRowsLen);

            if (!CheckForTie(_matrix))
            {
                _matrix[freeRows[randomPosition], freeCols[randomPosition]] = _pcChar;
            }
        }

        public static void PlayTieSound()
        {
            for (int beepIteration = 1; beepIteration < 10; beepIteration++)
            {
                Console.Beep(250, 200);
            }
        }

        public static void PlayWinningSound()
        {
            for (int beepIteration = 1; beepIteration < 10; beepIteration++)
            {
                Console.Beep(500, 200);
            }
        }
    }
}
