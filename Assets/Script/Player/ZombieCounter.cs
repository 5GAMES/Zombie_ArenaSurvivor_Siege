using System;

public static class ZombieCounter
{
    public static event Action<int> OnValueChanged;
    public static int ZombieKilled { get; private set; } = 0;
    public static  int Counter { get { return ZombieKilled; } }
    public static void UpdateStat()
    {
        ZombieKilled++;
        OnValueChanged?.Invoke(ZombieKilled);
    }

    
}
