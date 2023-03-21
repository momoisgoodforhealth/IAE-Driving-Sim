using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_vehi_move : MonoBehaviour
{
    public GameObject user;

    Rigidbody m_Rigidbody;
    public Vector3 centerofmass;
    // public Transform[] target;
    public List<GameObject> waypoints;
    // public GameObject[] way;
    //   public List<GameObject> waypointss;
    int index = 0;
    // Adjust the speed for the application.
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public float maxSteerAngle = 25f;
    Vector3 destination = Vector3.zero;

    public float maxMotorTorque = 80f;
    public float currentSpeed;
    public float maxSpeed = 100f;

    public bool start = true;
    //  public bool turn = false;
    // The target (cylinder) position.
    //   private Transform target;
    // Start is called before the first frame update
    private float dist;
    void Start()
    {
        //   way = GetComponentsInChildren<GameObject>();
        //   Debug.Log("Parent="+way);
        //   foreach (GameObject comp in way) Debug.Log("Child="+comp.name);//waypointss.Add(comp);

        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.centerOfMass = centerofmass;
        m_Rigidbody.velocity = new Vector3(0, 0, 10);
        //Set the speed of the GameObject
        //  m_Speed = 10.0f;
    }

    private void FixedUpdate()
    {
        //    ApplySteer();
        //    Drive();
    }
    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(user.transform.position, transform.position);
        if (dist <= 200f) start = true;

        destination = waypoints[index].transform.position;
        //  Vector3 newPos = Vector3.MoveTowards(transform.position, destination, m_Speed * Time.deltaTime);
        //  transform.position = newPos;
        // transform.LookAt(destination);
        float distance = Vector3.Distance(transform.position, destination);
        if (distance < 10)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
                transform.LookAt(destination);
            }
        }
        Vector3 targetDir = destination - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        Debug.Log("Angle=" + angle);
        Debug.Log("Torque=" + wheelFL.motorTorque);
        Debug.Log("Speed=" + currentSpeed);
        Debug.Log("Brake=" + wheelFL.brakeTorque);
        //   if (angle>1f) maxMotorTorque = 10f;
        //  else maxMotorTorque = 80f;

        if ((angle > 5f) && (currentSpeed > 10f))
        {
            wheelFL.brakeTorque = 300f;
            wheelFR.brakeTorque = 300f;
        }
        else
        {
            wheelFL.brakeTorque = 0f;
            wheelFR.brakeTorque = 0f;
        }

        if (start)
        {
            m_Rigidbody.AddForce(transform.forward * 100f);
            ApplySteer();
            Drive();
        }
        var AntiRoll = 5000.0;
          //  var hit : WheelHit;
    var travelL = 1.0;
    var travelR = 1.0;
 
    var groundedL = wheelFL.GetGroundHit(out WheelHit FL_HIT);
    if (groundedL)
        travelL = (-wheelFL.transform.InverseTransformPoint(FL_HIT.point).y - wheelFL.radius) / wheelFL.suspensionDistance;
 
    var groundedR = wheelFR.GetGroundHit(out WheelHit FR_HIT);
    if (groundedR)
        travelR = (-wheelFR.transform.InverseTransformPoint(FR_HIT.point).y - wheelFR.radius) / wheelFR.suspensionDistance;
 
    var antiRollForce = (travelL - travelR) * AntiRoll;
 
    if (groundedL)
        m_Rigidbody.AddForceAtPosition(wheelFL.transform.up * -(float)antiRollForce,  //antiRollForce
               wheelFL.transform.position);  
    if (groundedR)
        m_Rigidbody.AddForceAtPosition(wheelFR.transform.up *(float) antiRollForce,
               wheelFR.transform.position);  
        //   if (transform.position != target[current].position)
        // {
        //      Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, m_Speed * Time.deltaTime);
        //      GetComponent<Rigidbody>().MovePosition(pos);
        //  }
        //  else current = current + 1;

        //     m_Rigidbody.velocity = transform.forward * m_Speed;
    }

    public void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(destination);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }
    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;
        if (currentSpeed < maxSpeed)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFL.motorTorque = maxMotorTorque;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }

    }
}
