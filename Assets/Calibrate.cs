using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrate : MonoBehaviour
{
    public bool calibrated;
    Vector3 rightHand;
    Vector3 leftHand;
    public Vector3 firstCube;
    public Vector3 secondCube;
    public Vector3 thirdCube;
    public Vector3 fourthCube;
    int count;

    void Start()
    {
        calibrated = false;
        count = 0;
        Debug.Log("Hi");

    }

    void Update(){
        if(calibrated == false && count <= 4){
            if (Input.GetKeyUp("1")){
                rightHand = GameObject.FindGameObjectWithTag("RightHand").transform.position;
                leftHand = GameObject.FindGameObjectWithTag("LeftHand").transform.position;
                firstCube = new Vector3((rightHand.x + leftHand.x)/2, (rightHand.y + leftHand.y)/2, (rightHand.z + leftHand.z)/2);
                            Debug.Log("1");
                count++;
            }
            if (Input.GetKeyUp("2")){
                secondCube = GameObject.FindGameObjectWithTag("RightHand").transform.position;
                            Debug.Log("2");
                count++;
            }
            if (Input.GetKeyUp("3")){
                thirdCube = GameObject.FindGameObjectWithTag("LeftHand").transform.position;
                            Debug.Log("3");
                count++;
            }
            if (Input.GetKeyUp("4")){
                rightHand = GameObject.FindGameObjectWithTag("RightHand").transform.position;
                leftHand = GameObject.FindGameObjectWithTag("LeftHand").transform.position;
                            Debug.Log("4");
                fourthCube = new Vector3((rightHand.x + leftHand.x)/2, (rightHand.y + leftHand.y)/2, (rightHand.z + leftHand.z)/2);
                count++;
                calibrated = true;
            }
        
        }

        if(calibrated == true){
            if(Input.GetKeyUp("r")){
                count = 0;
                calibrated = false;
            }
        }
    }
    
}
