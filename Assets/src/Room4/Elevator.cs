using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Animator DoorsAnimator;
    // Start is called before the first frame update
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.DoorsAnimator.SetTrigger("Closed");
            StartCoroutine(moveScene());
        }
    }

    IEnumerator moveScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
