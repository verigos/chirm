using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class toggleGestures : MonoBehaviour
{
    public GameObject type;
    public GameObject otherGesture;
    public GameObject otherCubes;
    public bool disabled;
    GameObject[] selectors;
    public GameObject[] newTouchPoints;
    public GameObject[] oldTouchPoints;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    void Update() {
        /*if(otherGesture.GetComponent<MeshRenderer>().material.color == Color.green && disabled == false){
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            disabled = true;
        } else if(disabled == true){
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            type.SetActive(false);
        } else if(disabled == false){
            this.GetComponent<MeshRenderer>().material.color = Color.green;
            type.SetActive(true);

        }*/

        if(type.activeSelf == true){
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }else{
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }


        // Update is called once per frame
    void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hello it is working");
            if(type.activeSelf == false){
                Debug.Log("Setting active");
                type.SetActive(true);
                selectors = GameObject.FindGameObjectsWithTag("Selector").OrderBy(go => go.name).ToArray(); 
                selectors[0].GetComponent<MeshRenderer>().enabled = true;
                type.GetComponent<MoveCubes>().previousBox = 0;
                disabled = false;
                type.GetComponent<Calibrate>().count = 0;
            }else if(type.activeSelf == true){
                Debug.Log("Setting false");
                disabled = true;
                type.SetActive(false);
                selectors = GameObject.FindGameObjectsWithTag("Selector").OrderBy(go => go.name).ToArray();    
                for(int i = 0; i < selectors.Length; i++){
                    selectors[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }

        }

        void OnTriggerExit(Collider other){
            if(type.activeSelf == true){
                if(type.name == "CubeMover" && otherCubes.activeSelf == true){
                    otherCubes.SetActive(false);
                    for(int i = 0; i < oldTouchPoints.Length; i++){
                        oldTouchPoints[i].SetActive(false);
                    }
                    for(int i = 0; i < newTouchPoints.Length; i++){
                        newTouchPoints[i].SetActive(true);
                    }
                } else if(type.name == "CubeFingerMover"){
                    otherCubes.SetActive(false);
                    for(int i = 0; i < oldTouchPoints.Length; i++){
                        oldTouchPoints[i].SetActive(false);
                    }
                    for(int i = 0; i < newTouchPoints.Length; i++){
                        newTouchPoints[i].SetActive(true);
                    }
                }
            }else if (type.activeSelf == false){
                if(this.name == "ToggleFingerGestures"){
                    for(int i = 0; i < newTouchPoints.Length; i++){
                        newTouchPoints[i].SetActive(false);
                    }
                    for(int i = 0; i < oldTouchPoints.Length; i++){
                        oldTouchPoints[i].SetActive(true);
                    }
                }else{
                    for(int i = 0; i < newTouchPoints.Length; i++){
                        newTouchPoints[i].SetActive(true);
                    }
                    for(int i = 0; i < oldTouchPoints.Length; i++){
                        oldTouchPoints[i].SetActive(false);
                    }
                }
            }
        }

}

