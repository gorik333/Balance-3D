using System.Collections;
using UnityEngine;

public class TipsFirstLevel : MonoBehaviour
{
    [SerializeField] private GameObject startGameTip;
    [SerializeField] private GameObject controlBallTip;
    [SerializeField] private GameObject openOrBreakDoor;
    [SerializeField] private GameObject pushBoxTip;

    [SerializeField] private GameObject boxDoesntFallTip;
    [SerializeField] private GameObject deathObstaclesTip;
    [SerializeField] private GameObject collectCoinTip;
    [SerializeField] private GameObject showGameScore;

    [SerializeField] private GameObject cameraTip;

    private bool isPlayerMoved = false;
    private bool isCoinCollected = false;
    private bool isCameraChanged = false;

    private float boxDoesntFallTimer;


    void Start()
    {
        TipsOnStart();
    }


    void Update()
    {
        CheckFirstMove();
        CheckIfBoxFallen();
        CheckIfChangedLook();
    }


    private void CheckIfChangedLook()
    {
        if((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) || isCameraChanged)
        {
            cameraTip.SetActive(false);
        }
    }


    private void CheckIfBoxFallen()
    {
        if (WoodBoxFall.IsBoxFallen)
        {
            boxDoesntFallTip.SetActive(false);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Equals("WoodBoxForFalling"))
        {
            boxDoesntFallTimer += Time.deltaTime; // Типа задержка перед появлением подсказки про "не толкать коробку"
            if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 0.011f
                && !WoodBoxFall.IsBoxFallen && boxDoesntFallTimer >= 1.5f)
            {
                boxDoesntFallTip.SetActive(true);
            }
        }
    }


    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name.Equals("DoorWithAnimation"))
        {
            if (Input.GetKeyDown(KeyCode.R) || collider.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DoorKnockedOut"))
            {
                GameObject arrow = GameObject.Find("DoorArrow");
                StartCoroutine(DestroyObjectTimer(0.6f, arrow));
                StartCoroutine(TurnOffTipTimer(2f, openOrBreakDoor));
            }
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("PushBoxTrigger"))
        {
            pushBoxTip.SetActive(true);
            StartCoroutine(TurnOffTipTimer(6, pushBoxTip));
        }
        if (collider.gameObject.name.Equals("DeathObstaclesAndCoinTrigger") && !isCoinCollected)
        {
            deathObstaclesTip.SetActive(true);
            collectCoinTip.SetActive(true);
            StartCoroutine(TurnOffTipTimer(7, deathObstaclesTip, collectCoinTip));
            isCoinCollected = true;
        }
        if (collider.gameObject.name.Equals("Anim&Particles"))
        {
            showGameScore.SetActive(true);
            collectCoinTip.SetActive(false);
            GameObject arrow = GameObject.Find("CoinArrow");
            StartCoroutine(DestroyObjectTimer(1.1f, arrow));
        }
        if (collider.gameObject.name.Equals("CameraTipTrigger"))
        {
            cameraTip.SetActive(true);
            StartCoroutine(TurnOffTipTimer(7, cameraTip));
        }
    }


    private void TipsOnStart()
    {
        openOrBreakDoor.SetActive(true);
        controlBallTip.SetActive(true);
        startGameTip.SetActive(true);
        StartCoroutine(TurnOffTipTimer(7, startGameTip));
    }


    private void CheckFirstMove()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.1f && !isPlayerMoved)
        {
            isPlayerMoved = true;
            controlBallTip.SetActive(false);
        }
    }


    private IEnumerator DestroyObjectTimer(float duration, params GameObject[] _gameObjects)
    {
        yield return new WaitForSeconds(duration);

        for (int i = 0; i < _gameObjects.Length; ++i)
        {
            Destroy(_gameObjects[i]);
        }
    }


    private IEnumerator TurnOffTipTimer(float duration, params GameObject[] _gameObjects)
    {
        yield return new WaitForSeconds(duration);

        for (int i = 0; i < _gameObjects.Length; ++i)
        {
            _gameObjects[i].SetActive(false);
        }
    }


    public GameObject BoxDoesntFallTip { get => boxDoesntFallTip; set => boxDoesntFallTip = value; }
}
