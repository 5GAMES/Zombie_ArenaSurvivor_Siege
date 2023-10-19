using System.Threading.Tasks;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float _damage = 3f;
    private bool _canDamage = true;

    private void OnCollisionEnter(Collision collision) => CheckPlayer(collision);
    private void OnCollisionStay(Collision collision) =>  CheckPlayer(collision);
   
    private void CheckPlayer(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth health)) TryDamage(health);
    }

    private async void TryDamage(PlayerHealth health)
    {
        if(!_canDamage) return;
        _canDamage = false;
        health.TakeDamage(_damage);
        await Task.Delay(500);
        _canDamage = true;
    }
}
