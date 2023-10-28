using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public Action<float> OnValeChanged;
    public Action OnDie;
    public float MaxHealth => _maxHealth;
    public float Health => _health;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private TextMeshProUGUI _textHP;
    [SerializeField] private LevelConrtoller _levelConrtoller;
    [SerializeField] private SaveLocal _save;
    private void Start()
    {
        _textHP.text = _health.ToString();
        _sliderHP.minValue = 0;
        _sliderHP.maxValue = _maxHealth;
        _sliderHP.value = _health;
        
    }
    public void TakeDamage(float value)
    {
       
        _health -= value;
        _sliderHP.value = _health;
        _textHP.text = _health.ToString();
        if (_health <= 0)
        {
            _health = 0;
            ZombieCounter.SetStat(0);
            print(ZombieCounter.ZombieKilled);
            _save.Save();
            _levelConrtoller.�hoice();
            OnDie?.Invoke();
        }
        OnValeChanged?.Invoke(_health);
    }

    public void TakeHeal(float value)
    {
        if(_health + value <= _maxHealth)_health += value;
        OnValeChanged?.Invoke(_health);
    }
}
