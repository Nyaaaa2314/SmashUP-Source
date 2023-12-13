public abstract class FactionFactory{
    
    public static Faction genFaction(int FID, Player p){
        
        switch(FID){
            case 0:
                return new Robots(p);
        }
        return null;
    }



}