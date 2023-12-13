using System.Runtime.CompilerServices;
using SmashUP;
public class Robots : Faction {

    //FID = 0
    Player player;
    public List<Card> cards;
    public Robots(Player player){
        this.player = player;
        cards = genCards();
        //Console.WriteLine("\n\n\n" + cards.Count + "\n\n\n");
    }
    
    //String name, String faction, int basePower, int currentPower, Boolean isMinion, String ability, Player owner
    public List<Card> genCards(){
        List<Card> cards = new List<Card>();
        for(int i = 0; i < 4; i++){
            cards.Add(new Card("Zapbot", "Robots", 2, 2, true, "Play an extra minion of power 2 or less", player));
        }
        for(int i = 0; i < 3; i++){
            cards.Add(new Card("Hoverbot", "Robots", 3, 3, true, "", player));
        }
        cards.Add(new Card("Warbot", "Robots",4,4,true,"",player));
        cards.Add(new Card("Warbot", "Robots",4,4,true,"",player));
        cards.Add(new Card("Nukebot", "Robots",5,5,true,"",player));
        cards.Add(new Card("Microbot Fixer", "Robots",1,1,true,"",player,8));
        cards.Add(new Card("Microbot Fixer", "Robots",1,1,true,"",player,8));
        cards.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",player,8));
        cards.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",player,8));
        cards.Add(new Card("Microbot Guard","Robots",1,1,true,"",player,4 | 8 ));
        cards.Add(new Card("Microbot Guard", "Robots", 1, 1, true, "", player,4 | 8));
        cards.Add(new Card("Microbot Archive","Robots",1,1,true,"",player, 8));
        cards.Add(new Card("Microbot Alpha","Robots",1,1,true,"+1 Power for every other microbot in play",player, 8));
        cards.Add(new Card("Test Card", "Robots", 1,1,true,"Destroy one card on base", player));
        cards.Add(new Card("Tech Center","Robots",0,0,false,"Draw cards equal to number of minions on a base", player));
        cards.Add(new Card("Tech Center","Robots",0,0,false,"Draw cards equal to number of minions on a base", player));
        return cards;
    }

    public static void procAbility(Card c){
        if (c.name == "Nukebot") {
            if((c.flags & 1) == 1){
                Base b = GameState.gs.findBaseOf(c.lastBase);
                //Console.WriteLine(b.name);
                List<Card> toDestroy = new List<Card>();
                foreach(Card card in b.onBase){
                    if(card.owner != c.owner && !((card.flags & 4) == 4)){
                        toDestroy.Add(card);
                    }
                }
                foreach(Card card in toDestroy){
                    Effects.destroyCard(card);
                }
            }
        }
        if(c.name == "Test Card"){
            if((c.flags & 1) == 1){
                return;
            }
            Base b = GameState.gs.findBaseOf(c.uniqueID);
            List<Card> options = new List<Card>();
            foreach(Card card in b.onBase){
                
                if(card.owner != c.owner && !((card.flags & 4) == 4)){
                    options.Add(card);
                }
            }
            while(true){
                if(options.Count == 0){
                    Console.WriteLine("No cards to destroy.");
                    break;
                }
                int i = 1;
                foreach(Card card2 in options){
                    Console.WriteLine(i + ": " + card2.handToString());
                    i++;
                } 
                Console.WriteLine(i + ": Cancel");
                Console.WriteLine("Choose a card to destroy.");
                try{
                    int choice = int.Parse(Console.ReadLine());
                    choice--;
                    if(choice >= options.Count || choice < 0){
                        break;
                    }
                    else{
                        Card card3 = options[choice];
                        Effects.destroyCard(card3);
                        break;
                    }
                }
                catch(Exception e){
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Invalid input.");
                    continue;
                }
                
            }
        }




    }

    List<Card> Faction.getCards()
    {
        return cards;
    }

    void Faction.setCards()
    {
        
    }
}