using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainGameInterface : MonoBehaviour
{
    [SerializeField] private Text currentGameTimeText;
    [SerializeField] private Text scoreNumberText;
    [SerializeField] private Text livesNumberText;

    private float currentGameTimeNumber;

    private static int score;


    private void Start()
    {
        scoreNumberText.text = "0";
        score = 0;
    }


    private void FixedUpdate()
    {
        ShowCurrentGameTime();
        ShowCurrentGameScore();
        ShowCurrentLivesCount();
    }


    private void ShowCurrentLivesCount()
    {
        livesNumberText.text = PlayerStats.NumberOfLives.ToString();
    }


    private void ShowCurrentGameScore()
    {
        scoreNumberText.text = score.ToString();
    }


    private void ShowCurrentGameTime()
    {
        currentGameTimeNumber += Time.fixedDeltaTime;
        currentGameTimeText.text = Mathf.Round(currentGameTimeNumber).ToString();
    }


    private IEnumerator TurnOffTimer(float duration, params GameObject[] _gameObjects)
    {
        yield return new WaitForSeconds(duration);

        for (int i = 0; i < _gameObjects.Length; ++i)
        {
            _gameObjects[i].SetActive(false);
        }
    }


    public static int Score { get => score; set => score = value; }
}
