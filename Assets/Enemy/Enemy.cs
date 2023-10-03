
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    private StateMachine _stateMachine;
    private NavMeshAgent _agent;
    private GameObject _player;
    private Vector3 _lasKnowPos;
    public NavMeshAgent Agent { get => _agent; }
    public GameObject Player { get => _player; }
    public Vector3 LastKnowPos { get => _lasKnowPos; set => _lasKnowPos = value; }

    private SpawnerEnemy _spawnerEnemy;
    public PathEnemy put;
    [Header("Sight Values")]
    public float _helathEnemy;
    
    public float _sightDistance = 20f;
    public float _fieldOfView = 85f;
    public float _eyeHeight;
    [Header("Weapon Values")]
    public Transform _gunBarre1;
    public Transform _gunBarre2;
    public AudioSource _gun;
    [Range(0.1f, 10f)] public float _fireRate;
   
    [SerializeField]  string _currentState;
    private void Start()
    {

       
        _gun = GetComponent<AudioSource>();
        _spawnerEnemy = FindObjectOfType<SpawnerEnemy>();
        _stateMachine = GetComponent<StateMachine>();
        _agent = GetComponent<NavMeshAgent>();
        _stateMachine.Initialise();
        _helathEnemy = 100f;
        _player = GameObject.FindGameObjectWithTag("Player");
        
    }
    public void TakeDamage(int damage)
    {
        if(_helathEnemy <0)
        {
            Destroy(gameObject);
        }
        else
        {
            _helathEnemy -= damage;
        }
       

    }
    private void Update()
    {
        
        CanSeePlayer();
       
        _currentState = _stateMachine._activeState.ToString();

    }
    public bool CanSeePlayer()
    {
        if(_player != null )
        {
           
            if(Vector3.Distance(transform.position, _player.transform.position) < _sightDistance)
            {
               Vector3 targetDirection = _player.transform.position - transform.position - (Vector3.up * _eyeHeight);
                float angelToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if(angelToPlayer >= - _fieldOfView && angelToPlayer <= _fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * _eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray, out hitInfo, _sightDistance))
                    {
                        if (hitInfo.transform.gameObject == _player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * _sightDistance);
                            return true;
                        }
                    }
                    

                }
            }
        }
        else
        {
            _gun.Stop();
        }
        return false;
    }
    
    public void RandomPath()
    {
            
        int randomIndex = Random.Range(0, 3);
        if(randomIndex == 0)
        {
            GameObject path0 = GameObject.Find("Path");
            put = path0.GetComponent<PathEnemy>();
        }
        if(randomIndex == 1)
        {
            GameObject path1 = GameObject.Find("Path (1)");
            put = path1.GetComponent<PathEnemy>();
        }
        if( randomIndex == 2)
        {
            GameObject path2 = GameObject.Find("Path (2)");
            put = path2.GetComponent<PathEnemy>();
        }
        if(randomIndex == 3)
        {
            GameObject path3 = GameObject.Find("Path (3)");
            put = path3.GetComponent<PathEnemy>();
        }
    }
    private IEnumerator AudioWithDelay()
    {

        yield return new WaitForSeconds(0.5f);
        _gun.Stop();
    }
    public void AudioCoroutine()
    {
        StartCoroutine(AudioWithDelay());
    }
    public void AudioGun()
    {
        if(_gun.isPlaying == false)
        {
            _gun.Play();
        }
    }

}
