using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public List<GameObject> objectPrefabs; // lista de prefabs de planetas
    public GameObject selectedPlanetObject;

    private List<GameObject> spawnedPlanets = new List<GameObject>();

    // Método para spawnear un planeta aleatorio
    public void RandomizeSpawnOption()
    {
        if (objectPrefabs.Count == 0) return;

        int index = Random.Range(0, objectPrefabs.Count);
        GameObject prefab = objectPrefabs[index];
        GameObject newPlanet = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        spawnedPlanets.Add(newPlanet);

        selectedPlanetObject = newPlanet;

        PlanetController pc = newPlanet.GetComponent<PlanetController>();
        if (pc != null)
        {
            GlobalPlanetSlider slider = Object.FindFirstObjectByType<GlobalPlanetSlider>();
            if (slider != null)
                slider.SetSelectedPlanet(pc);
        }

        Debug.Log("Planeta aleatorio spawneado: " + newPlanet.name);
    }
}
