using System;
using System.Linq;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool foundWinner = false;
            char userChoice = (char)0;
            char pcChoice = (char)0;
            char[,] matrix = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
            };

        selectCharacter:
            Console.WriteLine("Tic-Tac-Toe");
            Console.WriteLine("Select your character:");
            Console.WriteLine("O/X");
            userChoice = char.Parse(Console.ReadLine());
            if (userChoice == 'X')
            {
                pcChoice = 'O';
            }
            else if (userChoice == 'O')
            {
                pcChoice = 'X';
            }
            else
            {
                Console.WriteLine("Invalid choice!");
                Console.Clear();
                goto selectCharacter;
            }

            Console.Clear();
            Helper.PrintMatrix(matrix);

            while (foundWinner != true)
            {
                string[] move = Console.ReadLine().Split().ToArray();
                int row = new();
                int col = new();

                if (move[0][0] == 'R')
                {
                    row = int.Parse(move[0][1].ToString());
                }

                if (move[1][0] == 'C')
                {
                    col = int.Parse(move[1][1].ToString());
                }

                if (matrix[row - 1, col - 1] != 'O' && matrix[row - 1, col - 1] != 'X')
                {
                    matrix[row - 1, col - 1] = userChoice;
                }
                else
                {
                    Console.WriteLine("Cell occupied!");
                    continue;
                }

                Console.Beep();
                Console.Clear();

                if (!Helper.CheckForWinnerAxis_X(matrix))
                {
                    if (!Helper.CheckForWinnerAxis_Y(matrix))
                    {
                        if (!Helper.CheckForWinnerAxis_Z(matrix))
                        {
                            Helper.PCSelectPoint(ref matrix, pcChoice);
                            Helper.PrintMatrix(matrix);
                            if (Helper.CheckForTie(matrix) == true)
                            {
                                Console.WriteLine("TIE! No winners!");
                                Helper.PlayTieSound();
                                foundWinner = !foundWinner;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                foundWinner = !foundWinner;
            }

            Helper.PlayWinningSound();
            Console.ReadLine();
        }
    }
}
