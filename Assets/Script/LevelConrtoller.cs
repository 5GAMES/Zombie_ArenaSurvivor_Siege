using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConrtoller : MonoBehaviour
{
    private void Start()
    {
        PlayerMotor.Singleton.GetComponent<PlayerHealth>().OnDie += RestartLevel;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
