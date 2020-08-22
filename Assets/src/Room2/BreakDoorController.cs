using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDoorController : MonoBehaviour
{
    public GameObject brokenDoor;
    public GameObject canonController;
    // Start is called before the first frame update
    void Start()
    {
        brokenDoor.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Canon")
        {
            Destroy(this.gameObject);
            this.brokenDoor.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
