using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    [SerializeField] private float xOffSet;
    [SerializeField] private float yOffSet;
    [SerializeField] private float zOffSet;

    private static int rotation;

    private bool isCorrect;
    private bool isEnteredToLabyrinth = false;

    private const float positiveNumber = 3.5f;
    private const float negativeNumber = -3.5f;


    void Start()
    {
        DefaultValues();
    }


    public void DefaultValues()
    {
        xOffSet = 0;
        yOffSet = 1.4f;
        zOffSet = -3.5f;
        rotation = 0;
    }


    public void LabyrinthValues()
    {
        isEnteredToLabyrinth = !isEnteredToLabyrinth;
        if (isEnteredToLabyrinth)
        {
            xOffSet = 0;
            yOffSet = 5f;
            zOffSet = 0f;
        }
        else
        {
            DefaultValues();
        }
    }


    void Update()
    {
        if (PlayerInput.IsGrounded)
        {
            TurnRight();
            TurnLeft();
            isCorrect = false;
        }
        transform.position = ball.transform.position + new Vector3(xOffSet, yOffSet, zOffSet);
        transform.LookAt(ball.transform);
    }

    /// <summary>
    /// Метод для поворота камеры, есть какой-то еще cinemachine, но решил своими силами сделаю
    /// </summary>
    private void TurnRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rotation == 0 && !isCorrect)
            {
                xOffSet = negativeNumber;
                zOffSet = 0f;
                rotation = 270; // Были взяты псевдо значения, сюда можно любое значение ставить.
                isCorrect = true;
            }
            if (rotation == 90 && !isCorrect)
            {
                xOffSet = 0f;
                zOffSet = negativeNumber;
                rotation = 0;
                isCorrect = true;
            }
            if (rotation == 180 && !isCorrect)
            {
                xOffSet = positiveNumber;
                zOffSet = 0f;
                rotation = 90;
                isCorrect = true;
            }
            if (rotation == 270 && !isCorrect)
            {
                xOffSet = 0f;
                zOffSet = positiveNumber;
                rotation = 180;
            }
        }
    }


    private void TurnLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (rotation == 0 && !isCorrect)
            {
                xOffSet = positiveNumber;
                zOffSet = 0f;
                rotation = 90;
                isCorrect = true;
            }
            if (rotation == 90 && !isCorrect)
            {
                xOffSet = 0f;
                zOffSet = positiveNumber;
                rotation = 180;
                isCorrect = true;
            }
            if (rotation == 180 && !isCorrect)
            {
                xOffSet = negativeNumber;
                zOffSet = 0f;
                rotation = 270;
                isCorrect = true;
            }
            if (rotation == 270 && !isCorrect)
            {
                xOffSet = 0f;
                zOffSet = negativeNumber;
                rotation = 0;
            }
        }
    }


    public static int Rotation { get => rotation; set => rotation = value; }
}