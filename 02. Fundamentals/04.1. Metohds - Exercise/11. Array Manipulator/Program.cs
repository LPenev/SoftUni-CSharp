using System;

namespace _1111._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string inputedCommand = Console.ReadLine();
            
            while (inputedCommand != "end")
            {
                string[] command = inputedCommand.Split().ToArray();

                switch (command[0])
                {
                    case "exchange":
                        CommandExchange(ref input,int.Parse(command[1]));
                        break;
                    case "max":
                        CommandMax(input,command[1] == "even");
                        break;
                    case "min":
                        CommandMin(input, command[1] == "even");
                        break;
                    case "first":
                        CommandFirst(input, int.Parse(command[1]), command[2] == "even");
                        break;
                    case "last":
                        CommandLast(input, int.Parse(command[1]), command[2] == "even");
                        break;
                }
                inputedCommand = Console.ReadLine();
            }
            Console.WriteLine("[{0}]",string.Join(", ", input));
        }

        static void CommandExchange(ref int[] input, int index)
        {
            if(input.Length <= index || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            input = input.Skip(index + 1).Take(input.Length - index).Concat(input.Take(index+1)).ToArray();
        }

        static void CommandMax(int[] array,bool isEven)
        {
            if (!array.Any(x => isEven == (x%2 == 0)))
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int max = array.Where(x => isEven == (x%2 ==0)).Max();
                Console.WriteLine(Array.LastIndexOf(array,max));
            }
        }
        static void CommandMin(int[] array, bool isEven)
        {
            if (!array.Any(x => isEven == (x % 2 == 0)))
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int min = array.Where(x => isEven == (x % 2 == 0)).Min();
                Console.WriteLine(Array.LastIndexOf(array, min));
            }
        }
        static void CommandFirst(int[] array, int count, bool isEven)
        {
            if (isCountValid(array, count))
            {
                int[] result = array.Where(x => isEven == (x%2 == 0)).Take(count).ToArray();
                Console.WriteLine("[{0}]", string.Join(", ", result));
            }
        }
        static void CommandLast(int[] array, int count, bool isEven)
        {
            if(isCountValid(array, count))
            {
                int[] result = array.Where(x => isEven == (x%2 == 0)).TakeLast(count).ToArray();
                Console.WriteLine("[{0}]", string.Join(", ",result));
            }
        }

        static bool isCountValid(int[] array, int count)
        {
            if (array.Length < count)
            {
                Console.WriteLine("Invalid count");
                return false;
            }
            return true;
        }
    }
}