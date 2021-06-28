using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private static Animator _transition;

    private const float CROSSFADE_ANIM_DELAY = 1f;


    void Awake()
    {
        Time.timeScale = 1f;
        _transition = GetComponentInChildren<Animator>();
    }


    public IEnumerator AnimationDelayBeetwenLevels(int sceneNumber)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(CROSSFADE_ANIM_DELAY);
        SceneManager.LoadScene($"Level_{sceneNumber}");
    }


    public IEnumerator AnimationDelayToMenu()
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(CROSSFADE_ANIM_DELAY);
        SceneManager.LoadScene("Menu");
    }


    public IEnumerator AnimationDelayToGamePassed()
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(CROSSFADE_ANIM_DELAY);
        SceneManager.LoadScene("GamePassed");
    }


    public IEnumerator AnimationDelatToRestart()
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(CROSSFADE_ANIM_DELAY);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}