namespace Kaartspel;

internal class Program
{
    private static void Main(string[] args)
    {
       
        //Maak een kaartspel template met een class of struct voor een kaart en een class voor een deck(een set van een x-aantal kaarten).
        //Zorg voor logische invullingen van beide classes en/of structs.
        //Wanneer een deck geinstantieerd wordt moet het gevuld worden met de juiste 52 kaarten.
        //Zorg voor duidelijk commentaar op de juiste plekken.
        //Vraag om de speler naam en gebruik deze in je communicatie met de speler.
        // Zorg voor een game loop die pas ophoudt als de speler de esc-toets indrukt, dit is de enige mogelijkheid om de applicatie te laten eindigen.
    }
}

public class Card
{
    public string suit { get; }
    public string rank { get; }

    public Card(string suit, string rank)
    {
        suit = suit;
        rank = rank;
    }

    public override string ToString()
    {
        return $"{suit} {rank}";
    }
}

public class Deck
{
    public List<Card> Cards { get; }
    
    public enum Suits
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public Deck()
    {
        //ik maak een array van een string aan van alle ranks en jack queen king en aces
        string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
        Cards = Cards;
        foreach (var Suits in Enum.GetNames(typeof(Suits)))
        {
            foreach (var rank in Ranks)
            {
                Cards.Add(new Card(Suits, rank));
            }
        }
    }

    public void Shuffle()
    {
        Random rnd = new Random();
        int a = Cards.Count;
        while (a > 0)
        {
            a--;
            int k = rnd.Next(a + 1);
            // Wissel de positie van de kaarten op index k en a in het deck
            Card value = Cards[k];
            Cards[k] = Cards[a];
            Cards[a] = value;
        }
    }

    public void DrawCard()
    {
        if (Cards.Count == 0) throw new InvalidOperationException("No cards left in the deck");
        {
            Card drawn = Cards[0];
            Cards.RemoveAt(0);
        }
    }
}

