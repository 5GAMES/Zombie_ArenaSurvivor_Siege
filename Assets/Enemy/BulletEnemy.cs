using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        Transform hit = collision.transform;
        if (hit.CompareTag("Player"))
        {

            hit.GetComponent<PlayerHealthBar>().TakeDamage(3);
            
        }
        else
        {
            Invoke("Die", 0.5f);
        }

    }
    private void Die()
    {
        Destroy(gameObject);
    }
    
}
