using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Canvas _menu;
    [SerializeField] private GamaManager _gamaManager;
    [SerializeField] private Canvas _shop;
    private bool _isMenuActive = false;
    public bool IsActivAD;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            PauseGames();
        }
    }
    public void  IsActiveAd(bool isActiveAd)
    {
            IsActivAD = isActiveAd;
    }
    private IEnumerator IsActiveCoro(bool isActiveAd)
    {
        yield return new WaitForSeconds(4);
        IsActivAD = isActiveAd;
    }
    public void PauseGames()
    {
        if (!IsActivAD)
        {
            _isMenuActive = !_isMenuActive;
            _menu.enabled = _isMenuActive;
            if (_isMenuActive)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                _shop.enabled = false;
                Cursor.visible = false;
            }
        }
        
    }
}
