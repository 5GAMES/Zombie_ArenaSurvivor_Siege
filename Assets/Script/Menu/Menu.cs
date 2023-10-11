using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Canvas _menu, _shop;
    private bool _isMenuActive = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
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
                _shop.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
