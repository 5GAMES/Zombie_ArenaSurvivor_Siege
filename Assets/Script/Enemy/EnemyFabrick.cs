using NTC.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFabrick : MonoBehaviour
{
    public Action OnLevelEnd;
    
    [SerializeField] private List<EnemyMovement> _first, _second, _thrid, _four, _five;
    [SerializeField] private List<GameObject> _spawnPoints;
    [Header("Values : ")]
    [SerializeField, Range(1, 7)] private int _enemyPerSpawn;
    [SerializeField] private int _additionalEnemy;
    [SerializeField, Range(1, 50)] private int _timeToNextWave;
    private int _wave = 0, _tier = 0;
    [SerializeField]private List<Target> _spawndZombi = new();

    private void Start() => StartLevel();

    public void StartLevel()
    {
        for(int i = 0; i < _enemyPerSpawn; i++)
        {
            var num = UnityEngine.Random.Range(0, _spawnPoints.Count);
            var point = _spawnPoints[num];
            var enemy = NightPool.Spawn(ChoiseEnemy().gameObject, point.transform.position, Quaternion.identity);
            enemy.GetComponent<Target>().OnDiee += CheckEnemyCount;
            _spawndZombi.Add(enemy.GetComponent<Target>());
        }
    }

    private void CheckEnemyCount(Target target)
    {
        _spawndZombi.Remove(target);
        if(_spawndZombi.Count == 0)
        {
            StartCoroutine(StartNewWave());
        }
    }

    private IEnumerator StartNewWave()
    {
        _wave++;
        int time = _timeToNextWave;
        if (_wave % 5 == 0)
        {
            print("tierUP");
            _tier++;
            if (_tier > 4) _tier = 0;
            _timeToNextWave += 30;
        }
        OnLevelEnd?.Invoke();
        _enemyPerSpawn += _additionalEnemy;
        yield return new WaitForSeconds(_timeToNextWave);
        _timeToNextWave = time;
        StartLevel();
        yield break;
    }

    private EnemyMovement ChoiseEnemy()
    {
        switch (_tier)
        {
            case 0:
                return _first[UnityEngine.Random.Range(0, _first.Count)];
            case 1:
                return _second[UnityEngine.Random.Range(0, _second.Count)];
            case 2:
                return _thrid[UnityEngine.Random.Range(0, _thrid.Count)];
            case 3:
                return _four[UnityEngine.Random.Range(0, _four.Count)];
            case 4:
                return _five[UnityEngine.Random.Range(0, _five.Count)];
            default:
                return null;
        } 
    }
}
