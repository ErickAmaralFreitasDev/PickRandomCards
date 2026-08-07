namespace DeckOfCards
{
    public class Card
    {
        public enum Suit
        {
            Hearts = 1,
            Diamonds = 2,
            Clubs = 3,
            Spades = 4
        }

        public enum Value
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 1
        }

        public Suit suit;
        public Value value;

        private static Random random = new Random();

        public void CardPlay()
        {
            Array suits = Enum.GetValues(typeof(Suit));
            Array values = Enum.GetValues(typeof(Value));

            suit = (Suit)suits.GetValue(random.Next(0, suits.Length));
            value = (Value)values.GetValue(random.Next(0, values.Length));
        }
    }

    public class CardComparerByValue : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            if(x.suit > y.suit)
                return 1;
            else if (x.suit < y.suit)
                return -1;
            else if (x.value > y.value)
                return 1;
            else if (x.value < y.value)
                return -1;
            else
                return 0;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            Console.WriteLine("Enter the number of cards to draw: ");
            if(!int.TryParse(Console.ReadLine(), out int numCards)) return;
            
            for (int i = 0; i < numCards; i++)
            {
                Card card = new Card();
                card.CardPlay();
                cards.Add(card);
            }

            CardComparerByValue comparer = new CardComparerByValue();
            cards.Sort(comparer);
            Console.WriteLine("\nSorted cards by value: ");
            foreach (Card card in cards)
            {
                Console.WriteLine($"{card.value} of {card.suit}");
            }
        }
    }
}
