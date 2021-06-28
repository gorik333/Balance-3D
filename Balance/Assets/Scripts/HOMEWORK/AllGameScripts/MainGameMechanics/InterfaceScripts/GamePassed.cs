using UnityEngine;

public class GamePassed : MonoBehaviour
{
    private AudioSource _saluteSound;

    private LevelLoader _levelLoader;
    private BackgroundMusic _music;
    private PausePanelController _pausePanelController;


    void Awake()
    {
        _pausePanelController = FindObjectOfType(typeof(PausePanelController)) as PausePanelController;
        _pausePanelController.TurnOffPauseButton();

        _music = FindObjectOfType(typeof(BackgroundMusic)) as BackgroundMusic;
        _music.StopOnStart();

        _saluteSound = GetComponent<AudioSource>();
        _saluteSound.Play();
        _levelLoader = FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
    }


    public void OnClickToMenu()
    {
        _music.PlayOnEnd();
        StartCoroutine(_levelLoader.AnimationDelayToMenu());
        StartCoroutine(_pausePanelController.TurnOnPauseButton());
    }
}
