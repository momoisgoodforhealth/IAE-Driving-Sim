using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
//Rigidbody m_Rigidbody;
    public bool touch = false;
    public GameObject menu;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name == "Vehicle") || (collision.gameObject.tag == "Player"))
        {
            Debug.Log("detected");
            touch = true;
            menu.SetActive(true);
        }
    }
    void Start()
    {
        menu.SetActive(false);
       // m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
