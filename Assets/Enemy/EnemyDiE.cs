using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiE : MonoBehaviour
{
    [SerializeField] Transform _enemytrasform;
    private Enemy _enemy;
    private GameManager _gameManager;
    private int chance;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _enemy = GetComponent<Enemy>();
        _enemytrasform = _enemy.transform;

    }
    private void Update()
    {
       
    }


    public void Die()
    {
        Vector3 spawnPosition = _enemytrasform.position;
        
        
        chance = Random.Range(0, 3);
        if(chance == 1)
        {
            spawnPosition.y = 0.4f;
            Instantiate(_gameManager._kit, spawnPosition, Quaternion.identity);
        }
        Instantiate(_gameManager.DestoryDron, spawnPosition, Quaternion.identity);
        Destroy(gameObject);



    }
    private IEnumerator CreatKit()
    {


        yield return new WaitForSeconds(1f);
        
        Destroy(gameObject);
    }
}
