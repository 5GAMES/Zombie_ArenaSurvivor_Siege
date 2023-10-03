
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class AttackMily : BaseStates
{
    private float _moveTimer;
    private float _losePlayerTimer;
    private float _shootTimer;
    
    public override void Enter()
    {

    }
    public override void Exit()
    {

    }
    public override void Perform()
    {
        if (_enemy.CanSeePlayer())
        {
            _losePlayerTimer = 0;
            _moveTimer += Time.deltaTime;
            _shootTimer += Time.deltaTime;
            _enemy.transform.LookAt(_enemy.Player.transform);
            if(_shootTimer > _enemy._fireRate ) 
            {
               
                EnemyShoot();
            }
            
            
           
            


            if (_moveTimer > Random.Range(3, 7))
            {
                _enemy.Agent.SetDestination(_enemy.transform.position + (Random.insideUnitSphere * 5));
                _moveTimer = 0;
            }
            _enemy.LastKnowPos = _enemy.Player.transform.position;
        }
        else
        {
            _losePlayerTimer += Time.deltaTime;
            if (_losePlayerTimer > 8)
            {
                _stateMachine.ChangeState(new SearchState());
            }
        }
    }
    public void EnemyShoot()
    {
        //_enemy.AudioGun();
        _enemy._gun.Play();
        Transform gunbarrel1 = _enemy._gunBarre1;
        GameObject bullet1 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel1.position, Quaternion.identity);
        Vector3 shootDirection1 = (_enemy.Player.transform.position - gunbarrel1.transform.position).normalized;
        bullet1.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection1 * 40;
        bullet1.transform.rotation = Quaternion.LookRotation(shootDirection1);


        Transform gunbarrel2 = _enemy._gunBarre2;
        GameObject bullet2 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel2.position, _enemy.transform.rotation);
        Vector3 shootDirection2 = (_enemy.Player.transform.position - gunbarrel2.transform.position).normalized;
        bullet2.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection2 * 40;

       
        Debug.Log("Shoot");
        _shootTimer = 0;
       

    }
}   
