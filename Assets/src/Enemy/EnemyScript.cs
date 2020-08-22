using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;

    public Vector3 checkpoint = new Vector3((float)-10.6, (float)4.17, (float)-15.4);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Debug.DrawRay(pos, Vector3.forward * 5, Color.red);
        if (Physics.Raycast(pos, Vector3.forward, out hit, 5) && hit.collider.gameObject.tag == "Player")
        {
            //StartCoroutine("TeleportCharacter");
            Rigidbody rb = player.gameObject.GetComponent<Rigidbody>();
            rb.MovePosition(checkpoint);

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

