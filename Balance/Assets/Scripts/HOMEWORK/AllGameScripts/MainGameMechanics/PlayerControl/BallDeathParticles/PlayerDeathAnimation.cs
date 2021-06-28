using UnityEngine;

public class PlayerDeathAnimation : MonoBehaviour
{
    private Animator anim;
    private CameraRotation cameraRotation;


    void Start()
    {
        cameraRotation = FindObjectOfType(typeof(CameraRotation)) as CameraRotation;
        anim = GetComponent<Animator>();
    }


    public void StartDeathAnimation()
    {
        if (PlayerStats.NumberOfLives > 1)
        {
            anim.SetTrigger("Death");
            anim.SetTrigger("Reincarnation");
            //cameraRotation.DefaultValues(); // Не нравится когда камера становится default look
        }
        else if(PlayerStats.NumberOfLives == 1)
        {
            anim.SetTrigger("Death");
        }
    }
}
