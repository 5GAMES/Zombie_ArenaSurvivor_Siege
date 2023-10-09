using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDron : MonoBehaviour
{
    private AudioSource _dron;
   private IEnumerator DestroYDron()
    {
        _dron.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    private void Start()
    {
          var Audio = GetComponent<AudioSource>();
          _dron = Audio;
          StartCoroutine(DestroYDron());
    }

}
