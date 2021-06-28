using UnityEngine;

public class SpringPower : MonoBehaviour
{
    [SerializeField] private int strength = 1;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerInput.IsAllowed = false;
            Invoke("Launch", 2f);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInput.IsAllowed = true;
        }
    }


    private void Launch()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * strength);
    }
}
