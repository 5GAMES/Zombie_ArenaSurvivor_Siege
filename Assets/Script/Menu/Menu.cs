using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Canvas _menu;
    [SerializeField] private GamaManager _gamaManager;
    [SerializeField] private Canvas _shop;
    private bool _isMenuActive = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            PauseGames();
        }
    }

    public void PauseGames()
    {
        _isMenuActive = !_isMenuActive;
        _menu.enabled = _isMenuActive;
        if (_isMenuActive)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            _shop.enabled = false;
        }
    }
}
