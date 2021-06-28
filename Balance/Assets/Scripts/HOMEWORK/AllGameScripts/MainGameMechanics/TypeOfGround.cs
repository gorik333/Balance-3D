using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfGround : MonoBehaviour
{
    private bool isOnStone = false;
    private bool isOnWood = false;
    private bool isOnIron = false;


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("StoneRoad"))
        {
            isOnStone = true;
        }
        if (collision.gameObject.tag.Equals("WoodRoad"))
        {
            isOnWood = true;
        }
        if (collision.gameObject.tag.Equals("IronRoad"))
        {
            isOnIron = true;
        }
    }

    
    private void OnCollisionExit(Collision collision)
    {
        isOnStone = false;
        isOnWood = false;
        isOnIron = false;
    }


    public bool IsOnStone { get => isOnStone; set => isOnStone = value; }

    public bool IsOnWood { get => isOnWood; set => isOnWood = value; }

    public bool IsOnIron { get => isOnIron; set => isOnIron = value; }
}
