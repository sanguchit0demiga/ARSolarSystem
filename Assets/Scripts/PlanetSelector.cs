using UnityEngine;
using System.Collections.Generic;

public class PlanetSelector : MonoBehaviour
{
    public PlanetSpawner spawner;          // Referencia al PlanetSpawner
    public List<GameObject> planetPrefabs; // Lista de prefabs: Tierra=0, Júpiter=1, Marte=2, etc.

    // Llamado desde UI
    public void SelectPlanetByIndex(int index)
    {
        if (index >= 0 && index < planetPrefabs.Count && spawner != null)
        {
            spawner.SetPlanetPrefab(planetPrefabs[index]);
        }
    }
}
