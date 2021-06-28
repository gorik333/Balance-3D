using UnityEngine;

public class ParticlesRotation : MonoBehaviour
{
    private Vector3 _rotation;


    void FixedUpdate()
    {
        _rotation.y += Time.fixedDeltaTime * 300;
        transform.eulerAngles = _rotation; 
    }
}
