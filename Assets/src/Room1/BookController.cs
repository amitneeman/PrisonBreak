using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public Light hintLight;
    public GameObject Player;
    public GameObject Book;
    public Text hintMessage;
    bool isPlayerAbleToUse;
    public Animator ShelfAnimator;
    public Animator BookAnimator;

    // Start is called before the first frame update
    void Start()
    {
        hintLight.enabled = false;
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
            string message = "Press 1 to touch the book.";
            this.displayMessage(message);
            this.hintLight.enabled = true;
            this.isPlayerAbleToUse = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.isPlayerAbleToUse = false;
            this.hintLight.enabled = false;
            this.removeMessage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isPlayerAbleToUse && Input.GetKeyDown("1"))
        {
            Destroy(this.hintLight.gameObject);
            Destroy(this.hintMessage.gameObject);
            ScoreScript.scoreValue += 30;
            MoveBook();
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(1);
        ShelfAnimator.SetTrigger("Open");
        Destroy(this.gameObject);
    }

    void MoveBook()
    {
        BookAnimator.SetTrigger("Move");
    }
}
