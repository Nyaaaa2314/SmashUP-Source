
using System.Runtime.CompilerServices;

public class GameState {
    public List<Player> players;
    public List<Base> bases;
    public static GameState gs;

    public static GameState getInstance(){
        if(gs == null){
            gs = new GameState();
        }
        return gs;
    }

    private GameState() {
        players = new List<Player>();
        bases = new List<Base>();
        bases.Add(new Base(15, 0, 5, 2, 0, "The Homeworld", "Ongoing: After you play a minion here, you may play an extra minion of power 2 or less here."));
        bases.Add(new Base(16, 0, 4, 3, 1, "The Test", ""));
        bases.Add(new Base(17, 0, 2, 3, 1, "The Test Two", ""));
    }

    public void drawCards(Player p, int num){
        while(num > 0){
            if(p.deck.Count == 0){
                Random rnd = new Random();
                p.deck = new Stack<Card>(p.discard.OrderBy(x => rnd.Next()));
                p.discard = new List<Card>();
            }
            p.hand.Add(p.deck.Pop());
            num--;
        }
    }
    public Boolean checkWin(){
        foreach(Player p in players){
            if(p.VP >= 15){
                return true;
            }
        }
        return false;
    }
    public Base findBaseOf(String name){
        foreach(Base b in bases){
            if(b.name == name){
                return b;
            }
        }
        return null;
    }
    public Base findBaseOf(int ID){
        foreach(Base b in bases){
            foreach(Card c in b.onBase){
                if(c.uniqueID == ID){
                    return b;
                }
            }
        }
        return null;
    }
    public void baseBreak(Base b){
        bases.Remove(b);
        int[] points = new int[players.Count];
        foreach(Card c in b.onBase){
            points[players.IndexOf(c.owner)] += c.currentPower;
            c.owner.discard.Add(c);
            c.flags = c.ogflags;
        }
        int max = 0;
        int mindex = 0;
        foreach(int i in points){
            if(i > max){
                max = i;
                mindex = Array.IndexOf(points, i);
            }
        }
        players[mindex].VP += b.firstplace;
        bases.Add(new Base(17, 0, 2, 3, 1, "Broken base test", ""));
    }
}