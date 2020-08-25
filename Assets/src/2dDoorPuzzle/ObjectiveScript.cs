using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectiveScript : MonoBehaviour
{
    public GameObject player;
    public GameObject openLock;
    public GameObject closedLock;
    private int points = 0;
    private int maxPoints = 5;
    private bool isInReach = false;
    public Vector2[] positions;

    public Text pointsText;

    void Start()
    {
        this.transform.position = positions[points];
        this.closedLock.SetActive(true);
        this.openLock.SetActive(false);
        this.pointsText.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInReach && Input.GetKeyDown("1"))
        {
            points++;
            this.pointsText.text = points.ToString();
            MoveToNextPoint(points);
            if (points == maxPoints)
            {
                EndMiniGame();
            }
        }
    }

    void EndMiniGame()
    {
        this.player.SetActive(false);
        this.openLock.SetActive(true);
        this.closedLock.SetActive(false);
        this.pointsText.text = "";
        StartCoroutine("MoveBack");
    }

    public IEnumerator MoveBack()
    {
        CrossSceneData.flags.Add("picked",true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        isInReach = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isInReach = false;
    }

    void MoveToNextPoint(int index)
    {
        int arrayIndex = index % positions.Length;
        this.transform.position = positions[arrayIndex];
    }
}
