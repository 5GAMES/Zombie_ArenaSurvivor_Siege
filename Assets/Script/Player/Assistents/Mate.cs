using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Mate : MonoBehaviour
{
    public Action OnTargetFounded, OnMove, OnTargetLoss, OnStay;
    [SerializeField] private float _findRange, _closeToPlayerDisnance;
    private Weapon _weapon;
    private EnemyMovement _target;
    private NavMeshAgent _agent;
    private bool _canShooting;
    private bool _isMoving = false;
    private void CheckAmmo(int value)
    { if (value == 0) _weapon.Recharge(); }
  
    private void OnDestroy() => _weapon.OnMagazineValueChnaged -= CheckAmmo;
    private void Start()
    {
        _weapon = GetComponentInChildren<Weapon>();
        _weapon.OnMagazineValueChnaged += CheckAmmo;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _canShooting = false;
    }

    private void Update()
    {
            FindTarget();
 
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void FindTarget()
    {
        if (_isMoving) return;
        var coliders = Physics.OverlapSphere(transform.position, _findRange);
        foreach (Collider collider in coliders)
        {
            _target = collider.GetComponent<EnemyMovement>();
            if (_target != null && _target != this)
            {
                _agent.updateRotation = false;
                Vector3 directionToEnemy = _target.transform.position - transform.position;
                float targetAngle = Mathf.Atan2(directionToEnemy.x, directionToEnemy.z) * Mathf.Rad2Deg + 45f;
                Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
                OnTargetFounded?.Invoke();
                if (!_canShooting)
                {
                    StartCoroutine(WeaponCoroutin());
                    return;
                }
                break;
            }
            else
            {
                _agent.updateRotation = true;
                OnTargetLoss?.Invoke();
            }
        }
    }
    private IEnumerator WeaponCoroutin()
    {
        _canShooting = true;
        yield return new WaitForSeconds(0.1f);
        _canShooting = false;
        _weapon.Shoot();

    }

    private void Move()
    {
        if (PlayerMotor.Singleton == null
            || Vector3.Distance(transform.position, PlayerMotor.Singleton.transform.position) < _closeToPlayerDisnance)
        {
            _agent.destination = transform.position;
            OnStay?.Invoke();
            _isMoving = false;
            return;
        }
        _agent.destination = PlayerMotor.Singleton.transform.position;
        _agent.updateRotation = true;
        OnMove?.Invoke();
        OnTargetLoss?.Invoke();
        _isMoving = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _findRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _closeToPlayerDisnance / 2);
    }
}
