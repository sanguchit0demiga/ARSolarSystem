using UnityEngine;

public class PlanetUIController : MonoBehaviour
{
    public string planetTag = "Planet";

    public void DeleteLastPlanet()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag(planetTag);

        if (planets.Length == 0)
        {
            return;
        }

        GameObject lastPlanet = planets[planets.Length - 1];
        Destroy(lastPlanet);
    }

    public void DeleteAllPlanets()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag(planetTag);

        foreach (GameObject planet in planets)
            Destroy(planet);

    }
}
