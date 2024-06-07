namespace Kaartspel;

class Program
{
   public List<string> kaarten = new List<string> {};
    static void Main(string[] args)
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
    private List Cards;
    
    public struct Card
    {
        public string suit;
        public string rank;
    }
    public Deck()
    {
        string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
        Cards = Cards;
        public enum suits
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        }
        
        
    }
}