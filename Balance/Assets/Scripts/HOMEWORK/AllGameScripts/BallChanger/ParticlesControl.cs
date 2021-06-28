using UnityEngine;
using System.Collections;

namespace GlobalTypeNames.Types
{
    public class ParticlesControl : MonoBehaviour
    {
        private ParticleSystem changerParticleSystem;

        private const float DELAY_DURATION = 1.5f;

        private static string currentType;

        private TypeOfBall typeOfBall;


        void Start()
        {
            typeOfBall = FindObjectOfType(typeof(TypeOfBall)) as TypeOfBall; // Без этого почему-то не работает.
            currentType = TypeOfBall.CurrentTypeString;
            changerParticleSystem = GetComponent<ParticleSystem>();
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Player") && !currentType.Equals(TypeOfBall.CurrentTypeString))
            {
                var changeColor = changerParticleSystem.main;
                changeColor.startColor = Color.green;

                var stopEmission = changerParticleSystem.emission;
                stopEmission.rateOverTime = 0f;

                changerParticleSystem.emission.SetBurst(0, new ParticleSystem.Burst(0.1f, 30, 1, 1.1f));

                changerParticleSystem.Play();

                currentType = TypeOfBall.CurrentTypeString;
                StartCoroutine(TurnOffDelay(DELAY_DURATION));
            }
        }


        private void ContinuePlaying()
        {
            changerParticleSystem.emission.SetBurst(0, new ParticleSystem.Burst(0.1f, 0, 1, 1.1f));

            var changeColor = changerParticleSystem.main;
            changeColor.startColor = Color.red;

            changerParticleSystem.Play();
            
            var stopEmission = changerParticleSystem.emission;
            stopEmission.rateOverTime = 7f;
        }


        private IEnumerator TurnOffDelay(float duration)
        {
            yield return new WaitForSeconds(duration);
            changerParticleSystem.Stop();
            yield return new WaitForSeconds(duration * 2);
            ContinuePlaying();
        }
    }
}