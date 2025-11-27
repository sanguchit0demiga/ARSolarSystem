using UnityEngine;
using TMPro;

public class MenuDesplegableSimple : MonoBehaviour
{
    public GameObject contenido;
    public TMP_Text botonTexto;

    private bool open = false;

    public void ToggleMenu()
    {
        open = !open;
        contenido.SetActive(open);

        if (open)
            botonTexto.text = "CLOSE ";
        else
            botonTexto.text = "OPEN ";
    }
}
