using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrate : MonoBehaviour
{
    public bool calibrated;
    public GameObject fingerMover;
    Vector3 rightHand;
    Vector3 leftHand;
    Vector3 rightFinger;
    public Vector3 firstCube;
    public Vector3 secondCube;
    public Vector3 thirdCube;
    public Vector3 fourthCube;
    public int count;

    void Start()
    {
        calibrated = false;
        count = 0;
        Debug.Log("Hi");

    }

    void Update(){
        if(count == 0){
            calibrated = false;
        }
        
        if(calibrated == false && count <= 4 && fingerMover.activeSelf == false){
            if (Input.GetKeyUp("1")){
                rightHand = GameObject.Find("CubeInteractorRight").transform.position;
                leftHand = GameObject.Find("CubeInteractorLeft").transform.position;
                firstCube = new Vector3((rightHand.x + leftHand.x)/2, (rightHand.y + leftHand.y)/2, (rightHand.z + leftHand.z)/2);
                            Debug.Log("1");
                count++;
            }
            if (Input.GetKeyUp("2")){
                secondCube = GameObject.Find("CubeInteractorLeft").transform.position;
                            Debug.Log("2");
                count++;
            }
            if (Input.GetKeyUp("3")){
                thirdCube = GameObject.Find("CubeInteractorRight").transform.position;
                            Debug.Log("3");
                count++;
            }
            if (Input.GetKeyUp("4")){
                rightHand = GameObject.Find("CubeInteractorRight").transform.position;
                leftHand = GameObject.Find("CubeInteractorLeft").transform.position;
                            Debug.Log("4");
                fourthCube = new Vector3((rightHand.x + leftHand.x)/2, (rightHand.y + leftHand.y)/2, (rightHand.z + leftHand.z)/2);
                count++;
                calibrated = true;
            }
        
        }else if (calibrated == false && count <= 0){
            if (Input.GetKeyUp("1")){
                rightFinger = GameObject.Find("PointInteractorRight").transform.position;
                firstCube = rightFinger;
                            Debug.Log("1");
                count = 4;
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
