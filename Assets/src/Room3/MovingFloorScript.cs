using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorScript : MonoBehaviour
{

    private bool inProccess = false;

    public Material redFloor;

    public Material grayFloor;
    // Start is called before the first frame update
    void Start()
    {
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && !inProccess)
        {
            this.inProccess = true;
            this.startProccess();
        }
    }

    void startProccess()
    {
        StartCoroutine(removeFloor());
    }

    IEnumerator removeFloor()
    {
        GetComponent<Renderer>().material = redFloor;
        yield return new WaitForSeconds(3);
        this.setExistence(false);
        StartCoroutine(returnFloor());
    }

    IEnumerator returnFloor()
    {
        GetComponent<Renderer>().material = grayFloor;
        yield return new WaitForSeconds(0.8f);
        this.inProccess = false;
        this.setExistence(true);
    }

    void setExistence(bool status)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = status;
        this.gameObject.GetComponent<MeshCollider>().enabled = status;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
