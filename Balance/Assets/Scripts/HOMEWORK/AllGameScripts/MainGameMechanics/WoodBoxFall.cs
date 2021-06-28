using UnityEngine;

public class WoodBoxFall : MonoBehaviour
{
    private static bool isBoxFallen = false;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("BoxTrigger"))
        {
            isBoxFallen = true;
        }
    }


    public static bool IsBoxFallen { get => isBoxFallen; set => isBoxFallen = value; }
}
