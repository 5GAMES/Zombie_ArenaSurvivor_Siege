using System;
using System.Diagnostics;
using Unity.VisualScripting.FullSerializer;
using YG;

public static class ZombieCounter
{
    public static Save Saver ;
    public static event Action<int> OnValueChanged;
    public static int ZombieKilled { get; private set; }
    public static int ZombieKilledMax { get; private set; } 
    public static void SetMax(int value) => ZombieKilledMax = value;
    public static void UpdateStat()
    {
        ZombieKilled++;
        if(ZombieKilled > ZombieKilledMax)
        {
            
            ZombieKilledMax = ZombieKilled;
            YandexGame.NewLeaderboardScores("ZombieKilled", ZombieKilledMax);
        }
        OnValueChanged?.Invoke(ZombieKilled);
        //Saver.KilledZombie = ZombieKilled;
        
    }
    public static void SetStat(int value)
    {
        ZombieKilled = value;
        OnValueChanged?.Invoke(ZombieKilled);
    }
    
}
