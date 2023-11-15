using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using Oculus.Interaction;
using TMPro;

public class PressOnBody : MonoBehaviour
{
    GameObject[] selectors;
    GameObject confirmedButton;

    int previousBox;
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
       this.GetComponent<Button>().onClick.Invoke();
       /*
       switch (directionSelect){

       case direction.Up:
       Debug.Log("Up");
       if(previousBox > 0 && (selectors.Length)/2){   
       Debug.Log("Big");
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("Disabled");
            previousBox = previousBox-1;
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("Enabled");
            //Debug.Log("Previous box: " + previousBox);
            
             
            //break;
         //} 
            break;
           
        case direction.Down:
        Debug.Log(previousBox);
            if(previousBox != ((selectors.Length/2)-1) && previousBox != selectors.Length-1) {
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
            previousBox = previousBox+1;
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            
            break;
            } else {
            break;
            }
/*
        case direction.Left:
           if(previousBox % 2 == 0 && previousBox != 0) {
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
            Debug.Log(previousBox);
            selectors[previousBox-(selectors.Length/2)].GetComponent<MeshRenderer>().enabled = true;
            previousBox = previousBox - (selectors.Length/2);
            Debug.Log(previousBox);
            break;
            }
            Debug.Log(previousBox);
            break; 

        case direction.Right:
            if(previousBox % 2 == 1 && previousBox == 0) {
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
            selectors[previousBox+(selectors.Length/2)].GetComponent<MeshRenderer>().enabled = true;
            previousBox = previousBox + (selectors.Length/2);
            break;
            } 
            break;
/*
        case direction.Confirm:
            confirmedButton = buttons[previousBox].gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
            Debug.Log(confirmedButton);
            break;*/
       //}
       
       
       //this.gameObject.GetComponent<Button>().onClick.Invoke();
       
    }

    
    //public void MoveSelectedButton(){

 //   }
}