using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Action OnMove;
    private NavMeshAgent _agent;
    private void Start() => _agent = GetComponent<NavMeshAgent>();

    private void FixedUpdate()
    {
        if (PlayerMotor.Singleton == null) return;
        OnMove?.Invoke();
        _agent.destination = PlayerMotor.Singleton.transform.position;
    }
}
