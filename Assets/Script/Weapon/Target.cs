using System;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public Action OnDie;
    public float Health => _health;
    public float MaxHealth => _maxHealth;

    [SerializeField]private float _maxHealth = 50;
    private float _health;

    private void Start() => _health = _maxHealth;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health < 0)
        {
            _health = 0;
            OnDie?.Invoke();
            Destroy(this.gameObject);
        }
    }

    public void TakeHeal(float value)
    {
        if(_health + value <= _maxHealth)_health += value;
    }
}
