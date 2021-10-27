using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiInteractor : MonoBehaviour
{
    public TextMeshProUGUI Muestra;
    public int Number;

    [ContextMenu ("Botón")]
    public void Metodo()
    {
        ButtonNumber(Number.ToString());
    }
    public void ButtonNumber(string Number)
    {
        Muestra.text += Number;
    }
}
