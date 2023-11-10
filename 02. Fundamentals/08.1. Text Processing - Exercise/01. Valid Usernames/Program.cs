namespace _101._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var validUsernames = new List<string>();
            var usernames = Console.ReadLine().Split(", ");

            foreach (var username in usernames)
            {
                if (isUsernameValid(username))
                {
                    validUsernames.Add(username);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames)); 
        }

        public static bool isUsernameValid(string username)
        {
            if(username.Length < 3 ||  username.Length > 16)
            {
                return false;
            }

            for (int i = 0; i < username.Length; i++)
            {
                if (!(char.IsLetterOrDigit(username[i]) || username[i].Equals('-') || username[i].Equals('_')))
                {
                    return false;
                }
            }
            return true;
        }
    }
}