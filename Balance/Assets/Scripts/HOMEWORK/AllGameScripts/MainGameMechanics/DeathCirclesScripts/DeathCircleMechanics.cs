using UnityEngine;

public class DeathCircleMechanics : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float pushStrength = 2f; // Сила толчка


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector3 direction = collision.transform.position - transform.position; // направление вектора, в какую сторону полетит шар

            collision.rigidbody.AddForce(direction.normalized * pushStrength, ForceMode.Impulse);
        }
    }
}
