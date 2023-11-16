using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleGestures : MonoBehaviour
{
  
    GameObject CubeMover;    

    // Start is called before the first frame update
    void Start()
    { 
        CubeMover = GameObject.Find("/CubeMover");
        
    }


        // Update is called once per frame
    void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hello it is working");
            if(CubeMover.activeSelf == false){
                CubeMover.SetActive(true);
            }else if(CubeMover.activeSelf == true){
                CubeMover.SetActive(false);
            }

        }

}

