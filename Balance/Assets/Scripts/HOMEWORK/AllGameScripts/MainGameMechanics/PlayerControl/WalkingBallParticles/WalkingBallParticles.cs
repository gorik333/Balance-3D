using UnityEngine;

public class WalkingBallParticles : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private ParticleSystem _followStoneParticles;
    [SerializeField] private ParticleSystem _followWoodParticles;

    private TypeOfGround TypeOfGround;

    private bool isStoneWorking = false;
    private bool isWoodWorking = false;


    void Start()
    {
        TypeOfGround = FindObjectOfType(typeof(TypeOfGround)) as TypeOfGround;
    }


    void FixedUpdate()
    {
        ToggleStoneParticles();
        ToggleWoodParticles();
    }


    private void ToggleStoneParticles()
    {
        if (TypeOfGround.IsOnStone)
        {
            _followStoneParticles.transform.position = _player.position;
            if (!isStoneWorking)
            {
                _followStoneParticles.Play();
                isStoneWorking = true;
            }
        }
        else
        {
            isStoneWorking = false;
        }
    }


    private void ToggleWoodParticles()
    {
        if (TypeOfGround.IsOnWood)
        {
            _followWoodParticles.transform.position = _player.position;
            if (!isWoodWorking)
            {
                _followWoodParticles.Play();
                isWoodWorking = true;
            }
        }
        else
        {
            isWoodWorking = false;
        }
    }
}
