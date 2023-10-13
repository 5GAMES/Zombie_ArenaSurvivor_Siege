using System.Collections.Generic;
using UnityEngine;

public class ShopTurret : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints;

    public void SetTurret(Turret tur)
    {
        var point = _spawnPoints[Random.Range(0, _spawnPoints.Count - 1)];
        Instantiate(tur.gameObject, point.transform.position, Quaternion.identity);
    }
}
