namespace SmashUP
{
[Flags]
public enum Flags : int {
    None = 0,
    wasDestroyed = 1,
    isNegated = 2,
    
    cantBeDestroyed = 4,

    isMicroBot = 8,

}
}