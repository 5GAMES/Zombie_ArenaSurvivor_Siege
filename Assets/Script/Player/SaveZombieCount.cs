using UnityEngine;

public class SaveZombieCount : MonoBehaviour
{
    private void Start() =>
        ZombieCounter.SetValue(PlayerPrefs.GetInt("Killed"));
    
    private void OnApplicationQuit() =>
        PlayerPrefs.SetInt("Killed", ZombieCounter.Count);
    
}
