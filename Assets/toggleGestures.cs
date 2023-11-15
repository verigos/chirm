using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleGestures : MonoBehaviour
{
  
    GameObject headset;    
    GameObject upCube;
    public bool disabled;

    // Start is called before the first frame update
    void Start()
    {
        headset = GameObject.Find("/OVRCameraRig/TrackingSpace/CenterEyeAnchor");    
        upCube = GameObject.Find("/CubeMover/UP");
        disabled = false;
        
    }


        // Update is called once per frame
    void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Hello");
            this.gameObject.GetComponent<Button>().onClick.Invoke();
        }

      public void GestureSwitch(){
            if(disabled == true){
                upCube.transform.position = new Vector3 (headset.transform.position.x, (headset.transform.position.y - 5), (headset.transform.position.z));
            }
        }

}

