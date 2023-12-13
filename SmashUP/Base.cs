public class Base{
    public int breakpoint;
    public int currentPower;
    public int firstplace;
    public int secondplace;
    public int thirdplace;
    public String name;
    public String ability;

    public List<Card> onBase;

    public Base(int breakpoint, int currentPower, int firstplace, int secondplace, int thirdplace, String name, String ability){
        this.breakpoint = breakpoint;
        this.currentPower = currentPower;
        this.firstplace = firstplace;
        this.secondplace = secondplace;
        this.thirdplace = thirdplace;
        this.name = name;
        this.ability = ability;
        this.onBase = new List<Card>();
    }
    public void update(){
        currentPower = 0;
        foreach(Card c in this.onBase){
            currentPower += c.currentPower;
        }
    }
    public Boolean isBroken(){
        if(this.currentPower >= this.breakpoint){
            return true;
        }
        return false;
    }
}