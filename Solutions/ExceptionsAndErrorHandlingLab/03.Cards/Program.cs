List<Card> cards = new List<Card> ();

string[] cardArgs = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

foreach (var cardArg in cardArgs)
{
    string[] faceSuit = cardArg
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    Card card = CreateCard(faceSuit[0], faceSuit[1]);

    if(card is not null)
    {
        cards.Add(card);
    }
}

Card CreateCard(string face, string suit)
{
    string[] allowedFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    string[] allowedSuits = { "S", "H", "D", "C" };

    try
    {
        if(!allowedFaces.Contains(face) || !allowedSuits.Contains(suit))
        {
            throw new ArgumentException("Invalid card!");
        }
        return new Card(face, suit);
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }

    return null;
}

Console.WriteLine(String.Join(" ", cards));

class Card
{
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face { get; set; }

    public string Suit
    {
        get 
        {
            switch (suit)
            {
                case "S":
                    return "\u2660";
                case "H":
                    return "\u2665";
                case "D":
                    return "\u2666";
                case "C":
                    return "\u2663";
                default:
                    return default(string);
            }
        }
        set { suit = value; }
    }

    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }

}