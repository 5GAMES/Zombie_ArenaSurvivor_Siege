using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Canvas _menu;
    [SerializeField] private GamaManager _gamaManager;
    [SerializeField] private GameObject _shop;
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
            _gamaManager.Boken();
        }
        else
        {
            Time.timeScale = 1;
            _shop.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            _gamaManager.Boken();
        }
    }
}
