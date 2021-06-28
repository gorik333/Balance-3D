using System.Collections;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private PlayerInteraction playerInteraction;
    private GameMaster gm;

    private const float ANIMATION_DELAY = 2.3f;


    void Start()
    {
        gm = FindObjectOfType(typeof(GameMaster)) as GameMaster;
        playerInteraction = FindObjectOfType(typeof(PlayerInteraction)) as PlayerInteraction;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && PlayerStats.NumberOfLives == 1)
        {
            BallDeathParticles.IsFallen = true;
            StartCoroutine(LoseScreenDelay(ANIMATION_DELAY));
        }
        else if (collider.gameObject.CompareTag("Player") && PlayerStats.NumberOfLives > 1)
        {
            BallDeathParticles.IsFallen = true;
            StartCoroutine(AnimationDelay(ANIMATION_DELAY, collider));
            PlayerStats.NumberOfLives -= 1;
            StartCoroutine(FreezeMoving(0.6f));
        }
        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, collider.transform.position);
    }


    private IEnumerator FreezeMoving(float duration)
    {
        PlayerMovement.IsCanMove = false;
        yield return new WaitForSeconds(duration);
        PlayerMovement.IsCanMove = true;
    }


    private IEnumerator LoseScreenDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        playerInteraction.LoseScreen();
    }


    private IEnumerator AnimationDelay(float duration, Collider collider)
    {
        yield return new WaitForSeconds(duration);
        collider.gameObject.GetComponent<Animator>().SetTrigger("Reincarnation");
        gm.RespawnOnLastCheckPoint();
    }
}
