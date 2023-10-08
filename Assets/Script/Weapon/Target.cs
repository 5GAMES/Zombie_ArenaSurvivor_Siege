
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
   // private GameManager _gameManager;
    private void Start()
    {
       // _gameManager = FindObjectOfType<GameManager>();


    }
    public void TakeDamage(float damage)
    {
        //_gameManager.AddMoney(10);
        //FindObjectOfType<GameManager>().HitEnemy();
        health -= damage;
        if (health < 0)
        {
            //GetComponentInParent<EnemyDiE>().Die();
            Debug.Log("Die");



        }
    }



}
