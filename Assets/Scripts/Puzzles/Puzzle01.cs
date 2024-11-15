using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle01 : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;

    [SerializeField] float waitTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorAnimator.SetBool("Triggered", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(waitTime);
        doorAnimator.SetBool("Triggered", false);
    }
}
