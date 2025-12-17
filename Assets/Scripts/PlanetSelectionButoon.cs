using UnityEngine;
using UnityEngine.UI;

public class PlanetSelectionButton : MonoBehaviour
{
    public GameObject planet; // Planeta spawneado o prefab
    public GlobalPlanetSlider globalSlider;

    public void OnButtonPressed()
    {
        if (planet == null)
        {
            Debug.LogError("[PlanetSelectionButton] No hay planeta asignado al botón!");
            return;
        }

        if (globalSlider == null)
        {
            Debug.LogError("[PlanetSelectionButton] No hay GlobalPlanetSlider asignado!");
            return;
        }

        PlanetController pc = planet.GetComponent<PlanetController>();
        if (pc == null)
        {
            Debug.LogError("[PlanetSelectionButton] El planeta no tiene PlanetController!");
            return;
        }

        globalSlider.SetSelectedPlanet(pc);
        Debug.Log("[PlanetSelectionButton] Planeta seleccionado por botón: " + planet.name);
    }
}
