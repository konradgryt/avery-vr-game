using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    private void Update()
    {
        Vector3 vrInput = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Quaternion vrRot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch); 
        transform.localRotation = vrRot;
        transform.localPosition = vrInput.normalized * 4f;
    }

}
