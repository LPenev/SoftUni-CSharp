using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] personInputArray = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string personInput in personInputArray)
                {
                    string[] personArray = personInput
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = personArray[0];
                    decimal money = decimal.Parse(personArray[1]);

                    Person person = new Person(name, money);
                    persons.Add(person);
                }

                string[] productInputArray = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string productInput in productInputArray)
                {
                    string[] productArray = productInput.Split('=');
                    string name = productArray[0];
                    decimal cost = decimal.Parse(productArray[1]);

                    Product product = new Product(name, cost);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArray = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string nameOfPerson = inputArray[0];
                string nameOfProduct = inputArray[1];

                var currentProduct = products.FirstOrDefault(x => x.Name == nameOfProduct);
                var currentPerson = persons.FirstOrDefault(x => x.Name == nameOfPerson);


                if (currentPerson is not null && currentProduct is not null)
                {
                    Console.WriteLine(currentPerson.Add(currentProduct));
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, persons));
        }
    }
}
