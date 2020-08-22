using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public bool playerAbleToPick = false;
    public GameObject door;
    public Animator animator;

    public Text doorMessages;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        removeMessage();
    }

    void displayMessage(string message)
    {
        this.doorMessages.text = message;
    }

    void removeMessage()
    {
        this.doorMessages.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            List<string> inventory = other.GetComponent<Player>().inventory;
            if (inventory.IndexOf("LockPick") == -1)
            {
                displayMessage("You need to find a lock pick");
            }
            else
            {
                playerAbleToPick = true;
                displayMessage("Press 1 to pick the lock");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.removeMessage();
        }
    }

    private void Update()
    {
        if (playerAbleToPick && Input.GetKeyDown("1"))
        {
            Debug.Log("Move to the picking scene");
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        this.animator.SetTrigger("Open");
        Destroy(this.doorMessages.gameObject);
        Destroy(this.gameObject);
    }
}
