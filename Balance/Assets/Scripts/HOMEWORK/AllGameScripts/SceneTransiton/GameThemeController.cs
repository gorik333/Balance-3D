using UnityEngine;
using UnityEngine.SceneManagement;

public class GameThemeController : MonoBehaviour
{
    [SerializeField] private Animator animator;


    void Update()
    {
        if (Input.anyKey && !animator.GetCurrentAnimatorStateInfo(0).IsName("GameTheme"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}