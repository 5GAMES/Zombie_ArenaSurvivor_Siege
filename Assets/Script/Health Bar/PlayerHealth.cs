using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public Action<float> OnValeChanged;
    public Action OnDie;
    public float MaxHealth => _maxHealth;
    public float Health => _health;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    public void TakeDamage(float value)
    {
        _health -= value;
        if(_health <= 0)
        {
            _health = 0;
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
