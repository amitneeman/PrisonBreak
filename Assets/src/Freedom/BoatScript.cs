using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{ //Boat
    public float turnSpeed = 100f;
    public float accellerateSpeed = 100f;
    private Rigidbody rg;
    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * Time.deltaTime;
        rg.AddTorque(0f, h * turnSpeed, 0f);
        rg.AddForce(transform.right * v * accellerateSpeed);
    }
}