using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class toggleGestures : MonoBehaviour
{
  
    GameObject CubeMover;
    public bool disabled;
    GameObject[] selectors;

    // Start is called before the first frame update
    void Start()
    { 
        CubeMover = GameObject.Find("/CubeMover");
        disabled = true;
        
    }


        // Update is called once per frame
    void OnTriggerExit(Collider other)
        {
            Debug.Log("Hello it is working");
            if(CubeMover.activeSelf == false){
                CubeMover.SetActive(true);
                selectors = GameObject.FindGameObjectsWithTag("Selector").OrderBy(go => go.name).ToArray(); 
                selectors[0].GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("CubeMover").GetComponent<MoveCubes>().previousBox = 0;
                disabled = false; 
            }else if(CubeMover.activeSelf == true){
                disabled = true;
                CubeMover.SetActive(false);
                selectors = GameObject.FindGameObjectsWithTag("Selector").OrderBy(go => go.name).ToArray();    
                for(int i = 0; i < selectors.Length; i++){
                    selectors[i].GetComponent<MeshRenderer>().enabled = false;

                }
                
            }

        }

}

