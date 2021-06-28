using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen; 
    [SerializeField] private GameObject _winScreen;

    private GameMaster _gameMaster;
    private LevelLoader _levelLoader;


    private void Awake()
    {
        _levelLoader = FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
        _gameMaster = FindObjectOfType(typeof(GameMaster)) as GameMaster;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name.Equals("FinishTrigger"))
        {
            WinScreen();
        }
        if (collider.name.Equals("FinishGameTrigger"))
        {
            StartCoroutine(_levelLoader.AnimationDelayToGamePassed());
        }
    }


    public void LoseScreen()
    {
        _loseScreen.SetActive(true);
        TimeAndButtonControl();
    }


    public void WinScreen()
    {
        _winScreen.SetActive(true);
        TimeAndButtonControl();
    }


    private void TimeAndButtonControl()
    {
        Time.timeScale = 0f;
    }


    private IEnumerator LoseScreenDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        LoseScreen();
    }


    private IEnumerator ReincarnationDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.position = _gameMaster.LastCheckPointPos;
    }
}