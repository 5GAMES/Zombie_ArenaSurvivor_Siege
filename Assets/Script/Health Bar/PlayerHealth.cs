using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            _levelConrtoller.Ñhoice();
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
