using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTracker : MonoBehaviour
{
     void Update()
    {
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
    }
}
