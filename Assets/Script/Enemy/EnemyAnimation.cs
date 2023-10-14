using UnityEngine;

[RequireComponent (typeof(EnemyMovement))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _anim;
    private Target _target;
    private EnemyMovement _enemyMovement;

    private void Start()
    {
        _anim = GetComponent<Animator> ();
        _target = GetComponent<Target>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _enemyMovement.OnMove += () => _anim.SetBool("Run", true);
        _target.OnDie += () =>
        {
            _anim.SetBool("Run", false);
            _anim.SetBool("Die", true);
        };
    }
}
