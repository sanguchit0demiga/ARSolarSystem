using UnityEngine;
using TMPro;

public class PlanetInfoUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public void ShowPlanetInfo(string name, string desc)
    {
        panel.SetActive(true);
        titleText.text = name;
        descriptionText.text = desc;
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
