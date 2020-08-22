using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public BoatScript boat;

    public Text endMessage;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        this.endMessage.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boat")
        {
            boat.enabled = false;
            this.endMessage.enabled = true;
        }
    }
}
