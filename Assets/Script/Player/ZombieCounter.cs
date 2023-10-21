using System;

public static class ZombieCounter
{
    public static event Action<int> OnValueChanged;
    public static int ZombieKilled { get; private set; }
    public static int Count { get { return ZombieKilled; } }
    public static void UpdateStat()
    {
        ZombieKilled++;
        OnValueChanged?.Invoke(ZombieKilled);
    }

    public static void SetValue(int value)
    {
        ZombieKilled = value;
        OnValueChanged?.Invoke(ZombieKilled);
    }
    
}
