using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _damage, _attackTime, _range;
    [SerializeField] private Animator _anim;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _impactEffect;
    private EnemyMovement _target;

    private void Update() => FindTarget();
    private void FindTarget()
    {
        var coliders = Physics.OverlapSphere(transform.position, _range);
        foreach (Collider collider in coliders)
        {
            _target = collider.GetComponent<EnemyMovement>();
            if (_target != null)
            {
                Vector3 direction = (_target.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction);
                Shoot();
                break;
            }
        }
    }

    private void Shoot()
    {
        Invoke("AudioShoot", 0.2f);
        _anim.SetBool("Fire", true);
        _anim.SetBool("NoAmmo", false);
        _muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, _range))
        {
            IDamageable target = hit.transform.GetComponent<IDamageable>();
            if (target != null) target.TakeDamage(_damage);

            Destroy(Instantiate(_impactEffect, hit.point, Quaternion.identity), 1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, _range);
    }
}
