
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using YG;

public class GameManager : MonoBehaviour
{
    [Header("Ui")]
    [SerializeField] private GameObject _buttonHelp;
    [SerializeField] private Image DamageOverlay;
    [SerializeField] public TextMeshProUGUI textmoney;
    [SerializeField] public int _money;
    [SerializeField] private GameObject _help;

    [Header("SDK")]
    //[SerializeField]private YandexGame _sdk;
    //[SerializeField] GameObject _auth;
    //[SerializeField] private GameObject _review;

    public GameObject _kit;
    public GameObject DestoryDron;

    [Header("Message")]
    [SerializeField] AudioManager _audioManager;


    [Header("Hit")]
    [SerializeField] private GameObject _hitCrosshair;
    private float toggleDuration = 0.2f;

    [Header("Ad")]
    [SerializeField] private Image _adfullsceen;
    [SerializeField] private float _time =1f;
    [SerializeField] private float _timer = 10f;
    [SerializeField] bool _IsAdplay;
    [SerializeField] private TextMeshProUGUI _textad;
    [SerializeField] private GameObject _fullsceenAd;

    [SerializeField] TextMeshProUGUI _hints;
    private AudioSource _connectmessage;

    [Header("Authentication")]
    [SerializeField] private GameObject _authentication;


    private void Awake()
    {
       //_money = DataHolder.money;
       textmoney.text = _money.ToString();
    
    }
    private void Start()
    {
        _connectmessage = GetComponent<AudioSource>();
        _textad.text = _timer.ToString();

      
        StartCoroutine(AdFullScreen());

        Invoke("UdpateMoney", 0.5f);
        DamageOverlay.enabled = true;
    }
    private void Update()
    {
        AddSdk();
        if (Input.GetKeyUp(KeyCode.Q))
        {
           // if(FindObjectOfType<message>() != null)
            {
                _connectmessage.Play();
             //   FindObjectOfType<message>().DieMessage();
            }
        }
       

        //if (Input.GetKeyUp(KeyCode.H))
        //{
        //    _money += 10000;
        //}
        //textmoney.text = _money.ToString();


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
    public void UdpateMoney()
    {
        textmoney.text = _money.ToString();
    }
   
    public void AddMoney(int money)
    {
        _money += money;
        textmoney.text = _money.ToString();
    }
    public void AddMoneySdk()
    {
        //_sdk._RewardedShow(1);

       // FindObjectOfType<SaverData>().Save();
    }
    public void AddSdk()
    {
        if(_IsAdplay == true)
        {
            int roundedTimer = Mathf.FloorToInt(_timer);
            if (roundedTimer >= 0)
            {
                _timer -= Time.deltaTime;
                _textad.text = roundedTimer.ToString();
            }
            
            
            _time -= Time.deltaTime * 0.1f;
            _adfullsceen.fillAmount = _time;
            if (_time <= 0)
            {
                //_sdk._FullscreenShow();
                _IsAdplay = false;
                _fullsceenAd.SetActive(false);
            }
        }
        
        
    }
    private IEnumerator AdFullScreen()
    {
        
        yield return new WaitForSeconds(60f);
        _IsAdplay = true;
        _fullsceenAd.SetActive(true);
    }
    public void Review()
    {
        //_review.SetActive(true);
    }


    public void LoadSceneGame()
    {

        
        SceneManager.LoadScene("Game");
    }
    public void WeaponS()
    {
       
    }
    public void ExitShop()
    {
        FindObjectOfType<DestroyMagazin>().Destroy();
    }
    public void HitEnemy()
    {

        _audioManager.PlaySound(2);
        StartCoroutine(ToggleObjectForDuration());
    }
    IEnumerator ToggleObjectForDuration()
    {
        // Включаем объект
        _hitCrosshair.SetActive(true);

        // Ждем заданное количество времени
        yield return new WaitForSeconds(toggleDuration);

        // Выключаем объект
        _hitCrosshair.SetActive(false);
    }
    public void UpdateHintsText(string prompMessage)
    {
        _hints.text = prompMessage;
    }
    public void Reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
        
    }
    public void OpenHelp()
    {
        _help.SetActive(true);
        _buttonHelp.SetActive(false);
    }
    public void CloseHelp()
    {
        _help.SetActive(false);
        _buttonHelp.SetActive(true);
    }
}
