using UnityEngine;

public class PlanetController : MonoBehaviour
{
    private float rotationSpeed = 20f;

    void Update()
    {
        // Rotación constante sobre su eje
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void SetRotation(float value)
    {
        rotationSpeed = value;
    }

    public float GetRotationValue()
    {
        return rotationSpeed;
    }

    public void SetScale(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }
}