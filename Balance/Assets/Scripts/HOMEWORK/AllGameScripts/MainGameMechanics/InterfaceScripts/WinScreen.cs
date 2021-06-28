using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Text totalScoreNumberText;

    private LevelLoader _levelLoader;


    void Start()
    {
        _levelLoader = FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
        totalScoreNumberText.text = MainGameInterface.Score.ToString();
    }


    public void NextLevelOnClick()
    {
        StartCoroutine(_levelLoader.AnimationDelayBeetwenLevels(SceneManager.GetActiveScene().buildIndex + 1));
        DefaultSettings();
    }


    public void RestartLevelOnClick()
    {
        StartCoroutine(_levelLoader.AnimationDelayBeetwenLevels(SceneManager.GetActiveScene().buildIndex));
        DefaultSettings();
    }


    public void ExitToMenuOnClick()
    {
        StartCoroutine(_levelLoader.AnimationDelayToMenu());
    }


    private void DefaultSettings()
    {
        CameraRotation.Rotation = 0;
    }
}
