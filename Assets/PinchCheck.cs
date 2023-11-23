﻿﻿﻿﻿﻿﻿﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PinchCheck : MonoBehaviour
{
    [SerializeField]
    private float minFingerPinchDownStrength = 0.5f;
    
    [SerializeField]
    public Transform objectToMove;

    public OVRHand ovrHand;

    public OVRBone boneToTrack;

    public OVRSkeleton ovrSkeleton;

    public bool pinching = false;

    // Start is called before the first frame update
    void Start()
    {
        
        //ovrHand = GetComponent<OVRHand>();
        //ovrSkeleton = GetComponent<OVRCustomSkeleton>();
    }

    // Update is called once per frame
    void Update()
    {
      
        CheckPinchState();
    }

    private void CheckPinchState()
    {
        Debug.Log(pinching);    

        bool isIndexFingerPinching = ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if(isIndexFingerPinching){
            pinching = true;
        }else {
            pinching = false;
        }

        
        float indexFingerPinchStrength = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

        if(ovrHand.GetFingerConfidence(OVRHand.HandFinger.Index) != OVRHand.TrackingConfidence.High)
            return;

        // finger pinch down
        if (isIndexFingerPinching && indexFingerPinchStrength >= minFingerPinchDownStrength)
        {
            return;
        }
        //Debug.Log(pinching);
    }
}