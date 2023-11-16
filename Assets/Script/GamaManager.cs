
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using YG;

public class GamaManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _texthelp;
    [SerializeField] private Menu _menu;
    [SerializeField] private Volume _volume;
   // [SerializeField] private TextMeshProUGUI [] _textExplanations;
    [Header("ADD")]
    [SerializeField] private Slider _sliderFullScreen;
    [SerializeField] private YandexGame _sdk;
    [SerializeField] private GameObject _estimate;
    private float _timer = 10f;
    [SerializeField] bool _IsAdplay;
    [SerializeField] private TextMeshProUGUI _textad;
    [SerializeField] private GameObject _fullsceenAd;
    [SerializeField] private Wallet _wallet;

    [Header("Authentication")]
    [SerializeField] private GameObject _authentication;
    [SerializeField] private SaveLocal _saverTest;
    public Image Icones;
  

   // public int IsFirstGame;

    public void ResumeGames() => _menu.PauseGames();
    public void AddMoneySdk0()
    {
        _sdk._RewardedShow(0);
        ResumeGames();
        //StartCoroutine(S());
    }
    public void AddMoneySdk1() => _sdk._RewardedShow(1);
    public void AddMoneySdk2()
    {
        _sdk._RewardedShow(2);
        //StartCoroutine(S());
    }
    public void FullcreenShow() => _sdk._FullscreenShow();
    public void NoAuthentication() => StartCoroutine(NoAuthenticationCoroutine());
    public void SaveLocalBuy() => _saverTest.Save();
    public void ActiveEstimate() => _estimate.SetActive(true);
    private void OnApplicationQuit() => _saverTest.Save();
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;
    public void ExampleOpenRewardAd(int id) => YandexGame.RewVideoShow(id);
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.15f);
        _sliderFullScreen.minValue = 0f;
        _sliderFullScreen.maxValue = _timer;
        _sliderFullScreen.value = 0f;
        //if (IsFirstGame == 2)
        //{
        //    DestoryExplanationsAdd();
        //}
        //if (IsFirstGame == 0)
        //{
        //    Time.timeScale = 0f;
        //    _textExplanations[10].text = "Нажмите на Г, чтобы продолжить";
        //}
        StartCoroutine(AdFullScreen());
    }
    private void Update()
    {
        AddSdk();
        //DestoryExplanations();
    }
    private void Rewarded(int id)
    {
        if (id == 0)
            _wallet.AddMoney(400);
        else if (id == 1)
            _wallet.AddMoney(0);
        else if (id == 2)
            _wallet.AddMoney(0);
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
    private IEnumerator AdFullScreen()
    {
        yield return new WaitForSeconds(60f);
        _IsAdplay = true;
        _fullsceenAd.SetActive(true);
    }
    private IEnumerator NoAuthenticationCoroutine()
    {
        _authentication.SetActive(true);
        yield return new WaitForSeconds(3);
        _authentication.SetActive(false);
    }
    
    //private void DestoryExplanations()
    //{
    //   if(Input.GetKeyDown(KeyCode.U) && IsFirstGame == 0)
    //   {
    //        DestoryExplanationsAdd();
    //        IsFirstGame = 2;
    //   }
    //}
    //private void DestoryExplanationsAdd()
    //{
    //    foreach (var item in _textExplanations)
    //    {
    //        if (item?.gameObject != null) Destroy(item?.gameObject);      
    //    }
    //    Time.timeScale = 1f;
    //}   
}