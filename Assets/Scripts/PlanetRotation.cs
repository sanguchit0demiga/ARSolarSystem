using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    // Esta variable es modificada por PlanetController.SetRotation()
    public float planetRotation; // Valor inicial por defecto

    void Update()
    {
        // Aplica la rotación constante en cada frame
        transform.Rotate(Vector3.up, planetRotation * Time.deltaTime);
    }
}