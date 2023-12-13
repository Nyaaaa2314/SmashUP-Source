using System.Security.Cryptography.X509Certificates;

public class Player{
    public String name;
    public Faction faction1;
    public Faction faction2;

    public Stack<Card> deck;
    public List<Card> discard;
    public List<Card> hand;
    public int VP;
    public int currentMinionPlays;
    public int currentActionPlays;
    public Player(String name, int FID1, int FID2){
        this.name = name;
        this.faction1 = FactionFactory.genFaction(FID1, this);
        this.faction2 = FactionFactory.genFaction(FID2, this);
        List<Card> temp = faction1.getCards();
        temp.AddRange(faction2.getCards());
        this.deck = new Stack<Card>(temp.OrderBy(x => new Random().Next()));
        //Console.WriteLine("\n\n\n" + deck.Count + "\n\n\n");
        this.discard = new List<Card>();
        this.hand = new List<Card>();
        this.VP = 0;
        this.currentMinionPlays = 1;
        this.currentActionPlays = 1;
    }

    public void resetPlays(){
        this.currentMinionPlays = 1;
        this.currentActionPlays = 1;
    }
    
}