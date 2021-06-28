using UnityEngine;

namespace GlobalTypeNames.Types
{
    public class SetStoneType : MonoBehaviour
    {
        private TypeOfBall typeOfBall;


        void Awake()
        {
            typeOfBall = FindObjectOfType(typeof(TypeOfBall)) as TypeOfBall;
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Player") && TypeOfBall.CurrentTypeString != GlobalStringVals.STONE_TYPE)
            {
                GetComponent<AudioSource>().Play();
                typeOfBall.ChangeToStoneType();
            }
        }
    }
}
