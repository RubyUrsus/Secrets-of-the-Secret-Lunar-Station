using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle02 : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            doorAnimator.SetBool("Triggered", true);
        }
    }
}
