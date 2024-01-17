SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

// read products from console and add them into dictionary
string input = string.Empty;
while((input = Console.ReadLine()) != "Revision")
{
    string[] inputArray = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string shopName = inputArray[0];
    string productName = inputArray[1];
    double productPrice = double.Parse(inputArray[2]);

    if (!shops.ContainsKey(shopName))
    {
        shops.Add(shopName,new Dictionary<string, double>());
    }

    if (!shops[shopName].ContainsKey(productName))
    {
        shops[shopName][productName] = productPrice;
    }

    shops[shopName][productName] = productPrice;
}

// print result
foreach(var shopName in shops)
{
    Console.WriteLine($"{shopName.Key}->");

    foreach(var product in shops[shopName.Key])
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
}