
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelConrtoller : MonoBehaviour
{
    [SerializeField] private GamaManager _gamaManager;
    [SerializeField] private Canvas _defeats;
    [SerializeField] private GameObject _defeatss;
    [SerializeField] PlayerHealth _playerHealth;
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
        Time.timeScale = 1;
        _defeats.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerHealth.TakeHeal(100);
        _gamaManager.FullcreenShow();
        
    }
    public void Ñhoice()
    {
        Time.timeScale = 0;
        _defeats.enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
