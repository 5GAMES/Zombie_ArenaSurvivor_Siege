using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioSource _musicSource;
    private bool _IsPlay;
    private void Start()
    {
        _musicSource.clip = _musicClip;
       
           InvokeRepeating("PlayMusic", 5f, 0.5f);
       
    }
    private void PlayMusic()
    {

        if (Time.timeScale == 1 && !_IsPlay)
        {
            Debug.Log("YEs");
            _musicSource.Play();
            _IsPlay = true;
        }

        if(Time.timeScale == 0 && _IsPlay)
        {
            Debug.Log("No");
            _musicSource.Stop();
            _IsPlay = false;
        }
    }
}
