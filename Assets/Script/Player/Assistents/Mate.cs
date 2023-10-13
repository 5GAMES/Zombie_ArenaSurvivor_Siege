using UnityEngine;
using UnityEngine.AI;

public class Mate : MonoBehaviour
{
    [SerializeField] private float _findRange;
    [SerializeField] private Weapon _weapon;
    private EnemyMovement _target;
    private NavMeshAgent _agent;

    private void CheckAmmo(int value)
    { if (value == 0) _weapon.Recharge(); }

    private void OnDestroy() => _weapon.OnMagazineValueChnaged -= CheckAmmo;
    private void Start()
    {
        _weapon.OnMagazineValueChnaged += CheckAmmo;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        FindTarget();
        Move();
    }
        
    private void FindTarget()
    {
        var coliders = Physics.OverlapSphere(transform.position, _findRange);
        foreach (Collider collider in coliders)
        {
            _target = collider.GetComponent<EnemyMovement>();
            if (_target != null)
            {
                Vector3 direction = (_target.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction);
                _weapon.Shoot();
                break;
            }
        }
    }

    private void Move()
    {
        if (PlayerMotor.Singleton == null) return;
        _agent.destination = PlayerMotor.Singleton.transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _findRange);
    }
}
