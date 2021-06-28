using UnityEngine;
using System.Collections;

public class SharpWallMechanics : MonoBehaviour
{
    private PlayerInteraction playerInteraction;

    private GameMaster gm;

    private bool isLeft;


    void Start()
    {
        isLeft = true;
        gm = FindObjectOfType(typeof(GameMaster)) as GameMaster;
        playerInteraction = FindObjectOfType(typeof(PlayerInteraction)) as PlayerInteraction;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player") && PlayerStats.NumberOfLives == 1)
        {
            playerInteraction.LoseScreen();
        }
        else if (collision.gameObject.tag.Equals("Player") && PlayerStats.NumberOfLives > 1 && isLeft)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Reincarnation");
            gm.RespawnOnLastCheckPoint();
            PlayerStats.NumberOfLives -= 1;
            isLeft = false;
            StartCoroutine(FreezeMoving(0.5f));
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isLeft = true;
        }
    }


    private IEnumerator FreezeMoving(float duration)
    {
        PlayerMovement.IsCanMove = false;
        yield return new WaitForSeconds(duration);
        PlayerMovement.IsCanMove = true;
    }
}
