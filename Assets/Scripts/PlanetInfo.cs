using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour
{
    public GameObject infoPanel; // Panel que se activa
    public Text infoText;        // Texto dentro del panel
    [TextArea]
    public string panelMessage;  // Mensaje que queremos mostrar

    private void Start()
    {
        // Nos aseguramos que el panel esté cerrado al iniciar
        infoPanel.SetActive(false);

        // Asignamos la función al botón
        GetComponent<Button>().onClick.AddListener(ShowInfo);
    }

    public void ShowInfo()
    {
        infoText.text = panelMessage;
        infoPanel.SetActive(true);
    }

    // Función para cerrar el panel (se puede asignar a un botón "Cerrar")
    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }
}
