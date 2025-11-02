using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.SceneManagement;

public class PlanetUIManager : MonoBehaviour
{
    public ObjectSpawner objectSpawner; 

    private void SpawnPlanet(int prefabIndex)
    {
        if (objectSpawner != null && prefabIndex >= 0 && prefabIndex < objectSpawner.objectPrefabs.Count)
        {
            objectSpawner.spawnOptionIndex = prefabIndex;
        }
        else
        {
            Debug.LogWarning("Prefab índice inválido o ObjectSpawner no asignado.");
        }
    }

    public void SpawnEarth() { SpawnPlanet(0); }
    public void SpawnJupiter() { SpawnPlanet(1); }
    public void SpawnMars() { SpawnPlanet(2); }
    public void SpawnMercury() { SpawnPlanet(3); }
    public void SpawnMoon() { SpawnPlanet(4); }
    public void SpawnNeptune() { SpawnPlanet(5); }
    public void SpawnSaturn() { SpawnPlanet(6); }
    public void SpawnSun() { SpawnPlanet(7); }
    public void SpawnUranus() { SpawnPlanet(8); }
    public void SpawnVenus() { SpawnPlanet(9); }

   
    public void SpawnRandom()
    {
        if (objectSpawner != null)
        {
            objectSpawner.RandomizeSpawnOption();
        }
    }

    public void OnMenuPressed()
    {
       SceneManager.LoadScene("Menu");
    }
}
