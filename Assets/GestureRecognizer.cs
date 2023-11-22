using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognizer : MonoBehaviour
{
    Color color;
    public Vector3 hand;
    public bool gesture;
    // Start is called before the first frame update
    void Start()
    {
        gesture = false;
    }

    // Update is called once per frame
    void Update()
    {
        color = this.GetComponent<MeshRenderer>().material.color;
        
        if(color == Color.green)
        {
           hand = GameObject.FindGameObjectWithTag("Hand").transform.position;
           gesture = true;
        }
    }
}
