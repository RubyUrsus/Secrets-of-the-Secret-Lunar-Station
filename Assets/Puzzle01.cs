using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle01 : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DoorTrigger")
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
        yield return new WaitForSeconds(1.5f);
        doorAnimator.SetBool("Triggered", false);
    }
}
