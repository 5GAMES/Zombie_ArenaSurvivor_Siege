
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using YG;

public class GamaManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _texthelp;
    [SerializeField] private Menu _menu;
    [SerializeField] private Volume _volume;
    [SerializeField] private DepthOfField _depthOfField;
    [Header("ADD")]
    [SerializeField] private Slider _sliderFullScreen;
    [SerializeField] private YandexGame _sdk;
    private float _time = 1f;
    private float _timer = 10f;
    [SerializeField] bool _IsAdplay;
    [SerializeField] private TextMeshProUGUI _textad;
    [SerializeField] private GameObject _fullsceenAd;

    [Header("Authentication")]
    [SerializeField] private GameObject _authentication;
    public Image Icones;
    void Start()
    {
        
        _sliderFullScreen.minValue = 0f;
        _sliderFullScreen.maxValue = _timer;
        _sliderFullScreen.value = 0f;
        //if (!_volume.profile.TryGet(out _depthOfField))
        //{
        //    Debug.LogError("Depth of Field is not set up in the Volume");
        //}
        StartCoroutine(AdFullScreen());
    }
    private void Update()
    {
       
        AddSdk();
    }
    public void ResumeGames() => _menu.PauseGames();

    public void Boken()
    {
        if (!_depthOfField.active) _depthOfField.active = true;
        else _depthOfField.active = false;
    }
    public void AddSdk()
    {
        if (_IsAdplay == true)
        {
            int roundedTimer = Mathf.FloorToInt(_timer);
            if (roundedTimer >= 0)
            {
                _timer -= Time.deltaTime;
                _textad.text = roundedTimer.ToString();
            }
            _sliderFullScreen.value += Time.deltaTime;
            if (_sliderFullScreen.value == 10)
            {
                _IsAdplay = false;
                _fullsceenAd.SetActive(false);
                FullcreenShow();

            }
        }
    }
    public void Texthelp(string message)
    {
        _texthelp.text = message.ToString();
       
    }
    public void FullcreenShow()
    {
        _sdk._FullscreenShow();
    }
    private IEnumerator AdFullScreen()
    {
        yield return new WaitForSeconds(60f);
        _IsAdplay = true;
        _fullsceenAd.SetActive(true);
    }
    public void NoAuthentication()
    {
        StartCoroutine(NoAuthenticationCoroutine());
    }
    private IEnumerator NoAuthenticationCoroutine()
    {
        _authentication.SetActive(true);
        yield return new WaitForSeconds(5);
        _authentication.SetActive(false);
    }
    public void AddMoneySdk()
    {
        _sdk._RewardedShow(1);
    }
}