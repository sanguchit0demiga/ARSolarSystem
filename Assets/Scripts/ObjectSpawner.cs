using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlanetSpawner : MonoBehaviour
{
    public ARRaycastManager raycastManager; // ARRaycastManager de tu AR Session Origin
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject currentPlanetPrefab = null; // El planeta seleccionado por UI

    // Este método se llama desde el selector/UI
    public void SetPlanetPrefab(GameObject planetPrefab)
    {
        currentPlanetPrefab = planetPrefab;
        Debug.Log("Planeta seleccionado: " + planetPrefab.name);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;

                    if (currentPlanetPrefab != null)
                        Instantiate(currentPlanetPrefab, hitPose.position, hitPose.rotation);
                    else
                        Debug.LogWarning("No se ha seleccionado ningún planeta.");
                }
            }
        }
    }
}
