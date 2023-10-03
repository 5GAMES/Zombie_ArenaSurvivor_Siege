using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseStates
{
    private float searchTimer;
    private float moveTimer;
    public override void Enter()
    {
        _enemy.Agent.SetDestination(_enemy.LastKnowPos);
    }
    public override void Exit()
    {
        
    }
    public override void Perform()
    {
        if (_enemy.CanSeePlayer())
        {
            _stateMachine.ChangeState(new AttackMily());
        }
        if (_enemy.Agent.remainingDistance < _enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if(moveTimer > Random.Range(3,7))
            {
                _enemy.Agent.SetDestination(_enemy.transform.position + (Random.insideUnitSphere * 10));
            }
            if (searchTimer > 10)
            {
                _stateMachine.ChangeState(new PatrolState());
            }
        }
    }
}
