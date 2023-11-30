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
    void OnTriggerExit(Collider other)
    {
       this.GetComponent<Button>().onClick.Invoke();
       Debug.Log(other.name);
      
    }

}