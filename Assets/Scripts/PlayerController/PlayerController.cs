using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField]
    public float movementSpeed = 1f;
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField]
    float drag = 0.4f;
    [SerializeField]
    float smoothing = 0.2f;
    [SerializeField]
    float gravity = -9.81f;

    Vector3 velocity;
    float currentVelX;
    float currentVelZ;
    Vector3 currentVel;
    Vector3 smoothMovement;
    Vector3 currentDashDir;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 movement = transform.TransformDirection(input);
        smoothMovement = Vector3.SmoothDamp(smoothMovement, movement.normalized, ref currentVel, smoothing);

        velocity.y += gravity * Time.deltaTime;
        if (characterController.isGrounded)
        {
            velocity.y = -2;
        }
        velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref currentVelX, drag);
        velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref currentVelZ, drag);


        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)) AddImpulseForce(Vector3.up * jumpForce);
        Debug.DrawRay(transform.position, currentDashDir, Color.yellow);
        Debug.DrawRay(transform.position, movement.normalized, Color.red);

        if (Vector3.Dot(currentDashDir, movement.normalized) < -0.1f)
        {
            velocity.x = 0;
            velocity.z = 0;
        }

        
        
        characterController.Move(smoothMovement * movementSpeed * Time.deltaTime + velocity * Time.deltaTime);
    }

    void AddImpulseForce(Vector3 force)
    {
        velocity += force;
    }

    
}

