using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ZombieCounter")]
public class ZombieCounter : ScriptableObject
{
    public static event Action<int> OnValueChanged;
    public int ZombieKilled { get; private set; }
    public static  int Counter { get { return ZombieKilled; } }
    public static void UpdateStat()
    {
        ZombieKilled++;
        OnValueChanged?.Invoke(ZombieKilled);
    }
    
}
