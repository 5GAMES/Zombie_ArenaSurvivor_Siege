
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelConrtoller : MonoBehaviour
{
    [SerializeField] private GamaManager _gamaManager;
    [SerializeField] private Canvas _defeats;
    [SerializeField] private GameObject _defeatss;
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] Menu _menu;
    public void RestartLevel()
    {
        for (int i = 0; i < YandexGame.savesData.Weapon.Count; i++)
        {
            if (i == 0) YandexGame.savesData.Weapon[i] = true;
            else YandexGame.savesData.Weapon[i] = false;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }
    public void ResumeLevelAdd()
    {
        _gamaManager.AddMoneySdk2();
        Time.timeScale = 1;
        _defeats.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _playerHealth.TakeHeal(100);
        
    }
    public void Ñhoice()
    {
        Time.timeScale = 0;
        _defeats.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
