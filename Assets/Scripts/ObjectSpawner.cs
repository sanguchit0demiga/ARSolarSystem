using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlanetSpawner : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject currentPlanetPrefab = null;
    private List<GameObject> spawnedPlanets = new List<GameObject>();

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
                // Instanciar un nuevo planeta en la posición tocada sobre el plano
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    if (currentPlanetPrefab != null)
                    {
                        GameObject newPlanet = Instantiate(currentPlanetPrefab, hitPose.position, hitPose.rotation);
                        newPlanet.transform.parent = null;

                        spawnedPlanets.Add(newPlanet);
                        Debug.Log("Planeta agregado. Total en lista: " + spawnedPlanets.Count);
                    }
                    else
                    {
                        Debug.LogWarning("No se ha seleccionado ningún planeta.");
                    }
                }
            }
        }
    }

    public void DeleteLastPlanet()
    {
        if (spawnedPlanets.Count > 0)
        {
            GameObject lastPlanet = spawnedPlanets[spawnedPlanets.Count - 1];
            Destroy(lastPlanet);
            spawnedPlanets.RemoveAt(spawnedPlanets.Count - 1);
            Debug.Log("Último planeta eliminado. Restan: " + spawnedPlanets.Count);
        }
        else
        {
            Debug.Log("No hay planetas para eliminar.");
        }
    }
}
