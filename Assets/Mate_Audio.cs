using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate_Audio : MonoBehaviour
{
    [SerializeField] AudioClip[] _audioClip;
    [SerializeField] AudioSource _audioSource;
    private bool _isPlay = false;
    private void Start()
    {
       StartCoroutine(PlayAudio());
    }
    private IEnumerator PlayAudio()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            int rnd = Random.Range(0, _audioClip.Length);
            _audioSource.clip = _audioClip[rnd];
            _audioSource.Play();
            
        }
       
    }
   

}
