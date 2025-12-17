using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlanetSpawner : MonoBehaviour
{
    public PlanetInfo lastSpawnedPlanet;
    public ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject currentPlanetPrefab = null;

    // Mantenemos la lista solo para cuando queramos borrar el último, 
    // pero para los sliders usaremos Tags.
    private List<GameObject> spawnedPlanets = new List<GameObject>();

    [Header("Configuración de UI")]
    public Slider sliderEscala;
    public Slider sliderRotacion;

    public void SetPlanetPrefab(GameObject planetPrefab)
    {
        currentPlanetPrefab = planetPrefab;
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
                    Pose hitPose = hits[0].pose;
                    if (currentPlanetPrefab != null)
                    {
                        GameObject newPlanet = Instantiate(currentPlanetPrefab, hitPose.position, hitPose.rotation);

                        // Aseguramos que tenga el TAG correcto por si olvidaste el Paso 1
                        newPlanet.tag = "Planet";

                        newPlanet.transform.parent = null;

                        // Aplicar valores iniciales de los sliders al nacer
                        if (sliderEscala != null)
                            newPlanet.transform.localScale = Vector3.one * sliderEscala.value;

                        if (sliderRotacion != null)
                        {
                            PlanetRotation rot = newPlanet.GetComponent<PlanetRotation>();
                            if (rot != null) rot.planetRotation = sliderRotacion.value;
                        }

                        spawnedPlanets.Add(newPlanet);
                    }
                }
            }
        }
    }

    // --- VERSIÓN UNIVERSAL: Busca por TAG ---

    public void ActualizarEscala()
    {
        // Buscamos TODOS los objetos que tengan el tag "Planet" en la escena
        GameObject[] planetasEnEscena = GameObject.FindGameObjectsWithTag("Planet");

        if (planetasEnEscena.Length == 0)
        {
            // Solo advertimos si es la primera vez, para no llenar la consola
            Debug.Log("⚠️ Slider movido, pero no encuentro objetos con Tag 'Planet'.");
            return;
        }

        float valor = sliderEscala.value;

        foreach (GameObject p in planetasEnEscena)
        {
            p.transform.localScale = Vector3.one * valor;
        }
    }

    public void ActualizarVelocidad()
    {
        GameObject[] planetasEnEscena = GameObject.FindGameObjectsWithTag("Planet");

        if (planetasEnEscena.Length == 0) return;

        float valor = sliderRotacion.value;

        foreach (GameObject p in planetasEnEscena)
        {
            PlanetRotation rot = p.GetComponent<PlanetRotation>();
            if (rot != null)
            {
                rot.planetRotation = valor;
            }
        }
    }

    public void DeleteLastPlanet()
    {
        if (spawnedPlanets.Count > 0)
        {
            GameObject last = spawnedPlanets[spawnedPlanets.Count - 1];
            Destroy(last);
            spawnedPlanets.RemoveAt(spawnedPlanets.Count - 1);
        }
    }
}