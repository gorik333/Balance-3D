using UnityEngine;

namespace GlobalTypeNames.Types
{
    public class TypeOfBall : MonoBehaviour
    {
        [SerializeField] private Material _stoneMaterial;
        [SerializeField] private Material _woodMaterial;


        private Rigidbody ballRigidbody;

        private PlayerMovement playerMovement;

        private MeshRenderer meshRenderer;

        private static string currentTypeString;


        void Awake()
        {
            currentTypeString = GlobalStringVals.WOOD_TYPE;
            playerMovement = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
            ballRigidbody = GetComponent<Rigidbody>();
            meshRenderer = GetComponent<MeshRenderer>();
        }


        public void ChangeToStoneType()
        {
            ballRigidbody.mass = 7f;
            playerMovement.BallMovementPower = 55f;
            meshRenderer.material = _stoneMaterial;
            currentTypeString = GlobalStringVals.STONE_TYPE;
        }


        public void ChangeToWoodType()
        {
            ballRigidbody.mass = 1f;
            playerMovement.BallMovementPower = 12f;
            meshRenderer.material = _woodMaterial;
            currentTypeString = GlobalStringVals.WOOD_TYPE;
        }


        public void SetType(string type)
        {
            if (type != null)
            {
                if (type.Equals(GlobalStringVals.WOOD_TYPE))
                {
                    ChangeToWoodType();
                }
                else if (type.Equals(GlobalStringVals.STONE_TYPE))
                {
                    ChangeToStoneType();
                }
            }
        }

        public static string CurrentTypeString { get => currentTypeString; set => currentTypeString = value; }
    }
}