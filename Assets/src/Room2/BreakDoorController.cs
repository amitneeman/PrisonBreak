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
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.brokenDoor.SetActive(true);
            StartCoroutine(DestroyLeftOvers());
        }
    }

    IEnumerator DestroyLeftOvers()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.brokenDoor.gameObject);
        Destroy(this.gameObject);
    }
}
