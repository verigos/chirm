using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public bool screenChanged;
    public GameObject screens;

// Start is called before the first frame update
    void Start()
    {
        screenChanged = false;
    }

    void OnTriggerStay(Collider other){
        screens.SetActive(true);

    }

    void OnTriggerExit(Collider other){
        screens.SetActive(false);

    }

    public void RemoveScreen(GameObject pastScreen){
        pastScreen.SetActive(false);
    }

    public void ChangeScreen(GameObject newScreen){
        newScreen.SetActive(true);
        screenChanged = true;
    }
}
