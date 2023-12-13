using SmashUP;
public class Card{
    public String name;
    public String faction;
    public int basePower;
    public int currentPower;
    public Boolean isMinion;
    public String ability;
    public Player owner;

    public int flags;

    public int ogflags;
    public int uniqueID; //randomly generated hash sequence

    public String lastBase;

    public Card(String name, String faction, int basePower, int currentPower, Boolean isMinion, String ability, Player owner){
        this.name = name;
        this.faction = faction;
        this.basePower = basePower;
        this.currentPower = currentPower;
        this.isMinion = isMinion;
        this.ability = ability;
        this.owner = owner;
        this.uniqueID = genUniqueID();
        flags = 0;
        ogflags = 0;
        lastBase =  "";
    }
     public Card(String name, String faction, int basePower, int currentPower, Boolean isMinion, String ability, Player owner, int flags){
        this.name = name;
        this.faction = faction;
        this.basePower = basePower;
        this.currentPower = currentPower;
        this.isMinion = isMinion;
        this.ability = ability;
        this.owner = owner;
        this.uniqueID = genUniqueID();
        this.ogflags = flags;
        this.flags = flags;
        lastBase =  "";
    }
    public String handToString(){
        return "Name: " + this.name + " | Faction: " + this.faction + " | Base Power: " + this.basePower + "\nAbility : " + this.ability + "\n";
    }
    public String onBaseToString(){
       return "Name: " + this.name + " | Faction: " + this.faction + "\nBase Power: " + this.basePower + " | Current Power: " + this.currentPower + "\nAbility : " + this.ability + "\n"; 
    }
    public String baseToString(){
        return this.name + "\n" + this.faction + "\n" + this.basePower + "\n" + this.currentPower + "\n" + this.ability + "\n" + this.owner.name;
    }

    public int genUniqueID(){
        Random rand = new Random();
        int ID = this.GetHashCode() * rand.Next();
        return ID;

    }
}