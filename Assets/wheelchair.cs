using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelchair : MonoBehaviour
{
   
Vector3 followPoint;
Quaternion rotatePoint;
public GameObject menu;


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        followPoint = GameObject.Find("CenterEyeAnchor").transform.position;
        rotatePoint = GameObject.Find("CenterEyeAnchor").transform.localRotation;
        this.transform.position = new Vector3(followPoint.x, -0.02f, followPoint.z);
        if(menu.activeSelf == false){
        this.transform.localRotation= new Quaternion(0, rotatePoint.y, 0, rotatePoint.w);
        }
    }
}
