using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject boat;
    public Camera boatCamera;
    public bool isAbleToMount = false;

    public Text message;
    // Start is called before the first frame update
    void Start()
    {
        boatCamera.enabled = false;
        boat.GetComponent<BoatScript>().enabled = false;
        removeMessage();
    }

    void displayMessage(string message)
    {
        this.message.text = message;
    }

    void removeMessage()
    {
        this.message.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            displayMessage("Press 1 to mount the boat and escape!");
            this.isAbleToMount = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.removeMessage();
            this.isAbleToMount = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isAbleToMount && Input.GetKeyDown("1"))
        {
            player.SetActive(false);
            boatCamera.enabled = true;
            boat.GetComponent<BoatScript>().enabled = true;
            Destroy(this.message.gameObject);
            Destroy(this.gameObject);
        }
    }
}
