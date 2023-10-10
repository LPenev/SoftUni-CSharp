namespace _99._Method_Test_Referent_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4 };

            UpdateArray(array);

            Console.WriteLine("[ {0} ]", string.Join(", ", array));
        }

        static void UpdateArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] + 1;
            }
        }
    }
}