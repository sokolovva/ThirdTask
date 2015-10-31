using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WordGame
{
class WordGame
{
        static void Main()
        {

            //declaration
            int counter = 0;
            Console.Write("Number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Number of cols: ");
            int cols = int.Parse(Console.ReadLine());
          
            char[,] matrix = new char[rows, cols];
            Console.WriteLine("Enter the cells of the matrix: ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                input.ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            Console.WriteLine("The word u are searchin for: ");
            string findThisString = Console.ReadLine();
            char[] letters = findThisString.ToCharArray();


            FindWord(matrix, findThisString, letters);
        }

        private static void FindWord(char[,] matrix, string findThisString, char[] letters)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            Console.WriteLine("The occurences of the " + findThisString + " in the table is "+( SearchingWordByDiagonals(matrix, findThisString, rows, cols) +
                              SearchingWordByColsReversedWay(matrix, letters) +
                              SearchingWordByCols(matrix, letters) +
                              SearchingWordByRowsReversedWay(matrix, letters) +
                              SearchingWordByRows(matrix, letters)));
        }


        private static int SearchingWordByDiagonals(char[,] matrix, string findThisString, int rows, int cols)
        {
            int counter = 0;
          
            StringBuilder stringb = new StringBuilder();
            StringBuilder secondString = new StringBuilder();
            for (int i = findThisString.Length - rows; i <= cols - findThisString.Length; i++)
            {
                for (int j = 0; j < Math.Min(rows, cols); j++)
                {

                    if (i <= 0)
                    {
                        if (j + Math.Abs(i) < rows)
                        {
                            stringb.Append(matrix[j + Math.Abs(i), j]);
                            secondString.Append(matrix[j + Math.Abs(i), cols - j - 1]);
                        }
                    }
                    else
                    {
                        if (j + i <= cols)
                        {
                            stringb.Append(matrix[j, j + i]);
               
                            secondString.Append(matrix[rows - j - 1, j + i]);
                        }
                    }
                }
                counter += subStringCounter(stringb.ToString(), findThisString);
                counter += subStringCounter(secondString.ToString(), findThisString);

                stringb = new StringBuilder(Reverse(stringb.ToString()));
                secondString = new StringBuilder(Reverse(secondString.ToString()));
                counter += subStringCounter(stringb.ToString(), findThisString);
                counter += subStringCounter(secondString.ToString(), findThisString);
                stringb = new StringBuilder();
                secondString = new StringBuilder();
            }
            return counter;
        }
        private static string Reverse(string stringG)
        {
            char[] reversed = stringG.ToCharArray();
            StringBuilder reverse = new StringBuilder();
            for (int i = stringG.Length - 1; i >= 0; i--)
            {
                reverse.Append(reversed[i]);
            }
            return reverse.ToString();
        }

        private static int subStringCounter(string inputDirections, String findThisString)
        {
            int counter = 0;
            for (int i = 0; i < inputDirections.Length; i++)
            {
                if (inputDirections.Contains(findThisString))
                {
                    counter++;
                    inputDirections = inputDirections.Substring(inputDirections.IndexOf(findThisString) + findThisString.Length);
                }
            }

            return counter;
        }

        private static int SearchingWordByColsReversedWay(char[,] matrix, char[] letters)
        {
            int moving = 0;
            int counter = 0;
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                moving = 0;
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == letters[moving])
                    {
                        moving++;
                        if (moving == letters.Length)
                        {
                            counter++;
                            moving = 0;
                        }
                    }
                }

            }
            return counter;
        }
        private static int SearchingWordByCols(char[,] matrix, char[] letters)
        {
            int moving = 0;
            int counter = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                moving = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] == letters[moving])
                    {
                        moving++;
                        if (moving == letters.Length)
                        {
                            counter++;
                            moving = 0;
                        }
                    }
                }
            }
            return counter;
        }



        private static int SearchingWordByRowsReversedWay(char[,] matrix, char[] letters
            )
        {
            int moving = 0;
            int counter = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                moving = 0;
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    if (matrix[row, col] == letters[moving])
                    {
                        moving++;
                        if (moving == letters.Length)
                        {
                            counter++;
                            moving = 0;
                        }
                    }
                }
            }
            return counter;
        }

        private static int SearchingWordByRows(char[,] matrix, char[] letters)
        {
            int moving = 0;
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                moving = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == letters[moving])
                    {
                        moving++;
                        if (moving == letters.Length)
                        {
                            counter++;
                            moving = 0;
                        }
                    }
                }
            }
            return counter;



        }
    }
}








