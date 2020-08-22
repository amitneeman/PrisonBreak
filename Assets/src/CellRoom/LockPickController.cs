using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPickController : MonoBehaviour
{
    public Light hintLight;
    public GameObject Player;
    public GameObject Key;
    public Text hintMessage;
    bool isPlayerAbleToPickUp;

    void Start()
    {
        hintLight.enabled = false;
        this.removeMessage();
    }

    void displayMessage(string message)
    {
        this.hintMessage.text = message;
    }

    void removeMessage()
    {
        this.hintMessage.text = "";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.displayMessage("Press 1 to pick up.");
            this.hintLight.enabled = true;
            this.isPlayerAbleToPickUp = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.isPlayerAbleToPickUp = false;
            this.hintLight.enabled = false;
            this.removeMessage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isPlayerAbleToPickUp && Input.GetKeyDown("1"))
        {
            this.Player.GetComponent<Player>().inventory.Add("LockPick");
            Destroy(this.hintLight.gameObject);
            Destroy(this.hintMessage.gameObject);
            Destroy(this.Key.gameObject);
            Destroy(this.gameObject);
        }
    }
}
