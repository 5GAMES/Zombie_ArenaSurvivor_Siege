using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Target))]
public class EnemyMovement : MonoBehaviour
{
    public Action OnMove;
    private NavMeshAgent _agent;
    private Target _target;
    private bool _canMoving = true;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GetComponent<Target>();
        _target.OnDie += () => _canMoving = false;
    }

    private void FixedUpdate()
    {
        if (PlayerMotor.Singleton == null || !_canMoving)
        {
            _agent.destination = transform.position;
            return;
        }
        OnMove?.Invoke();
        _agent.destination = PlayerMotor.Singleton.transform.position;
    }
}
