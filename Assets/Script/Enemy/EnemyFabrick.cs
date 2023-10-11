using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyFabrick : MonoBehaviour
{
    public Action OnLevelEnd;
    [Header("Values : ")]
    [SerializeField, Range(1, 7)] private int _enemyPerSpawn;
    [SerializeField] private int _additionalEnemy;
    [SerializeField, Range(1, 50)] private int _timeToNextWave;
    [Header("Links : ")]
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private EnemyMovement _enemy;
    private int _enemysDieCount = 0;

    private void Start() => StartLevel();

    public void StartLevel()
    {
        for(int i = 0; i < _enemyPerSpawn; i++)
        {
            var enemy = Instantiate(_enemy.gameObject, _spawnPoint.transform.position, Quaternion.identity);
            enemy.GetComponent<Target>().OnDie += () => StartCoroutine(nameof(CheckEnemyCount));
        } 
    }

    private IEnumerator CheckEnemyCount()
    {
        _enemysDieCount++;
        if(_enemysDieCount == _enemyPerSpawn)
        {
            OnLevelEnd?.Invoke();
            _enemyPerSpawn += _additionalEnemy;
            _enemysDieCount = 0;
            yield return new WaitForSeconds(_timeToNextWave);
            StartLevel();
        }
    }

}
