int inputDigit = int.Parse(Console.ReadLine());

for (int i = 1; i <= inputDigit; i++)
{
    bool isSpecialNum = false;
    int sumOfDigits = 0;
    int current = i;
    while (current > 0)
    {
        sumOfDigits += current % 10;
        current = current / 10;
    }
    isSpecialNum = sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11;
    Console.WriteLine("{0} -> {1}", i, isSpecialNum);
}