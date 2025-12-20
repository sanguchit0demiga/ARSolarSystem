using UnityEngine;
using TMPro;

public class MenuDesplegableSimple : MonoBehaviour
{
    [Header("Asigna los paneles aquí")]
    public GameObject contenido;
    public GameObject panelSliders;

    public TMP_Text botonTexto;

    private bool open = false;

    public void ToggleMenu()
    {
        open = !open;


        if (contenido != null)
            contenido.SetActive(open);


        if (panelSliders != null)
            panelSliders.SetActive(!open);


        if (botonTexto != null)
        {
            if (open)
                botonTexto.text = "CLOSE";
            else
                botonTexto.text = "OPEN";
        }
    }
}