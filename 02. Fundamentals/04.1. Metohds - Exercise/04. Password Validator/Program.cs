namespace _1104._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isPasswordLengther = CheckPasswordLength(password);
            bool isSpecial = CheckSpecialChar(password);
            bool isLeast2Digits = CheckLeast2Digits(password);

            if (!isPasswordLengther && !isSpecial && !isLeast2Digits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckPasswordLength(string inputedPassword)
        {
            bool result = false;
            if(inputedPassword.Length > 10 || inputedPassword.Length < 6)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                result = true;
            }
            return result;
        }

        static bool CheckLeast2Digits(string inputedPassword)
        {
            bool result = false;
            int counter = 0;
            for (int i = 0; i < inputedPassword.Length; i++)
            {
                if (char.IsDigit(inputedPassword[i]))
                {
                    counter++; 
                }
            }
            if(counter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                result = true;
            }
            return result;
        }

        static bool CheckSpecialChar(string inputedPassword)
        {
            bool result = false;
            for (int i = 0;i < inputedPassword.Length; i++)
            {
                if (!char.IsLetterOrDigit(inputedPassword[i]))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    result = true;
                    return result;
                }   
            }
            return result;
        }
    }
}