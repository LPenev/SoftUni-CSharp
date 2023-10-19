namespace _06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] infoArray = input.Split();

                string serialNumber = infoArray[0];
                string itemName = infoArray[1];
                int itemQnty = int.Parse(infoArray[2]);
                decimal itemPrice = decimal.Parse(infoArray[3]);

                Item item = new Item
                {
                    Name = itemName,
                    Price = itemPrice,
                };

                Box box = new Box
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    ItemQuantity = itemQnty,
                    PriceForBoxPrice = itemPrice * itemQnty,
                };

                boxes.Add(box);

                input = Console.ReadLine();
            }

            foreach (Box box in boxes.OrderByDescending(x => x.PriceForBoxPrice))
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBoxPrice:F2}");
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Box
    {
        //Box()
        //{
        //    Item = new Item();
        //}
        public string SerialNumber {  get; set; }
        public Item Item {  get; set; }
        public int ItemQuantity {  get; set; }
        public decimal PriceForBoxPrice { get; set; }
    }
}