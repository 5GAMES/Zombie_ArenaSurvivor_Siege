using System;
using System.Threading.Tasks;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public Action<Target> OnDiee;
    public Action OnDie;
    public float Health => _health;
    public float MaxHealth => _maxHealth;

    [SerializeField]private float _maxHealth = 50;
    [SerializeField, Range(5,25)] private int _gold = 5;
    private float _health;
    private bool _canBeDamaged = true;
    private bool _isDead = false;

    private void Start() => _health = _maxHealth;

    public async void TakeDamage(float damage)
    {
        if (!_canBeDamaged || _isDead) return;
        _canBeDamaged = false;
        _health -= damage;
        if(_health <= 0)
        {
            _isDead = true;
            _health = 0;
            OnDie?.Invoke();
            OnDiee?.Invoke(this);
            if (PlayerMotor.Singleton != null)PlayerMotor.Singleton.GetComponent<Wallet>().AddMoney(_gold);
            ZombieCounter.UpdateStat();
            Destroy(this.gameObject, 2f);
        }
        await Task.Delay(100);
        _canBeDamaged = true;
    }

    public void TakeHeal(float value)
    {
        if(_health + value <= _maxHealth)_health += value;
    }
}
