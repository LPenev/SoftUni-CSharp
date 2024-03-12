namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new();

            string[] inputArray = Console.ReadLine()
                .Split(',');

            foreach (string currntElement in inputArray)
            {
                string[] currentElementArray = currntElement
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                int account = int.Parse(currentElementArray[0]);
                double balance = double.Parse(currentElementArray[1]);

                accounts.Add(account, balance);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArray = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArray[0];
                int account = int.Parse(commandArray[1]);
                double sum = double.Parse(commandArray[2]);

                try
                {

                    if (!accounts.ContainsKey(account))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    switch (command)
                    {
                        // Add the given sum to the given account`s balance
                        case "Deposit":
                            accounts[account] += sum;
                            break;

                        // Subtract the given sum from the account`s balance
                        case "Withdraw":

                            if (accounts[account] < sum)
                            {
                                throw new ArgumentException("Insufficient balance!");
                            }

                            accounts[account] -= sum;
                            break;

                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                    Console.WriteLine($"Account {account} has new balance: {accounts[account]:F2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally 
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
