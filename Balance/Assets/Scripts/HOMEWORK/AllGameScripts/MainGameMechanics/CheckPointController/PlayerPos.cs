using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.Respawn;
    }
}
