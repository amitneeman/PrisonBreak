using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

     void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right,out hit, 100)) {
            if (hit.collider.gameObject.tag == "Player") {
                Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                rb.MovePosition(new Vector3((float)-7.7, (float)5.61, (float)-18.1));
            }
            
        }

    }
}
