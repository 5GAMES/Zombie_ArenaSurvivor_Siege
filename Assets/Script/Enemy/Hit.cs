using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] AudioSource _hit;
    [SerializeField] GameObject _hitCrosshair;
    private float toggleDuration = 0.3f;
    
    public void HitEnemy()
    {
        // _hit = GetComponent<AudioSource>();
        _hit.Play();
        StartCoroutine(ToggleObjectForDuration());
    }
    IEnumerator ToggleObjectForDuration()
    {
        // Включаем объект
        _hitCrosshair.SetActive(true);

        // Ждем заданное количество времени
        yield return new WaitForSeconds(toggleDuration);

        // Выключаем объект
        _hitCrosshair.SetActive(false);
    }
}
