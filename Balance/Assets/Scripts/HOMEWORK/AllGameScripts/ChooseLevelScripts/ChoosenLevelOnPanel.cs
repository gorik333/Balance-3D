using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChoosenLevelOnPanel : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    private LevelLoader _levelLoader;


    void Start()
    {
        _levelLoader = FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
    }


    public void OnClick()
    {
        string pressedButtonName = EventSystem.current.currentSelectedGameObject.name;
        for (int i = 0; i < buttons.Length; ++i)
        {
            if (buttons[i].name.Equals(pressedButtonName) && SceneManager.GetActiveScene().buildIndex != i + 1)
            {
                StartCoroutine(_levelLoader.AnimationDelayBeetwenLevels(i + 1));
            }
        }
    }
}
