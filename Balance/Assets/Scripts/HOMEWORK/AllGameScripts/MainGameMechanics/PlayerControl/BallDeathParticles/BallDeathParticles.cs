using UnityEngine;
using System.Collections;

public class BallDeathParticles : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private ParticleSystem _deadParticles;
    [SerializeField] private ParticleSystem _lightningParticle;

    private PlayerDeathAnimation playerDeathAnimation;

    private const float DRAG_INCREASE = 2f;

    private Rigidbody ballRigidbody;

    private float currentDrag = 0;

    private static bool isFallen = false;


    void Start()
    {
        ballRigidbody = _player.GetComponent<Rigidbody>();
        playerDeathAnimation = FindObjectOfType(typeof(PlayerDeathAnimation)) as PlayerDeathAnimation;

        _lightningParticle.Pause();
        _deadParticles.Pause();
    }


    void FixedUpdate()
    {
        if (isFallen)
        {
            StopBall();
        }
    }


    private void StartLightingParticles()
    {
        _lightningParticle.transform.position = _player.position;
        _lightningParticle.Play();
    }


    private void StartDeadParticles()
    {
        _deadParticles.transform.position = _player.position;
        _deadParticles.Play();
    }


    private void StopBall()
    {
        ballRigidbody.drag = currentDrag += DRAG_INCREASE; // Плавное замедленние падения

        if (ballRigidbody.velocity.magnitude.Equals(0))
        {
            StartLightingParticles();
            playerDeathAnimation.StartDeathAnimation();
            StartCoroutine(Delay(0.6f));
            IsFallen = false;
        }
    }


    private IEnumerator Delay(float duration)
    {
        yield return new WaitForSeconds(duration);
        StartDeadParticles();
    }


    public static bool IsFallen { get => isFallen; set => isFallen = value; }
}
