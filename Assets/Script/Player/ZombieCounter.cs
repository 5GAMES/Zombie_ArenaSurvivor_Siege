public static class ZombieCounter
{
    public static int ZombieKilled { get; private set; } = 0;
    public static  int Counter { get { return ZombieKilled; } }
    public static void UpdateStat() => ZombieKilled++;

    
}
