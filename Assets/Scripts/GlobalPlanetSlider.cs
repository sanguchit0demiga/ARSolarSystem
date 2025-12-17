using UnityEngine;
using UnityEngine.UI;

public class GlobalPlanetSlider : MonoBehaviour
{
    public Slider rotationSlider;
    public Slider scaleSlider;

    private PlanetController selectedPlanet;

    void Start()
    {
        rotationSlider.onValueChanged.AddListener(ChangeRotation);
        scaleSlider.onValueChanged.AddListener(ChangeScale);
        Debug.Log("GlobalPlanetSlider inicializado.");
    }

    public void SetSelectedPlanet(PlanetController planet)
    {
        selectedPlanet = planet;

        if (selectedPlanet != null)
        {
            rotationSlider.value = selectedPlanet.GetRotationValue();
            scaleSlider.value = selectedPlanet.transform.localScale.x;
            Debug.Log($"Planeta seleccionado: {selectedPlanet.name}. Sliders actualizados.");
        }
        else
        {
            Debug.Log("Ningún planeta seleccionado. Sliders deshabilitados/reseteados.");
        }
    }

    void ChangeRotation(float value)
    {
        if (selectedPlanet != null)
        {
            selectedPlanet.SetRotation(value);
            Debug.Log($"Rotación aplicada a {selectedPlanet.name}: {value}");
        }
    }

    void ChangeScale(float value)
    {
        if (selectedPlanet != null)
        {
            selectedPlanet.SetScale(value);
            Debug.Log($"Escala aplicada a {selectedPlanet.name}: {value}");
        }
    }
}
