using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConrtoller : MonoBehaviour
{
    [SerializeField] private GamaManager _gamaManager;
    [SerializeField] private Canvas _defeats;
    [SerializeField] private GameObject _defeatss;
    [SerializeField] PlayerHealth _playerHealth;
    private void Start()
    {
       
    }
    public void RestartLevel()
    {
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
