using System.Runtime;

namespace _01._03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pieces = new List<Piece>();

            var countOfPieses = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfPieses; i++)
            {
                var currentPiece = Console.ReadLine().Split("|");
                var nameOfPiece = currentPiece[0];
                var composer = currentPiece[1];
                var key = currentPiece[2];

                pieces.Add(new Piece(nameOfPiece, composer, key));
            }

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                var inputArray = input.Split("|");
                var command = inputArray[0];
                var piece = inputArray[1];
                var isPieceExist = pieces.Any(x => x.Name == piece);
                
                switch (command)
                {
                    case "Add":        
                        if (isPieceExist)
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        else
                        {
                            var composer = inputArray[2];
                            var key = inputArray[3];
                            pieces.Add(new Piece(piece, composer, key));
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!"); 
                        }
                        break;

                    case "Remove":
                        if (isPieceExist)
                        {
                            var toRemove = pieces.FirstOrDefault(x => x.Name == piece);
                            pieces.Remove(toRemove);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;

                    case "ChangeKey":
                        if (isPieceExist)
                        {
                            string newKey = inputArray[2];
                            var currentPiece = pieces.FirstOrDefault(x => x.Name == piece);
                            currentPiece.Key = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                }
            }

            // print result
            foreach ( Piece piece in pieces)
            {
                string name = piece.Name;
                string composer = piece.Composer;
                string key = piece.Key;
                Console.WriteLine($"{name} -> Composer: {composer}, Key: {key}");
            }
        }
    }
    public class Piece
    {
        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
