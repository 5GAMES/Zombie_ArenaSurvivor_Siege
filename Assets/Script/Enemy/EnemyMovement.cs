using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private void Start() => _agent = GetComponent<NavMeshAgent>();

    private void FixedUpdate()
    {
        //if (PlayerMovement.Singleton == null) return;
        //_agent.destination = PlayerMovement.Singleton.transform.position;
    }
}
