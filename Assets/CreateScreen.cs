using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScreen : MonoBehaviour
{

    public GameObject keypad;
    public bool initKeypadState;
    
    void Start()
    {
        Debug.Log("I Exist.");
        Debug.Log(gameObject.name);
    }

    void Update()
    {  /*
        if(!initKeypadState){
            keypad.SetActive(false);
            initKeypadState = true;
        }*/

    }
    /*
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision.");
        keypad.SetActive(true);
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Stop Collision.");
        keypad.SetActive(false);
    }
    */
}
