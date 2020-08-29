using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenDoors());
    }

    IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(1);
        this.animator.SetTrigger("Open");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
