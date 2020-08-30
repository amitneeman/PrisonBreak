using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoint;
    public float speed = 5;
    int currentWayPoint;
    Vector3 target, moveDirection;
    void Update()
    {
        target = waypoint[currentWayPoint].position;
        moveDirection = target - transform.position;
        if (moveDirection.magnitude < 1)
        {
            currentWayPoint =
            ++currentWayPoint % waypoint.Length;
        }

        GetComponent<Rigidbody>().velocity =
        moveDirection.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.MovePosition(new Vector3((float)-7.7,(float)5.61,(float)-18.1));
        }
    }
    
}
