using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private Text totalScoreNumberText;

    private LevelLoader _levelLoader;


    void Start()
    {
        _levelLoader = FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
        totalScoreNumberText.text = MainGameInterface.Score.ToString();
    }


    public void RestartLevelOnClick()
    {
        CameraRotation.Rotation = 0;
        StartCoroutine(_levelLoader.AnimationDelayBeetwenLevels(SceneManager.GetActiveScene().buildIndex));
    }


    public void ExitToMenuOnClick()
    {
        StartCoroutine(_levelLoader.AnimationDelayToMenu());
    }
}
