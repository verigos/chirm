using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GestureButtonSelect : MonoBehaviour
{
    GameObject highlightedButton;
    
    public void ButtonPressed(){
        highlightedButton = EventSystem.current.currentSelectedGameObject;
        if(highlightedButton.name == this.name){
            this.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }

}
