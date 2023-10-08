
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    [SerializeField]private float _maxHealth = 50;
    [SerializeField]private float _health;

    private void Start()=> _health = _maxHealth;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0) Debug.Log("Die"); 
    }
}
