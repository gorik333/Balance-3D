using UnityEngine;

public class ButtonAudioController : MonoBehaviour
{
    private AudioClip audioClip;


    void Start()
    {
        audioClip = GetComponent<AudioSource>().clip;
    }


    public void PlayOnClick()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
}
