using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;

    public Transform[] WayPoints;

    public Vector3 checkpoint = new Vector3((float)-10.6, (float)4.17, (float)-15.4);

    private AICharacterControl control;

    private int wayPoint = 0;

    //public Transform target;

    //NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<AICharacterControl>();
        control.SetTarget(WayPoints[wayPoint]);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, forward, out hit, 10) && hit.collider.gameObject.tag == "Player")
        {
            Rigidbody rb = player.gameObject.GetComponent<Rigidbody>();
            rb.MovePosition(checkpoint);
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WayPoint")
        {
         wayPoint = (wayPoint + 1) % WayPoints.Length;
          control.SetTarget(WayPoints[wayPoint]);
        }
    }

    public IEnumerator TeleportCharacter()
    {

        player.GetComponent<FirstPersonController>().enabled = false;
        player.transform.position = checkpoint;
        yield return new WaitForEndOfFrame();
        player.GetComponent<FirstPersonController>().enabled = true;

    }

}

