using UnityEngine;

namespace GlobalTypeNames.Types
{
    public class BonusManager : MonoBehaviour
    {
        private float _speedBonusDuration;

        [SerializeField] private Camera mainCamera;

        private PlayerMovement playerMovement;


        void Start()
        {
            playerMovement = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        }


        void FixedUpdate()
        {
            CheckIfSpeedBoostEnds();
        }


        public void SpeedBonus(float duration)
        {
            mainCamera.fieldOfView = 85;
            if (TypeOfBall.CurrentTypeString.Equals(GlobalStringVals.WOOD_TYPE))
            {
                playerMovement.BallMovementPower = 52f;
            }
            else if (TypeOfBall.CurrentTypeString.Equals(GlobalStringVals.STONE_TYPE))
            {
                playerMovement.BallMovementPower = 330f;
            }
            _speedBonusDuration = duration;
        }


        private void CheckIfSpeedBoostEnds()
        {
            _speedBonusDuration -= Time.fixedDeltaTime;
            if (_speedBonusDuration <= 0)
            {
                if (TypeOfBall.CurrentTypeString.Equals(GlobalStringVals.WOOD_TYPE))
                {
                    playerMovement.BallMovementPower = 12f;
                }
                else if (TypeOfBall.CurrentTypeString.Equals(GlobalStringVals.STONE_TYPE))
                {
                    playerMovement.BallMovementPower = 55f;
                }
                mainCamera.fieldOfView = 60;
            }
        }
    }
}