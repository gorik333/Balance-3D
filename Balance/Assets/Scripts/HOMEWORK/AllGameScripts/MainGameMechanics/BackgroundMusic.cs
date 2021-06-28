using UnityEngine;
using System.Collections;


public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic _instance;
    private AudioSource _audioSource;

    private const float ANIM_DURATION = 1f;


    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
        {
            _instance = this;
        }
        //otherwise, if we do, kill this thing
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        StartCoroutine(StartMusicDelay());
    }

    
    public void StopOnStart()
    {
        _audioSource.Stop();
    }


    public void PlayOnEnd()
    {
        _audioSource.PlayDelayed(1.5f);
    }


    private IEnumerator StartMusicDelay()
    {
        _audioSource = GetComponent<AudioSource>();
        yield return new WaitForSeconds(ANIM_DURATION);
        _audioSource.Play();
    }

}

