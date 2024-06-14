using System;
using System.Collections.Generic;

namespace Kaartspel
{
    // Enum die de vier kleuren in een standaard kaartspel vertegenwoordigt
    public enum Suits
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Higher/Lower Card Game!");
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Welcome, {playerName}, let's start the game!");

            // Maak en schud het deck
            Deck deck = new Deck();
            deck.Shuffle();

            int score = 0;
            Card previousCard = null;

            // Game loop
            while (deck.Cards.Count > 0)
            {
                if (previousCard != null)
                {
                    // Toon de vorige kaart en vraag de gebruiker om te raden
                    Console.WriteLine($"Previous card: {previousCard}");
                    Console.WriteLine("Do you think the next card will be (h)igher, (l)ower, or same (s)uit?");
                    char guess = Console.ReadKey().KeyChar;
                    Console.WriteLine(); // Nieuwe regel voor duidelijkheid

                    // Trek de volgende kaart
                    Card currentCard = deck.DrawCard();
                    Console.WriteLine($"Next card: {currentCard}");

                    // Vergelijk de kaarten en bepaal de score
                    bool correctGuess = false;
                    if (guess == 'h' && currentCard > previousCard)
                    {
                        correctGuess = true;
                    }
                    else if (guess == 'l' && currentCard < previousCard)
                    {
                        correctGuess = true;
                    }
                    else if (guess == 's' && currentCard.CardSuit == previousCard.CardSuit)
                    {
                        correctGuess = true;
                    }

                    if (correctGuess)
                    {
                        Console.WriteLine("Correct guess!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong guess.");
                    }

                    previousCard = currentCard; // Zet de huidige kaart als vorige kaart voor volgende ronde
                }
                else
                {
                    // Trek de eerste kaart
                    previousCard = deck.DrawCard();
                    Console.WriteLine($"First card: {previousCard}");
                }

                // Vraag om Esc-toets te drukken om te stoppen
                Console.WriteLine("Press Esc to quit, or any other key to continue.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Clear();
            }

            // Einde van het spel
            Console.WriteLine($"Game over, {playerName}. Your final score is: {score}");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class Card
    {
        public Suits CardSuit { get; }
        public string Rank { get; }

        private static readonly Dictionary<string, int> RankValues = new Dictionary<string, int>
        {
            {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
            {"Jack", 11}, {"Queen", 12}, {"King", 13}, {"Ace", 14}
        };

        public Card(Suits suit, string rank)
        {
            CardSuit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank} of {CardSuit}";
        }

        public int CompareTo(Card other)
        {
            return RankValues[this.Rank].CompareTo(RankValues[other.Rank]);
        }

        public static bool operator >(Card c1, Card c2)
        {
            return c1.CompareTo(c2) > 0;
        }

        public static bool operator <(Card c1, Card c2)
        {
            return c1.CompareTo(c2) < 0;
        }
    }

    public class Deck
    {
        public List<Card> Cards { get; }

        public Deck()
        {
            Cards = new List<Card>();
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (string rank in ranks)
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }

        public Card DrawCard()
        {
            if (Cards.Count == 0) throw new InvalidOperationException("No cards left in the deck");
            Card drawnCard = Cards[0];
            Cards.RemoveAt(0);
            return drawnCard;
        }
    }
}