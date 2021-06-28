using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FifthLevelTips : MonoBehaviour
{
    [SerializeField] private GameObject _tip;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("BridgeBallTip"))
        {
            _tip.SetActive(true);
            StartCoroutine(TurnOffTip(5, _tip));
        }
        if (collider.gameObject.name.Equals("SpeedBoostTip"))
        {
            _tip.GetComponentInChildren<Text>().text = "Подберите ускорение, чтобы перепрыгнуть через пропасть. Действует 2.5 секунды.";
            _tip.SetActive(true);

            StartCoroutine(TurnOffTip(5, _tip));
        }
    }


    private IEnumerator TurnOffTip(float duration, params GameObject[] _gameObjects)
    {
        yield return new WaitForSeconds(duration);

        for (int i = 0; i < _gameObjects.Length; i++)
        {
            _gameObjects[i].SetActive(false);
        }
    }
}
