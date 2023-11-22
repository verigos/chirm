using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MoveCubes : MonoBehaviour
{
    GameObject headset;
    GameObject cube;
    GameObject upCube;
    GameObject rightCube;
    GameObject leftCube;
    GameObject downCube;
    bool disabled;
    bool calibrated;
    GameObject toggleButton;
    Vector3 handPosition;
    GameObject[] selectors;
    public int previousBox;
    bool screenChanged;
    bool selectorsOff;
    Vector3 firstCube;
    Vector3 secondCube;
    Vector3 thirdCube;
    Vector3 fourthCube;
    int count;

    
    // Start is called before the first frame update
    void Start()
    {
       headset = GameObject.Find("/OVRCameraRig/TrackingSpace/CenterEyeAnchor");   
       cube = GameObject.Find("Cube");
       count = 0;
       upCube = GameObject.Find("/CubeMover/Up");
       rightCube = GameObject.Find("/CubeMover/Right");
       leftCube = GameObject.Find("/CubeMover/Left");
       downCube = GameObject.Find("/CubeMover/Down");
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
            
            calibrated = GameObject.Find("/CubeMover").GetComponent<Calibrate>().calibrated;
            selectorsOff = false;
    
            if(calibrated == true && count == 0){
                Debug.Log("Inside cubemover");
                firstCube = GameObject.Find("CubeMover").GetComponent<Calibrate>().firstCube;
                secondCube = GameObject.Find("CubeMover").GetComponent<Calibrate>().secondCube;
                thirdCube = GameObject.Find("CubeMover").GetComponent<Calibrate>().thirdCube;
                fourthCube = GameObject.Find("CubeMover").GetComponent<Calibrate>().fourthCube;
                upCube.transform.position = firstCube;
                rightCube.transform.position = secondCube;
                leftCube.transform.position = thirdCube;
                downCube.transform.position = fourthCube;
                count++;
            
            }
            
            /*if(cube.GetComponent<GestureRecognizer>().gesture == true){
                handPosition = cube.GetComponent<GestureRecognizer>().hand;
                upCube.transform.position = new Vector3 (headset.transform.position.x, (headset.transform.position.y/2), (headset.transform.position.z + handPosition.z +0.2f)); 
            }else{
                this.transform.position = new Vector3 (headset.transform.position.x, (headset.transform.position.y/2), (headset.transform.position.z + 0.6f));
            }*/

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
        //For whatever reason this is backwards but I'm not going to argue with it
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
        //For whatever reason this is backwards but I'm not going to argue with it
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
    selectors[previousBox].transform.parent.GetComponent<Button>().onClick.Invoke();
        screenChanged = GameObject.Find("atm").GetComponent<ScreenManager>().screenChanged;

    }
  
}
