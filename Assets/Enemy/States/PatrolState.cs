

using UnityEngine;

public class PatrolState : BaseStates
{
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {
       
    }
    public override void Perform()
    {
        PatrolCycle();
        if(_enemy.CanSeePlayer())
        {
            _stateMachine.ChangeState(new AttackMily());
        }
    }
    public override void Exit()
    {
       
    }
    public void PatrolCycle()
    {
        if(_enemy.Agent.remainingDistance < 0.2f)
        {
            
            waitTimer += Time.deltaTime;
            if(waitTimer > 3) 
            {
                if (waypointIndex < _enemy.put._waypoints.Count - 1)

                    waypointIndex++;

                else

                    waypointIndex = 0;
                _enemy.Agent.SetDestination(_enemy.put._waypoints[waypointIndex].position);
            }
           
            
        }
    }
}
