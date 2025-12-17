using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.SceneManagement;

public class PlanetUIManager : MonoBehaviour
{
    public PlanetSpawner planetSpawner; // Referencia al spawner que maneja los planetas
    public static GameObject currentPlanet;

    private void SpawnPlanet(int prefabIndex)
    {
        if (planetSpawner != null && prefabIndex >= 0 && prefabIndex < planetSpawner.objectPrefabs.Count)
        {
            GameObject prefab = planetSpawner.objectPrefabs[prefabIndex];

            // Instanciamos el planeta en la escena (posicion 0,0,0 por defecto, podes cambiar)
            GameObject newPlanet = Instantiate(prefab, Vector3.zero, Quaternion.identity);

            // Guardamos la instancia en el PlanetSpawner
            planetSpawner.selectedPlanetObject = newPlanet;

            // Asignamos la instancia al slider
            PlanetController pc = newPlanet.GetComponent<PlanetController>();
            if (pc != null)
            {
                GlobalPlanetSlider slider = Object.FindFirstObjectByType<GlobalPlanetSlider>();
                if (slider != null)
                {
                    slider.SetSelectedPlanet(pc);
                    Debug.Log("Planeta spawneado y asignado al slider: " + newPlanet.name);
                }
            }

            currentPlanet = newPlanet;
            Debug.Log("Planeta seleccionado: " + currentPlanet.name);
        }
        else
        {
            Debug.LogWarning("Prefab índice inválido o PlanetSpawner no asignado.");
        }
    }

    // Métodos para cada planeta
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
    public void SpawnSolarSystem() { SpawnPlanet(10); }

    public void SpawnRandom()
    {
        if (planetSpawner != null)
        {
            planetSpawner.RandomizeSpawnOption();
        }
    }

    public void OnMenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
