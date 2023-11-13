using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleGestures : MonoBehaviour
{
  

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] onBodyCubes = GameObject.FindGameObjectsWithTag("On-body");
        for (int i = 0; i < onBodyCubes.Length; i++)
        {
            onBodyCubes[i].SetActive(false);
        }
    }


        // Update is called once per frame
    void OnCollisionEnter(Collision collision)
        {
        GameObject[] onBodyCubes = GameObject.FindGameObjectsWithTag("On-body");
        for (int i = 0; i < onBodyCubes.Length; i++)
          {
                if (onBodyCubes[i].activeInHierarchy == false)
                {
                    onBodyCubes[i].SetActive(true);
                }
                else
                {
                    onBodyCubes[i].SetActive(false);
                }
            }
        }

}

