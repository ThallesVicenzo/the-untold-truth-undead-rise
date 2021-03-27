using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synopsis : MonoBehaviour
{
    public Transform canvas;
    public Transform synopsis;
    public void Sinopsis()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        synopsis.GetComponent<CanvasGroup>().alpha = 1;
        synopsis.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void MainMenu()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        synopsis.GetComponent<CanvasGroup>().alpha = 0;
        synopsis.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
