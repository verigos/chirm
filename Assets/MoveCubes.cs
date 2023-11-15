using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    GameObject headset;
    GameObject cube;
    GameObject upCube;
    GameObject toggleButton;
    Vector3 handPosition;
    GameObject[] selectors;
    int previousBox;

    
    // Start is called before the first frame update
    void Start()
    {
       headset = GameObject.Find("/OVRCameraRig/TrackingSpace/CenterEyeAnchor");   
       cube = GameObject.Find("Cube");
       upCube = GameObject.Find("/CubeMover/Up");
       toggleButton = GameObject.Find("On-body Gestures button");
       selectors = GameObject.FindGameObjectsWithTag("Selector");
        System.Array.Reverse(selectors);
        selectors[0].GetComponent<MeshRenderer>().enabled = true;
        previousBox = 0;
        Debug.Log("Previous box: " + previousBox);
        Debug.Log("Selector length: "+ selectors.Length);

    }

    // Update is called once per frame
    void Update()
    {
        if(cube.GetComponent<GestureRecognizer>().gesture == true && toggleButton.GetComponent<toggleGestures>().disabled == false){
            handPosition = cube.GetComponent<GestureRecognizer>().hand;
            upCube.transform.position = new Vector3 (headset.transform.position.x, (headset.transform.position.y/2), (headset.transform.position.z + handPosition.z +0.2f)); 
        }else{
            this.transform.position = new Vector3 (headset.transform.position.x, (headset.transform.position.y/2), (headset.transform.position.z + 0.6f));
        }
       
        //this.transform.localEulerAngles = new Vector3(0f, headset.transform.localEulerAngles.y, 0f);
    }

    public void Up(){
        Debug.Log("Up");
       if(previousBox > 0 && previousBox != (selectors.Length)/2 && previousBox-1 >= 0){   
            Debug.Log("Big");
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;

            previousBox = previousBox-1;
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;

            
       }
    }
    public void Down(){

        if(previousBox != ((selectors.Length/2)-1) && previousBox != selectors.Length-1 && previousBox+1 < selectors.Length) {
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
            previousBox = previousBox+1;
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            
        }
    }
    public void Right(){
        //For whatever reason this is backwards but I'm not going to argue with it
        if(previousBox % 2 == 0) {
            if((previousBox+(selectors.Length/2)) < selectors.Length){   
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
                previousBox = previousBox + (selectors.Length)/2;
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
                Debug.Log(previousBox);
            }
        }
            Debug.Log(previousBox+(selectors.Length/2));
            Debug.Log("This is the right input and failed because previousBox is: " + previousBox);
    }

    public void Left(){
        //For whatever reason this is backwards but I'm not going to argue with it
        if(previousBox % 2 == 1){
            if( (previousBox-(selectors.Length/2)) >= 0){
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
                previousBox = previousBox - (selectors.Length)/2;
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            }
                
        }
        Debug.Log(previousBox-(selectors.Length/2));
     Debug.Log("This is the left input and failed because previousBox is: " + previousBox);
        

    }
}
