using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float _damage = 3f;
    private bool _canDamage = true;
    private EnemyMovement _enemyMovement;
    private EnemyAnimation _enemyAnimation;

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void OnCollisionEnter(Collision collision) => CheckPlayer(collision);
    private void OnCollisionStay(Collision collision) =>  CheckPlayer(collision);

    private void CheckPlayer(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
           StartCoroutine(DamageDelay(health));
    }

    private IEnumerator DamageDelay(PlayerHealth health)
    {
        if (!_canDamage) yield break;
        _canDamage = false;

        _enemyMovement.MoveOff();
        _enemyAnimation.PlayAttackAnimation(true);
       
        health.TakeDamage(_damage);
        yield return new WaitForSeconds(2.0f); 

        _enemyAnimation.PlayAttackAnimation(false);
        _enemyMovement.MoveOn();
        _canDamage = true;
    }
}
