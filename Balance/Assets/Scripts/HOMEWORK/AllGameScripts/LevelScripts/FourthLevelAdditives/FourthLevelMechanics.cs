using UnityEngine;
using System.Collections;

public class FourthLevelMechanics : MonoBehaviour
{
    [SerializeField] private GameObject LabyrinthTip;

    private CameraRotation cameraRotation;


    private void Start()
    {
        cameraRotation = FindObjectOfType(typeof(CameraRotation)) as CameraRotation;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("LabyrinthEnter"))
        {
            cameraRotation.LabyrinthValues();
        }
        if (collider.gameObject.name.Equals("LabyrinthTip"))
        {
            LabyrinthTip.SetActive(true);
            StartCoroutine(Delay(7, LabyrinthTip));
        }
    }


    private IEnumerator Delay(float duration, params GameObject[] _gameObjects)
    {
        yield return new WaitForSeconds(duration);
        for(int i = 0; i < _gameObjects.Length; ++i)
        {
            _gameObjects[i].SetActive(false);
        }
    }
}
