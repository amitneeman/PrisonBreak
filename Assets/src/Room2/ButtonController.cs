using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject Canon;
    private bool isNear = false;
    public Light spotLight;
    public Text hintMessage;

    // Start is called before the first frame update
    void Start()
    {
        Canon.SetActive(false);
        spotLight.enabled = false;
        removeMessage();

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
            displayMessage("DO NOT PRESS 1");
            spotLight.enabled = true;
            isNear = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            removeMessage();
            spotLight.enabled = false;
            this.isNear = false;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown("1"))
        {
            this.Canon.SetActive(true);
            Destroy(this.spotLight.gameObject);
            Destroy(this.hintMessage);
            Destroy(this.gameObject);
        }
    }
}
