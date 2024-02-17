using System.Runtime.InteropServices;

namespace _02.Clear_Skies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[squareMatrixSize, squareMatrixSize];

            for (int row = 0; row < squareMatrixSize; row++)
            {
                string input = Console.ReadLine();


                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int jetRow = 0;
            int jetCol = 0;
            int armor = 300;
            int enemyCount = 0;

            // search for jet
            for (int row = 0; row < squareMatrixSize; row++)
            {
                for (int col = 0; col < squareMatrixSize; col++)
                {
                    if (matrix[row, col] == 'E')
                    {
                        enemyCount++;
                    }
                    else if (matrix[row, col] == 'J')
                    {
                        jetRow = row;
                        jetCol = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            while (armor > 0 && enemyCount > 0)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        jetRow--;
                        break;

                    case "down":
                        jetRow++;
                        break;

                    case "left":
                        jetCol--;
                        break;

                    case "right":
                        jetCol++;
                        break;
                }

                if (matrix[jetRow, jetCol] == 'R')
                {
                    armor = 300;
                    matrix[jetRow, jetCol] = '-';
                }
                else if (matrix[jetRow, jetCol] == 'E')
                {
                    enemyCount--;
                    armor -= 100;
                    matrix[jetRow, jetCol] = '-';
                }
            }
            // last positon of Jet
            matrix[jetRow, jetCol] = 'J';

            if(enemyCount == 0)
            {
                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
            }
            else
            {
                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetRow}, {jetCol}]!");
            }

            // print matrix
            for (int row = 0; row < squareMatrixSize; row ++)
            {
                for(int col = 0; col < squareMatrixSize; col ++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
