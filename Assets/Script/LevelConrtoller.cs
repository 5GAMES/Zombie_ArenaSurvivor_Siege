using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConrtoller : MonoBehaviour
{
    private void Start()
    {
        PlayerMotor.Singleton.GetComponent<PlayerHealth>().OnDie += RestartLevel;
        ZombieCounter.SetPrefsValue(PlayerPrefs.GetInt("Killed"));
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Killed", ZombieCounter.ZombieKilled);
    }
}
