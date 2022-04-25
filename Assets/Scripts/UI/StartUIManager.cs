using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.onGameStart += OnGamestarted;
    }

  

    private void OnDisable()
    {
        EventManager.onGameStart -= OnGamestarted;
    }


    private void OnGamestarted()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

   
}
