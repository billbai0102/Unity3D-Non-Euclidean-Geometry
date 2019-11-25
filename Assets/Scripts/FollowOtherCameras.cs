using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOtherCameras : MonoBehaviour
{
    public Transform playerCam;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
        Vector3 offsetFromPortal = playerCam.position - otherPortal.position;
        GetComponent<Camera>().transform.position = portal.position + offsetFromPortal;
    
        float angularDifferenceBtwnPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBtwnPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCam.forward;

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
