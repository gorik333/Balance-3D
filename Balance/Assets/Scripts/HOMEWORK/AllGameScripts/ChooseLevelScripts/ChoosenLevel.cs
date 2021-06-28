using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChoosenLevel : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    private LevelLoader _levelLoader;

    private const float CROSSFADE_ANIM_DELAY = 1f;


    void Start()
    {
        _levelLoader = FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
    }


    public void OnClick()
    {
        string pressedButtonName = EventSystem.current.currentSelectedGameObject.name;
        for (int i = 0; i < buttons.Length; ++i)
        {
            if (buttons[i].name.Equals(pressedButtonName))
            {
                Time.timeScale = 1f;
                StartCoroutine(_levelLoader.AnimationDelayBeetwenLevels(++i));
            }
        }
    }
}
