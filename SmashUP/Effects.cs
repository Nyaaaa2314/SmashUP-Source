using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using SmashUP;
public class Effects {

    public static void eff(Card c){
        checkTrigger(c);
        switch(c.faction){
            case "Robots":
                Robots.procAbility(c);
                break;
        }
    }

    public static void checkTrigger(Card c){
        if((c.flags & 8) == 8 && (c.flags & 1) != 1){
            foreach(Base b in GameState.gs.bases){
                foreach(Card card in b.onBase){
                    if(card.owner == c.owner && card.name == "Microbot Alpha"){
                        card.currentPower++;
                    }
                }
            }
        }
         if(((c.flags & 8) == 8) && ((c.flags & 1) == 1)){
            foreach(Base b in GameState.gs.bases){
                foreach(Card card in b.onBase){
                    if(card.owner == c.owner && card.name == "Microbot Alpha"){
                        card.currentPower--;
                    }
                }
            }
        }
    }
    public static void destroyCard(Card c){
        Base b = GameState.gs.findBaseOf(c.uniqueID);
        b.onBase.Remove(c);
        c.flags |= 1;
        c.lastBase = b.name;
        Effects.eff(c);
        c.owner.discard.Add(c);
        c.flags = c.ogflags;
        c.lastBase = "";
        b.update();
    }

    





}