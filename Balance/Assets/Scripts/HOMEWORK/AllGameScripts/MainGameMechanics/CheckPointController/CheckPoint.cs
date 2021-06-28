using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject pointMark;
    private GameMaster gm;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
            gm.LastCheckPointPos = transform.position;
            gm.ReloadToLastState();
            gameObject.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
        pointMark.transform.rotation = Quaternion.LookRotation(pointMark.transform.position - Camera.main.transform.position);
    }
}
