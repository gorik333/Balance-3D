using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static int numberOfLives;


    void Awake()
    {
        numberOfLives = 3;
    }


    public static int NumberOfLives { get => numberOfLives; set => numberOfLives = value; }
}
