using System.Collections;
using UnityEngine;

public class CoinAnimationController : MonoBehaviour
{
    private Animator anim;

    private float randomStart;


    void Start()
    {
        RandomStart();    
    }


    private void RandomStart()
    {
        anim = GetComponentInParent<Animator>();
        anim.enabled = false;
        randomStart = Random.Range(0.1f, 1.5f);

        StartCoroutine(TurnOnAnimation(randomStart, anim));
    }


    private IEnumerator TurnOnAnimation(float duration, Animator _anim)
    {
        yield return new WaitForSeconds(duration);
        _anim.enabled = true;
    }
}
