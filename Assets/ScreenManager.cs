using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public bool screenChanged;    

// Start is called before the first frame update
    void Start()
    {
        screenChanged = false;
    }


    public void RemoveScreen(GameObject pastScreen){
        pastScreen.SetActive(false);
    }

    public void ChangeScreen(GameObject newScreen){
        newScreen.SetActive(true);
        screenChanged = true;
    }
}
