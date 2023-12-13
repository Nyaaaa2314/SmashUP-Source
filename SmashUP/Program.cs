
using System.Numerics;

public class Program{
public static Boolean debug;
    public static void Main(String[] args){
        debug = true;
        Player player1 = new Player("Player 1", 0,0);
        Player player2 = new Player("Player 2", 0,0);
        GameState gs = GameState.getInstance();
        gs.players.Add(player1);
        gs.players.Add(player2);
        gs.drawCards(player1, 5);
        gs.drawCards(player2, 5);
        while(!gs.checkWin()){
            foreach(Player p in gs.players){
                int op = -1;
                Console.WriteLine(p.name + "'s turn");
                p.currentMinionPlays = 1;
                p.currentActionPlays = 1;
                while(op != 5){
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Play a Card");
                Console.WriteLine("2. Inspect Board");
                Console.WriteLine("3. Inspect Hand");
                Console.WriteLine("4. Inspect Discard");
                Console.WriteLine("5. Pass Turn");
                Console.WriteLine("6. See current scores");
                if(debug){
                    Console.WriteLine("7. Add Test Cards");
                    Console.WriteLine("8: Load Scenario");
                }
                op = int.Parse(Console.ReadLine());
                switch(op){
                    case 1:
                        Console.WriteLine("Which card would you like to play?");
                        int ind = 1;
                        foreach(Card c in p.hand){
                            Console.WriteLine("#" + ind + " "+ c.handToString());
                            ind++;
                        }
                        int cardNum = int.Parse(Console.ReadLine()) - 1;
                        Card card = p.hand[cardNum];
                        if(!card.isMinion){

                        }
                        else{
                            if(p.currentMinionPlays == 0 && !debug){
                                Console.WriteLine("You have no more minion plays");
                                break;
                            }
                            ind = 1;
                            Console.WriteLine("Where would you like to play this card?");
                            foreach(Base b in gs.bases){
                                Console.WriteLine("#" + ind + " " + b.name);
                                ind++;
                            }
                            int baseNum = int.Parse(Console.ReadLine()) - 1;
                            Base base1 = gs.bases[baseNum];
                            base1.onBase.Add(card);
                            base1.currentPower += card.basePower;
                            p.hand.RemoveAt(cardNum);
                            p.currentMinionPlays--;
                            Effects.eff(card);
                        }
                        
                        break;
                    case 2:
                        foreach(Base b in gs.bases){
                            Console.WriteLine(b.name + " | " + b.currentPower + " " + b.breakpoint);
                            foreach(Player pl in gs.players){
                                Console.WriteLine(pl.name + "'s cards on this base: ");
                                foreach(Card c in b.onBase){
                                    if(c.owner == pl){
                                        Console.WriteLine(c.onBaseToString());
                                    }
                                }
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 3:
                        foreach(Card c in p.hand){
                            Console.WriteLine(c.handToString());
                        }
                        break;
                    case 4:
                        foreach(Card c in p.discard){
                            Console.WriteLine(c.handToString());
                        }
                        break;
                    case 5:
                        Base baseToBreak = null;
                        foreach(Base b in gs.bases){
                            if(b.isBroken()){
                                baseToBreak = b;
                                break;
                            }
                        }
                        if(baseToBreak != null){
                            gs.baseBreak(baseToBreak);
                        }
                        break;
                    case 6:
                        foreach(Player pl in gs.players){
                            Console.WriteLine(pl.name + ": " + pl.VP);
                        }
                        break;
                    case 7:
                        p.hand.Add(new Card("Test Card", "Robots", 1,1,true,"Destroy one card on base", p));
                        p.hand.Add(new Card("Nukebot", "Robots",5,5,true,"",p));
                        break;
                    case 8:
                        Console.WriteLine("Which scenario would you like to load?");
                        Console.WriteLine("1. Nukebot test");
                        Console.WriteLine("2. Microbot Alpha test");
                        int choice = int.Parse(Console.ReadLine()) ;
                        switch(choice){
                            case 1:
                                Base b = gs.bases[0];
                                b.onBase.Add(new Card("Nukebot", "Robots",5,5,true,"",gs.players[1]));
                                b.onBase.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",p));
                                b.onBase.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",p));
                                b.onBase.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",p));
                                b.onBase.Add(new Card("Can't be destroyed","Robots",1,1,true,"",p, 4));
                                b.update();
                                break;
                            case 2:
                                Base b1 = gs.bases[0];
                                //Base b2 = gs.bases[1];
                                b1.onBase.Add(new Card("Microbot Alpha","Robots",1,1,true,"+1 Power for every other microbot in play",gs.players[0]));
                                //b2.onBase.Add(new Card("Microbot Alpha","Robots",1,1,true,"+1 Power for every other microbot in play",gs.players[0]));
                                p.hand.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",p,8));
                                p.hand.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",p,8));
                                p.hand.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",p,8));
                                p.hand.Add(new Card("Microbot Reclaimer","Robots",1,1,true,"",p,8));
                                b1.update();
                                break;
                        }
                        break;
                }
                }   

                





            }



        }


    }



}