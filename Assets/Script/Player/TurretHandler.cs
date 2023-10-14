using System.Collections.Generic;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    public void SetTurret(Turret turret)
    {
        var num = Random.Range(0, _spawnPoints.Count);
        var turet = Instantiate(turret.gameObject, _spawnPoints[num]);
        turet.transform.position = _spawnPoints[num].position;
    }
}
