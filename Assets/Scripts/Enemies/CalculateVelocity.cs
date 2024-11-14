using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateVelocity : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;
    private Vector3 previousPosition;

    public Vector3 Velocity { get => velocity; }
    public Vector3 InverseVelocity { get => transform.InverseTransformDirection(velocity); }
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovementVelocity();
    }

    private void MovementVelocity()
    {
        // V‰hennet‰‰n nykyinen positio edellisen framen positiosta ja jaetaan time.deltatimella niin saadaan nopeus ms
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        // Talletetaan nykyinen positio seuraavaa framea varten
        previousPosition = transform.position;
    }
}
