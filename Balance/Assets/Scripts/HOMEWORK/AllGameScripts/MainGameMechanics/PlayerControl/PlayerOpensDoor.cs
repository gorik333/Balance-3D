using UnityEngine;

public class PlayerOpensDoor : MonoBehaviour
{
    [SerializeField] private GameObject doorTip;

    private float currentSpeed;


    void FixedUpdate()
    {
        currentSpeed = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
    }


    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag.Equals("OpenDoorTrigger"))
        {
            if (Input.GetKeyDown(KeyCode.R) &&
                !collider.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DoorOpening")) // Проверка на то что не проигрывается анимация про откртие двери
                                                                                                                    // потому что она сама потом будет включаться
                                                                                                                    // так же первая проверка для того, чтобы другие коллайдеры 
                                                                                                                    // не попадали под проверки, и не происходило ошибок
            {
                collider.gameObject.GetComponent<Animator>().SetTrigger("DoorOpening");
                doorTip.SetActive(false);
            }
            else if (!collider.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DoorOpening")) // Чтобы надпись появилась сама когда игрок в зоне триггера,
                                                                                                              // и игрок не успел пройти, надпись появлялась
            {
                doorTip.SetActive(true);
            }
            if (collider.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DoorKnockedOut"))
            {
                Destroy(collider.GetComponent<Collider>());
                doorTip.SetActive(false);
            }
        }
    }


    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag.Equals("OpenDoorTrigger"))
        {
            doorTip.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("KnockOutDoor"))
        {
            int chance = Random.Range(1, 100);
            if (currentSpeed >= 2.67f && chance > 25 && !collision.gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DoorOpening"))
            // чтобы когда игрок может быть и врезался быстро, но он
            // нажал до столкновениякнопку открыть, поэтому анимация, "дверь выбита"
            // не сработает
            // Так же, есть шанс на то что выбьет дверь или нет
            {
                collision.gameObject.GetComponentInParent<Animator>().SetTrigger("DoorKnockedOut");
            }
        }
    }
}
