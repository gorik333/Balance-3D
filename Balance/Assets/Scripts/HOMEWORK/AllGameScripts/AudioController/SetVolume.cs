using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;


    public void MuteAudioOnClick(bool isMuted)
    {
        if (isMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }


    public void SetGeneralVolumeLevel(float sliderValue)
    {
        _mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }


    public void SetMusicLevel(float sliderValue)
    {
        _mixer.SetFloat("BackgroundMusic", Mathf.Log10(sliderValue) * 20);
    }


    public void MuteMusic()
    {
        _mixer.SetFloat("BackgroundMusic", 0.001f);
    }


    public void SetEffectsLevel(float sliderValue)
    {
        _mixer.SetFloat("Effects", Mathf.Log10(sliderValue) * 20);
    }


    public void SetUILevel(float sliderValue)
    {
        _mixer.SetFloat("UI", Mathf.Log10(sliderValue) * 20);
    }
}
