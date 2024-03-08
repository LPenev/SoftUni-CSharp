namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new();

            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string current in input)
            {
                try
                {
                    string[] currentArray = current.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string face = currentArray[0];
                    char suit = char.Parse(currentArray[1]);

                    Card card = new(face, suit);
                    cards.Add(card);
                }
                catch(InvalidCardException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException)
                {
                    Console.WriteLine(InvalidCardException.InvalidCardExceptionMessage);
                }
            }

            Console.WriteLine(String.Join(" ", cards));
        }

        internal class Card
        {
            private readonly HashSet<string> Faces
                = new() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            private string face;
            private char suit;

            public Card(string face, char suit)
            {
                Face = face;
                Suit = suit;
            }

            public string Face
            {
                get => face;
                private set => face = FaceChecker(value);
            }
            public char Suit
            {
                get => suit;
                private set => suit = SuitChecker(value);
            }

            private string FaceChecker(string face)
            {
                if (!Faces.Contains(face))
                {
                    throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
                }

                return face;
            }

            private char SuitChecker(char suit)
            {
                switch (suit)
                {
                    case 'S':
                        return '\u2660';
                    case 'H':
                        return '\u2665';
                    case 'D':
                        return '\u2666';
                    case 'C':
                        return '\u2663';
                    default:
                        throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
                }
            }

            public override string ToString()
            {
                return $"[{Face}{Suit}]";
            }
        }

        internal class InvalidCardException : Exception
        {
            public const string InvalidCardExceptionMessage = "Invalid card!";
            public InvalidCardException(string invalidCardExceptionMessage)
                : base(invalidCardExceptionMessage) { }
        }
    }
}
