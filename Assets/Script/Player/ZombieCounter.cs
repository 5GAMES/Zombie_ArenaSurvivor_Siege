
public static class ZombieCounter 
{
    private static int ZombieKilled = 0;
    public static  int Counter { get { return ZombieKilled; } }
    public static void UpdateStat() => ZombieKilled++;
    
}
