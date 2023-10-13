
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GamaManager : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Volume _volume;
    [SerializeField] private DepthOfField _depthOfField;

    void Start()
    {
        if (!_volume.profile.TryGet(out _depthOfField))
        {
            Debug.LogError("Depth of Field is not set up in the Volume");
        }
    }
    public void ResumeGames() => _menu.PauseGames();

    public void Boken()
    {
        if(!_depthOfField.active)
        {
            _depthOfField.active = true;
        }
        else
        {
            _depthOfField.active = false;
        }
    }
}
