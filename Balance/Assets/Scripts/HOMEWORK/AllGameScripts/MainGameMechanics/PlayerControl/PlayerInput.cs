using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{
    private Vector3 movement;

    private PlayerMovement playerMovement;

    private Rigidbody ballRigidody;

    private static bool isGrounded = false;

    private static bool isAllowed = true;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        ballRigidody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (CameraRotation.Rotation.Equals(0)) // Тут ввод игрока зависит от того, как повернута камера. Чтобы прямо, всегда было прямо
        {
            movement = new Vector3(horizontal, 0, vertical).normalized; // привести к единичному значению
        }
        if (CameraRotation.Rotation.Equals(90))
        {
            movement = new Vector3(-vertical, 0, horizontal).normalized;
        }
        if (CameraRotation.Rotation.Equals(180))
        {
            movement = new Vector3(-horizontal, 0, -vertical).normalized;
        }
        if (CameraRotation.Rotation.Equals(270))
        {
            movement = new Vector3(vertical, 0, -horizontal).normalized;
        }
    }


    private void FixedUpdate()
    {
        if (isGrounded && isAllowed)
        {
            ballRigidody.drag = 2.6f;
            ballRigidody.angularDrag = 2.6f;
            playerMovement.MoveCharacter(movement);
        }
    }

    /// <summary>
    /// Я использовал данный метод, так как Physics.RayCast() мне не понравился, если шар на краю стоит,
    /// он перестает реагировать, там нужно кучу векторов настраивать
    /// </summary>
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }


    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        ballRigidody.drag = 1f;
        ballRigidody.angularDrag = 1f;
    }


    public static bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    public static bool IsAllowed { get => isAllowed; set => isAllowed = value; }
}
