using System.Collections;
using UnityEngine;

namespace GlobalTypeNames.Types
{
    public class SpeedBoost : MonoBehaviour
    {
        [SerializeField] private Transform player;

        [SerializeField] private float bonusLifeTime;

        private BonusManager bonusManager;

        private const float BONUS_DURATION = 2.5f;


        void Start()
        {
            bonusManager = FindObjectOfType(typeof(BonusManager)) as BonusManager;
        }


        void FixedUpdate()
        {
            if (Vector3.Distance(player.position, transform.position) >= 1)
            {
                transform.LookAt(player);
            }
        }


        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag.Equals("Player"))
            {
                AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
                bonusManager.SpeedBonus(BONUS_DURATION);
                StartCoroutine(TurnOffBonus(bonusLifeTime));
            }
        }


        private IEnumerator TurnOffBonus(float duration)
        {
            yield return new WaitForSeconds(duration);
            gameObject.SetActive(false);
        }
    }
}
