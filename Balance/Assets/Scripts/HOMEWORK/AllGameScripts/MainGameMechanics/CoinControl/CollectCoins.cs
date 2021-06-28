using System.Collections;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        var emission = GetComponent<ParticleSystem>();
        emission.Stop();
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            var emission = GetComponent<ParticleSystem>();
            emission.Play();
            CollectCoinActions();
            audioSource.pitch = Random.Range(1f, 1.05f); // Для разнообразия
            audioSource.Play();
        }
    }


    private void CollectCoinActions()
    {
        MainGameInterface.Score++;
        GetComponentInParent<Animator>().SetTrigger("Collect");
        Destroy(GetComponent<Collider>());
        StartCoroutine(DestroyObjectTimer(1.2f, transform.parent.gameObject)); // уничтожение самого объекта с задержкой.
    }


    private IEnumerator DestroyObjectTimer(float duration, GameObject _gameObject)
    {
        yield return new WaitForSeconds(duration);
        Destroy(_gameObject);
    }
}
