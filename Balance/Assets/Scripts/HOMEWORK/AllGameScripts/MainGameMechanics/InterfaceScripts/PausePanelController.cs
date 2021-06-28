using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _otherLevelsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _chooseLevelPanel;

    [SerializeField] private GameObject _pauseButton;

    private bool isPressed = false;

    private LevelLoader levelLoader;
    private static PausePanelController _instance;


    private void Awake()
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

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }


    private void OnActiveSceneChanged(Scene unloadedScene, Scene loadedScene)
    {
        Time.timeScale = 1f;
        HidePauseAndLevelsPanel();
        levelLoader = FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
    }


    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }


    public void OnClickOpenOrClose()
    {
        ResumeGame();
        ToggleGame();
    }


    private void ResumeGame()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }


    public void OnClickRestart()
    {
        StartCoroutine(levelLoader.AnimationDelatToRestart());
    }

    
    public void OnClickSettings()
    {
        _settingsPanel.SetActive(true);
    }


    public void OnClickChangeLevel()
    {
        _otherLevelsPanel.SetActive(true);
    }


    public void OnClickBackToMenu()
    {
        StartCoroutine(levelLoader.AnimationDelayToMenu());
    }

   
    private void HidePauseAndLevelsPanel()
    {
        _pauseMenu.SetActive(false);
        _chooseLevelPanel.SetActive(false);
        isPressed = !isPressed;
    }


    private void ToggleGame()
    {
        isPressed = !isPressed;
        _pauseMenu.SetActive(isPressed);
        _chooseLevelPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }


    public void TurnOffPauseButton()
    {
        _pauseButton.SetActive(false);
    }


    public IEnumerator TurnOnPauseButton()
    {
        yield return new WaitForSecondsRealtime(1f);
        _pauseButton.SetActive(true);
    }
}
