using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MoveCubes : MonoBehaviour
{
    GameObject headset;
    GameObject upCube;
    GameObject rightCube;
    GameObject leftCube;
    GameObject downCube;
    GameObject toggleButton;
    GameObject[] selectors;
    bool disabled;
    bool calibrated;
    bool pinching;
    bool screenChanged;
    bool selectorsOff;
    Vector3 handPosition;
    Vector3 firstCube;
    Vector3 secondCube;
    Vector3 thirdCube;
    Vector3 fourthCube;
    int calibrateCount;
    int pinchCount;
    public int previousBox;

    
    // Start is called before the first frame update
    void Start()
    {
       headset = GameObject.Find("/OVRCameraRig/TrackingSpace/CenterEyeAnchor");   
       calibrateCount = 0;
       pinchCount = 0;
       pinching = false;
       upCube = GameObject.Find("" + this.name +"/Up");
       rightCube = GameObject.Find("" + this.name +"/Right");
       leftCube = GameObject.Find("" + this.name +"/Left");
       downCube = GameObject.Find("" + this.name +"/Down");
       toggleButton = GameObject.Find("On-body Gestures button");
       selectors = GameObject.FindGameObjectsWithTag("Selector").OrderBy(go => go.name).ToArray();
       screenChanged = false;
       selectorsOff = GameObject.Find("ToggleGestures").GetComponent<toggleGestures>().disabled;
        previousBox = 0;
        Debug.Log("Previous box: " + previousBox);
        Debug.Log("Selector length: "+ selectors.Length);
        for(int i=0; i<selectors.Length; i++){
            Debug.Log(selectors[i].name);
        }

    }

    // Update is called once per frame
    void Update()
    {
            
            for (int i = 0; i < selectors.Length; i++){
                if(selectors[i] != selectors[previousBox]){
            selectors[i].GetComponent<MeshRenderer>().enabled = false;
            
                }
            }
            pinching = GameObject.Find("/PinchChecker").GetComponent<PinchCheck>().pinching;
            calibrated = GameObject.Find(this.name).GetComponent<Calibrate>().calibrated;
            selectorsOff = false;
    
            if(calibrated == true && calibrateCount == 0 && this.name != "CubeFingerMover"){
                Debug.Log("Inside cubemover");
                firstCube = GameObject.Find(this.name).GetComponent<Calibrate>().firstCube;
                secondCube = GameObject.Find(this.name).GetComponent<Calibrate>().secondCube;
                thirdCube = GameObject.Find(this.name).GetComponent<Calibrate>().thirdCube;
                fourthCube = GameObject.Find(this.name).GetComponent<Calibrate>().fourthCube;
                upCube.transform.position = firstCube;
                rightCube.transform.position = secondCube;
                leftCube.transform.position = thirdCube;
                downCube.transform.position = fourthCube;
                calibrateCount++;
            
            }else if(calibrated == true && calibrateCount == 0 && this.name == "CubeFingerMover"){
                firstCube = GameObject.Find(this.name).GetComponent<Calibrate>().firstCube;
                upCube.transform.position = firstCube;
                calibrateCount = 4;
            }

            if(calibrateCount > 0){
                if(screenChanged == true){
                    selectors = GameObject.FindGameObjectsWithTag("Selector").OrderBy(go => go.name).ToArray();    
                    previousBox = 0;
                    selectors[0].GetComponent<MeshRenderer>().enabled = true;
                    screenChanged = false;
            
                } else if (disabled == true && selectorsOff == false){
                    for(int i = 0; i>selectors.Length; i++){
                        selectors[i].GetComponent<MeshRenderer>().enabled = false;
                }
                selectorsOff = true;
            }

                if(pinching == false && pinchCount > 0){
                    pinchCount = 0;
                }else if(pinching == true && pinchCount == 0){
                    Debug.Log(selectors[previousBox].transform.parent.name);    
                    selectors[previousBox].transform.parent.GetComponent<Button>().onClick.Invoke();
                    screenChanged = GameObject.Find("atm").GetComponent<ScreenManager>().screenChanged;
                    pinchCount++;

            }
        }
    }

    public void Up(){
       Debug.Log("Up");
       if(previousBox > 0 && previousBox-2 >= 0){   
            Debug.Log("Big");
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
            previousBox = previousBox-2;
            Debug.Log("Up previous box is: "+ previousBox);
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;

            
       }
    }
    
    public void Down(){
        if(previousBox >= 0 && previousBox + 2 < selectors.Length) {
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
            previousBox = previousBox+2;
            Debug.Log("Down previous box is: "+ previousBox);
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
     }
    }
    public void Right(){
       /* if(previousBox % 2 == 0) {
            Debug.Log("This is the right input and failed because previousBox is: " + previousBox);
            if((previousBox+(selectors.Length/2)) < selectors.Length){   
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
                previousBox = (previousBox-2) + ((selectors.Length)/2);
                Debug.Log("Right previous box is: "+ previousBox);
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            } else {
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
                previousBox++;
                Debug.Log("Right previous box is: "+ previousBox);
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            }

        }
            Debug.Log("This is the right input and failed because previousBox is: " + previousBox);*/

            if(previousBox % 2 == 0) {
            Debug.Log("This is the right input and failed because previousBox is: " + previousBox);
            if((previousBox + 1) % 2 == 1 && (previousBox + 1) < selectors.Length){   
            selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
                previousBox++;
                Debug.Log("Right previous box is: "+ previousBox);
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            } 

        }
            Debug.Log("This is the right input and failed because previousBox is: " + previousBox);
    }

    public void Left(){
        /*if(previousBox % 2 == 1){

            Debug.Log("Modulo previous box is: " + previousBox);

            if( ((previousBox + 2) -(selectors.Length/2)) >= 0){
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
                previousBox = (previousBox+2) - (selectors.Length)/2;
                Debug.Log("LEft previous box is: " + previousBox);
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            }else if((previousBox - (selectors.Length/2)) >= 0){
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
                previousBox = (previousBox) - (selectors.Length)/2;
                Debug.Log("Left previous box is: "+ previousBox);
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
                
            }
               Debug.Log(previousBox-(selectors.Length/2));
                Debug.Log("This is the left input and failed because previousBox is: " + previousBox);
        }*/
        if(previousBox % 2 == 1){

            Debug.Log("Modulo previous box is: " + previousBox);

            if(previousBox - 1 >= 0 && (previousBox - 1) % 2 == 0){
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = false;
                previousBox = previousBox-1;
                Debug.Log("LEft previous box is: " + previousBox);
                selectors[previousBox].GetComponent<MeshRenderer>().enabled = true;
            }
               Debug.Log(previousBox-(selectors.Length/2));
                Debug.Log("This is the left input and failed because previousBox is: " + previousBox);
        }
        
        Debug.Log(previousBox);

    }


    public void Confirm(){
        Debug.Log(selectors[previousBox].transform.parent.name);
        for (int i = 0; i < selectors.Length; i++){
            selectors[i].GetComponent<MeshRenderer>().enabled = false;
        }
        selectors[previousBox].transform.parent.GetComponent<Button>().onClick.Invoke();
        screenChanged = GameObject.Find("atm").GetComponent<ScreenManager>().screenChanged;
    }
  
}
