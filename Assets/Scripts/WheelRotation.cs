using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{

   // public GameObject re;
    public WheelCollider wheelcollider;


    private Vector3 wheelpos;
    private Quaternion wheelrot;
    void Update()
    {
        wheelcollider.GetWorldPose(out wheelpos, out wheelrot);
        transform.position = wheelpos;
        transform.rotation = wheelrot;
      //  re.transform.po
    }
}
