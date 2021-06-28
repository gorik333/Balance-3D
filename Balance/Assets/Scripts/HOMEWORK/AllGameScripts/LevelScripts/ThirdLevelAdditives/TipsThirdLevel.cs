using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalTypeNames.Types
{
    public class TipsThirdLevel : MonoBehaviour
    {
        [SerializeField] private GameObject tipPanel;

        private bool isChanged = false;


        void FixedUpdate()
        {
            if (TypeOfBall.CurrentTypeString.Equals(GlobalStringVals.STONE_TYPE) && !isChanged)
            {
                tipPanel.GetComponentInChildren<Text>().text = "Теперь вы тяжелее, и мощнее. Коробки будут легче толкаться, но с подъемами проблемка...";
                isChanged = true;
                StartCoroutine(TurnOffTipDelay(8, tipPanel));
            }
        }


        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.name.Equals("ChangeTypeTip"))
            {
                tipPanel.SetActive(true);
            }
            if (collider.gameObject.name.Equals("TryAnotherBallTip"))
            {
                tipPanel.GetComponentInChildren<Text>().text = "Теперь попробуйте тоже самое, и вы почувствуете разницу, если что рядом можно поменять на каменный.";
                tipPanel.SetActive(true);
                StartCoroutine(TurnOffTipDelay(8, tipPanel));
            }
        }


        private IEnumerator TurnOffTipDelay(float duration, params GameObject[] _gameObjects)
        {
            yield return new WaitForSeconds(duration);

            for (int i = 0; i < _gameObjects.Length; ++i)
            {
                _gameObjects[i].SetActive(false);
            }
        }
    }
}