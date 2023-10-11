using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Action<int> OnMagazineValueChnaged;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _impactForce = 30f;
    [SerializeField] private float _fireRate = 15f;
    [SerializeField] int _magazine = 30;
    [SerializeField] float _audioClips;
    private int _capacitmagazina;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _impactEffect;
    public Animator _anim;
    public bool _IsShoot;
    [SerializeField] private bool _IsShootActive;
    private bool _singleFireMode = true;
    [SerializeField] private WeaponParametersSO weaponParameters;
    private float nextTimeToFire = 0f;
    private bool _IsRecharge;

    public void Die() => Destroy(gameObject);
    public void DisableShooting() => _IsShootActive = false;
    public void EnableShooting() => _IsShootActive = true;


    private void Start()
    {
        _damage = weaponParameters.damage;
        _range = weaponParameters.range;
        _impactForce = weaponParameters.impactForce;
        _fireRate = weaponParameters.fireRate;
        _magazine = weaponParameters.magazine;
        _capacitmagazina = weaponParameters.magazineCapacity;
        _audioClips = weaponParameters._audioclips;
        
        _IsShoot = true;
        _IsShootActive = true;
        _IsRecharge = false;
    }

    private void Update()
    {  
        if (_IsShootActive == true)
        {
            HardShoot();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            _singleFireMode = !_singleFireMode;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Recharge();
        }
    }

    public void HardShoot()
    {
        if (_singleFireMode) 
        {
            if (Input.GetButtonDown("Fire1") && _magazine > 0)
            {
                nextTimeToFire = Time.time + 1f / _fireRate;
               
                Shoot();
            }
            if (_magazine <= 0)
            {
               
               // _gameManager.UpdateHintsText("������� ������� R ");
                Debug.Log("�����������");
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                if (_magazine <= 0)
                {
                   // _gameManager.UpdateHintsText("������� ������� R ");
                    
                    Debug.Log("�����������");
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
        _magazine -= 1;
        OnMagazineValueChnaged?.Invoke(_magazine);
        _muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward,out hit, _range))
        {
            IDamageable target = hit.transform.GetComponent<IDamageable>();
            if(target != null)
            {
                target.TakeDamage(_damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * _impactForce);
            }
            Destroy(Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal)), 2f);
        }
    }

    public void Recharge()
    {
        _IsRecharge = true;

        _anim.SetBool("NoAmmo", true);
        _magazine = _capacitmagazina;

        Invoke("OnRecharge", 1.8f);
       
    }

    private void OnRecharge()
    {
        _IsRecharge = false;
        _anim.SetBool("Recharge", false);
    }

}