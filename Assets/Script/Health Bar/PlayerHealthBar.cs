
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
   
    public float _health;
    private float _lerpTimer;
    [Header("Health Bar")]
    [SerializeField] bool _IsLive;
    [SerializeField] float _maxHealth = 100f;
    public float _chipsSpeed = 2f;
    [SerializeField] Image frontHealthBar;
    [SerializeField] Image backHealthBar;

    [Header("Damage Overlay")]
    public Image _overlay;
    public float _duration;
    public float _fadeSpeed;

    private float _durationTimer;
    private void Start()
    {
        
        _health = _maxHealth;
        _overlay.color = new Color(_overlay.color.r, _overlay.color.g, _overlay.color.b, 0);
    }
    private void Update()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        UpdateHealthUI();
        if(_overlay.color.a > 0)
        {
            if(_health > 30)
            {
                _durationTimer += Time.deltaTime;
                if (_durationTimer > _duration)
                {
                    float tempAlpha = _overlay.color.a;
                    tempAlpha -= Time.deltaTime * _fadeSpeed;
                    _overlay.color = new Color(_overlay.color.r, _overlay.color.g, _overlay.color.b, tempAlpha);
                }
            }
               
            
            
        }
       
    }
    public void UpdateHealthUI()
    {
        
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFaction = _health / _maxHealth;
        if(fillB > hFaction)
        {
            frontHealthBar.fillAmount = hFaction;
            backHealthBar.color = Color.red;
            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer / _chipsSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFaction, percentComplete);
        }
        if(fillF < hFaction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFaction;
            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer/ _chipsSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);   
        }
    }
    public void TakeDamage(float damage)
    { 
        if(_health <= 0f)
        {
            FindObjectOfType<PauseMenu>().Reborn();
            DiePlayer();
        }
        _health -= damage;
        _lerpTimer = 0f;
        _duration = 0f;
        _overlay.color = new Color(_overlay.color.r, _overlay.color.g, _overlay.color.b, 1);
    }
    public void RestoreHealth( float healing)
    {
        if(_health < 100f)
        {
            _health += healing;
           // if(FindObjectOfType<Kit>() != null)
            {
              //  FindObjectOfType<Kit>().DieKit();
            }
            
            _lerpTimer = 0f;
        }
        
        
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Kit"))
        {
            RestoreHealth(10f);
        }
    }
    public void DiePlayer()
    {
        if (_IsLive == true)
        {
            Destroy(gameObject);
        }
        else if(_IsLive == false)
        {
            Debug.Log("Dead");
        }
    }
}
