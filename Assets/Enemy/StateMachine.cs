
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseStates _activeState;
   
    public void Initialise()
    {
      
        ChangeState(new PatrolState());
    }
    private void Update()
    {
        if(_activeState != null)
        {
            _activeState.Perform();
        }
    }
    public void ChangeState(BaseStates newstate)
    {
        if(_activeState != null)
        {
            _activeState.Exit();
        }
        
        _activeState = newstate;

        if(_activeState != null)
        {
            _activeState._stateMachine = this;
            _activeState._enemy = GetComponent<Enemy>();
           
               
                _activeState.Enter();
            
          
        }
            
        
    }
}
