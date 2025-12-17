using UnityEngine;
using TMPro;

public class MenuDesplegableSimple : MonoBehaviour
{
    public GameObject contenido;        
    public GameObject panelControles;   
    public TMP_Text botonTexto;

    private bool open = false;

    public void ToggleMenu()
    {
        open = !open;

        contenido.SetActive(open);
        panelControles.SetActive(!open);

        botonTexto.text = open ? "CLOSE" : "OPEN";
    }
}
