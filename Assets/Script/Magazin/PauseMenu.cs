
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject PlayerUI;
    [SerializeField] GameObject Cam;
    [SerializeField] GameObject MenuUI;
    [SerializeField] GameObject Reload;
    [SerializeField] GameObject ResumeButton;
    [SerializeField] GameObject ShopButton;
    public bool IsOpenShoop = false;
    public bool IsOpenMenu = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Time.timeScale == 0f && IsOpenShoop == false)
            {
                Resume();
            }
            else if(IsOpenShoop == false)
            {
                Pause();
            }
           
        }

        if(IsOpenMenu == true && IsOpenShoop == true)
        {
            Time.timeScale = 0f;
        }
        
       
    }
    public void Reborn()
    {
        Debug.Log("Pause");
        Cursor.lockState = CursorLockMode.None;
        Reload.SetActive(true);
        MenuUI.SetActive(true);
        PlayerUI.SetActive(false);
        Cam.SetActive(true);
        ResumeButton.SetActive(false);
        ShopButton.SetActive(false);
    }
    public void Resume()
    {
        Debug.Log("Resume");
        Cursor.lockState = CursorLockMode.Locked;
        MenuUI.SetActive(false);
        PlayerUI.SetActive(true);
        Time.timeScale = 1f;
        IsOpenMenu = false;
        //AudioListener.pause = false;
    }

    void Pause()
    {
        Debug.Log("Pause");
        Cursor.lockState = CursorLockMode.None;
        MenuUI.SetActive(true);
        PlayerUI.SetActive(false);
        IsOpenMenu = true;
        Time.timeScale = 0f;
        //AudioListener.pause = true;
    } 
    public void ShoopActive()
    {
        MenuUI.SetActive(false);
        Shop.SetActive(true);
        Cam.SetActive(true);
        IsOpenShoop = true;
    }
    public void ShoopInactive()
    {
        MenuUI.SetActive(true);
        Shop.SetActive(false);
        Cam.SetActive(false);
        IsOpenShoop = false;
    }
}
