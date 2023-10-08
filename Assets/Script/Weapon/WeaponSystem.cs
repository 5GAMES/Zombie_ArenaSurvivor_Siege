using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] float _damage = 10f;
    [SerializeField] float _range = 100f;
    [SerializeField] float _impactForce = 30f;
    [SerializeField] float _fireRate = 15f;
    [SerializeField] float _magazine = 30f;
    [SerializeField] float _audioClips;
    private float _capacitmagazina;
    [SerializeField] TextMeshProUGUI _textmagazin;
    [SerializeField] Camera _fpsCam;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _impactEffect;
    //[SerializeField] AudioSource _audioSource;
    //[SerializeField] private AudioManager _audioManager;
    public Animator _anim;
   // private GameManager _gameManager;
    public bool _IsShoot;
    [SerializeField] private bool _IsShootActive;
    private bool _singleFireMode = true;
    [SerializeField] private WeaponParametersSO weaponParameters;
    private float nextTimeToFire = 0f;
    //[SerializeField]private PauseMenu _pauseMenu;
    private bool _IsRecharge;

    private void Awake()
    {
      // _pauseMenu =FindObjectOfType<PauseMenu>();
    }

    private void Start()
    {
        //_audioManager = FindObjectOfType<AudioManager>();
        
        _damage = weaponParameters.damage;
        _range = weaponParameters.range;
        _impactForce = weaponParameters.impactForce;
        _fireRate = weaponParameters.fireRate;
        _magazine = weaponParameters.magazine;
        _capacitmagazina = weaponParameters.magazineCapacity;
        _audioClips = weaponParameters._audioclips;
        FpsCamera();

      
        //_gameManager = FindObjectOfType<GameManager>();
        
        _IsShoot = true;
        _IsShootActive = true;
        _IsRecharge = false;
    }

    private void Update()
    {
       
      //  if(_pauseMenu.IsOpenShoop == false && _pauseMenu.IsOpenMenu == false && _IsRecharge == false)
        {
            if (_IsShootActive == true)
            {
                HardShoot();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                _singleFireMode = !_singleFireMode;
            }
            TextMagazina();
            if (Input.GetKey(KeyCode.R))
            {
                Recharge();
            }
        }
        


    }
    public void HardShoot()
    {
        if (FindObjectOfType<gun>() != null || _singleFireMode) 
        {
            if (Input.GetButtonDown("Fire1") && _magazine > 0)
            {
                nextTimeToFire = Time.time + 1f / _fireRate;
               
                Shoot();
            }
            if (_magazine <= 0)
            {
               
               // _gameManager.UpdateHintsText("Нажмите клавишу R ");
                Debug.Log("Закончились");
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                if (_magazine <= 0)
                {
                   // _gameManager.UpdateHintsText("Нажмите клавишу R ");
                    
                    Debug.Log("Закончились");
                }
                else
                {
                    if (_IsShoot == true)
                    {
                        nextTimeToFire = Time.time + 1f / _fireRate;
                        
                        Shoot();
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _anim.SetBool("Fire", false);
        }
    }
    private void AudioShoot()
    { 
        //if(_audioClips == 0)
        //{
        //    _audioManager.PlaySound(3);
        //}
        //else if(_audioClips == 1)
        //{
        //    _audioManager.PlaySound(4);
        //}
        //else if (_audioClips == 2)
        //{
        //    _audioManager.PlaySound(5);
        //}
        //else if (_audioClips == 3)
        //{
        //    _audioManager.PlaySound(6);
        //}
        //else if (_audioClips == 4)
        //{
        //    _audioManager.PlaySound(7);
        //}
        //else if (_audioClips == 5)
        //{
        //    _audioManager.PlaySound(8);
        //}
        //else if (_audioClips == 6)
        //{
        //    _audioManager.PlaySound(9);
        //}
        
        
    }
    public void Shoot()
    {
       
        Invoke("AudioShoot", 0.2f);
        _anim.SetBool("Fire", true);
        _anim.SetBool("NoAmmo", false);
        _magazine -= 1f;
        _textmagazin.text = _magazine.ToString();
        _muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward,out hit, _range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(_damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * _impactForce);
            }
            GameObject ImpactGo = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGo, 2f);
        }
        if (Time.timeScale == 0f)
        {
           // _audioSource.Pause();
        }
        else
        {
            //_audioSource.Play();
        }
    }
    public void OnAnimationEnd()
    {
        Debug.Log("edfsf");
    }
    public void Recharge()
    {
        _IsRecharge = true;

        _anim.SetBool("NoAmmo", true);
        _magazine = _capacitmagazina;
        //_gameManager.UpdateHintsText("");
        _textmagazin.text = _magazine.ToString();
        Invoke("OnRecharge", 1.8f);
       
    }
    private void OnRecharge()
    {
        _IsRecharge = false;
        _anim.SetBool("Recharge", false);
    }
    public void Die()
    {
       Destroy(gameObject);
    }
    private void TextMagazina()
    {
        GameObject textObject = GameObject.Find("Text(Magazin)");
        if (textObject != null)
        {
            //Debug.Log("God");
            _textmagazin = textObject.GetComponent<TextMeshProUGUI>();
            _textmagazin.text = _magazine.ToString();
        }
    }
    public void FpsCamera()
    {
        GameObject CameraS = GameObject.Find("Main Camera");
        if (CameraS != null)
        {
            _fpsCam = CameraS.GetComponent<Camera>();
            Debug.Log("Good");

        } 
            
        
    }
    public void DisableShooting()
    {
        _IsShootActive = false;
    }

    public void EnableShooting()
    {
        _IsShootActive = true;
    }

   
}