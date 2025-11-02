using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float planetRotation;

    void Update()
    {
        transform.Rotate(Vector3.up, planetRotation * Time.deltaTime);
    }
}

