using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1, 1000)] private float ballMovementPower = 12f;

    private Rigidbody ballRigidbody;

    //private AudioSource ballAudioSource;

    private static bool isCanMove;


    void Awake()
    {
        isCanMove = true;
        ballRigidbody = GetComponent<Rigidbody>();
        //ballAudioSource = GetComponent<AudioSource>();
    }


    public void MoveCharacter(Vector3 movement)
    {
        if (isCanMove)
        {
            ballRigidbody.AddForce(movement * ballMovementPower);
        }
    }


    //void FixedUpdate()
    //{
    //    PlayIfMoving();
    //}


    //private void PlayIfMoving()
    //{
    //    float maxSpeed = 2.67f * ballMovementPower;
    //    if (ballRigidbody.velocity.magnitude >= 0f)
    //    {
    //        ballAudioSource.volume = ((ballRigidbody.velocity.magnitude * ballMovementPower) / maxSpeed);
    //        ballAudioSource.PlayOneShot(ballAudioSource.clip);
    //    }
    //}


    public float BallMovementPower { get => ballMovementPower; set => ballMovementPower = value; }

    public static bool IsCanMove { get => isCanMove; set => isCanMove = value; }
}