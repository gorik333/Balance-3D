using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Vector3 lastCheckPointPos;

    private CameraRotation cameraRotation;

    private Vector3 respawn;

    private Collider[] bonuses;

    private float BONUSES_TURN_ON_RADIUS = 10f;

    private int BONUSES_LAYER_MASK = 1 << 8; //Layer 8

    string oldBallType = string.Empty;


    void Awake()
    {
        cameraRotation = FindObjectOfType(typeof(CameraRotation)) as CameraRotation;
        oldBallType = GlobalTypeNames.Types.TypeOfBall.CurrentTypeString;
        respawn = player.position;
        lastCheckPointPos = respawn;
        bonuses = Physics.OverlapSphere(lastCheckPointPos, BONUSES_TURN_ON_RADIUS, BONUSES_LAYER_MASK); // bonus layer
    }


    public void RespawnOnLastCheckPoint()
    {
        cameraRotation.DefaultValues();
        player.position = lastCheckPointPos;
        TurnBonusesOnAgain();
        SetOldBallType();
    }


    public void ReloadToLastState()
    {
        oldBallType = GlobalTypeNames.Types.TypeOfBall.CurrentTypeString;
        bonuses = Physics.OverlapSphere(lastCheckPointPos, BONUSES_TURN_ON_RADIUS, BONUSES_LAYER_MASK); // bonus layer
    }


    private void SetOldBallType()
    {
        GlobalTypeNames.Types.TypeOfBall typeOfBall = FindObjectOfType(typeof(GlobalTypeNames.Types.TypeOfBall)) as GlobalTypeNames.Types.TypeOfBall;
        typeOfBall.SetType(oldBallType);
    }


    private void TurnBonusesOnAgain()
    {
        foreach (var item in bonuses)
        {
            if (item.gameObject.tag.Equals("Bonus"))
            {
                item.gameObject.SetActive(true);
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(lastCheckPointPos, BONUSES_TURN_ON_RADIUS);
    }


    public Vector3 LastCheckPointPos { get => lastCheckPointPos; set => lastCheckPointPos = value; }

    public Vector3 Respawn { get => respawn; set => respawn = value; }
}
