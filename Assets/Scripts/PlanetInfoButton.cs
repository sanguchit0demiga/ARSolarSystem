using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoButton : MonoBehaviour
{
    public GameObject infoPanel;
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI descriptionText;
    public Image planetUIImage;
    public void ShowInfo()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        if (planets.Length == 0)
        {
           
            return;
        }

        GameObject lastPlanet = planets[planets.Length - 1];

        PlanetInfo info = lastPlanet.GetComponent<PlanetInfo>();

        if (info == null)
        {
            return;
        }

        infoPanel.SetActive(true);
        nameText.text = info.planetName;
        descriptionText.text = info.description;
        planetUIImage.sprite = info.planetImage;
    }
}
