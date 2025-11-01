using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float planetRotation;

    public void SetRotation()
    {
        transform.Rotate(Vector3.up, planetRotation * Time.deltaTime);
    }


    }

