using UnityEngine;

namespace GlobalTypeNames.Types
{
    public class SetWoodType : MonoBehaviour
    {
        private TypeOfBall typeOfBall;


        void Awake()
        {
            typeOfBall = FindObjectOfType(typeof(TypeOfBall)) as TypeOfBall;
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Player") && TypeOfBall.CurrentTypeString != GlobalStringVals.WOOD_TYPE)
            {
                GetComponent<AudioSource>().Play();
                typeOfBall.ChangeToWoodType();
            }
        }
    }
}
