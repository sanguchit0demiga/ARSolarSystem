using UnityEngine;
using System.Collections.Generic;

public class PlanetSelector : MonoBehaviour
{
    public PlanetSpawner spawner;          
    public List<GameObject> planetPrefabs; 

 
    public void SelectPlanetByIndex(int index)
    {
        if (index >= 0 && index < planetPrefabs.Count && spawner != null)
        {
            spawner.SetPlanetPrefab(planetPrefabs[index]);
        }
    }
}
