using UnityEngine;

public class PlanetSelectionManager : MonoBehaviour
{
    public GlobalPlanetSlider globalSlider;
    public string planetTag = "Planet"; // todos los planetas deben tener este tag

    public void SelectPlanetByName(string name)
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag(planetTag);

        foreach (GameObject planet in planets)
        {
            PlanetInfo info = planet.GetComponent<PlanetInfo>();
            if (info != null && info.planetName == name)
            {
                PlanetController pc = planet.GetComponent<PlanetController>();
                if (pc != null)
                {
                    globalSlider.SetSelectedPlanet(pc);
                    Debug.Log("[PlanetSelectionManager] Planeta seleccionado: " + name);
                    return;
                }
            }
        }

        Debug.LogWarning("[PlanetSelectionManager] No se encontró planeta con nombre: " + name);
    }
}
