using UnityEngine;

public class StartCircleAnimation : MonoBehaviour
{
    private float randomStartTimer;


    private void Start()
    {
        randomStartTimer = Random.Range(1f, 6f);
    }


    private void Update()
    {
        randomStartTimer -= Time.deltaTime;

        if (randomStartTimer <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("StartAnimation");
            Destroy(gameObject.GetComponent<StartCircleAnimation>());
        }
    }
}
