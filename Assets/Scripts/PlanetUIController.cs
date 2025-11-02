using UnityEngine;

public class PlanetUIController : MonoBehaviour
{
    public string planetTag = "Planet";

    public void DeleteLastPlanet()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag(planetTag);

        if (planets.Length == 0)
        {
            Debug.Log("No hay planetas para eliminar.");
            return;
        }

        GameObject lastPlanet = planets[planets.Length - 1];
        Destroy(lastPlanet);
        Debug.Log("Último planeta eliminado: " + lastPlanet.name);
    }

    public void DeleteAllPlanets()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag(planetTag);

        foreach (GameObject planet in planets)
            Destroy(planet);

        Debug.Log("Todos los planetas eliminados.");
    }
}
