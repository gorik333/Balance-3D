using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TipsSecondLevel : MonoBehaviour
{
    [SerializeField] private GameObject pushBoxTip;
    [SerializeField] private GameObject sharpWallsTip;
    [SerializeField] private GameObject deathCirclesTip;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name.Equals("PushBoxTipTrigger"))
        {
            pushBoxTip.SetActive(true);
        }
        if (collider.name.Equals("SharpWallsTipTrigger"))
        {
            sharpWallsTip.SetActive(true);
            StartCoroutine(TurnOffTipTimer(7, sharpWallsTip));
        }
        if (collider.name.Equals("DeathCirclesTipTrigger"))
        {
            deathCirclesTip.SetActive(true);
            StartCoroutine(TurnOffTipTimer(7, deathCirclesTip));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (pushBoxTip.gameObject.activeInHierarchy && collision.gameObject.name.Equals("WoodBox"))
        {
            pushBoxTip.GetComponentInChildren<Text>().text = "Теперь пытайся её подвигать, она ставится. Бери мальнький разгон так легче.";
            StartCoroutine(TurnOffTipTimer(5, pushBoxTip));
        }
    }


    private IEnumerator TurnOffTipTimer(float duration, params GameObject[] _gameObjects)
    {
        yield return new WaitForSeconds(duration);
        for (int i = 0; i < _gameObjects.Length; ++i)
        {
            _gameObjects[i].SetActive(false);
        }
    }
}
