using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnEnable() 
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;    
    }

    void Update() 
    {
        GetComponent<CanvasGroup>().alpha += Time.deltaTime * 0.5f;
    }
}
