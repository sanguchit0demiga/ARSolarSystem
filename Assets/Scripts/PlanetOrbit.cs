using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public float orbitSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up, orbitSpeed * Time.deltaTime);
    }
}