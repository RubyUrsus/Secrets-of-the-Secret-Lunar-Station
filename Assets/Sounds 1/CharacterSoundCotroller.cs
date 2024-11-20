using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSoundController : MonoBehaviour
{
    [Header("Character Settings")]
    public bool isPlayer = true; // Check if it's the player or a monster
    public float stepInterval = 0.5f; // Base interval for step sounds
    public float stepIntervalMultiplier = 1.0f; // Adjust based on speed
    public float movementThreshold = 0.1f; // Minimum speed to play step sounds
    CharacterController characterController;
    CalculateVelocity CalculateVelocity;
    private float stepTimer = 0f; // Timer to control step sound intervals

    [SerializeField] float speed;

    private void Start()
    {
       CalculateVelocity = GetComponent<CalculateVelocity>(); // Optional, use Rigidbody if available
       characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        speed = GetMovementSpeed(); // Get the character's movement speed

        // Debug speed value (for troubleshooting)
        //Debug.Log($"Speed: {speed}");

        // Only adjust the timer if speed is above the threshold
        if (speed > movementThreshold)
        {
            // Adjust step interval based on speed
            //float adjustedInterval = (1 + (speed / 5f)) * stepInterval;
            float adjustedInterval = 0.4f;

            // Count down the timer
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0) // Play step sound if timer runs out
            {
                PlayStepSound();
                stepTimer = adjustedInterval; // Reset the timer
            }
        }
        else
        {
            // Reset the timer when not moving to prevent premature triggering
            stepTimer = 0f;
        }
    }

    private float GetMovementSpeed()
    {
        // Use Rigidbody velocity for speed
        if (characterController.isGrounded && CalculateVelocity != null)
        {
            if (CalculateVelocity.velocitySmoothed.magnitude >= 1.25f)

                return CalculateVelocity.velocitySmoothed.magnitude;
        }    
            

        // Fallback to custom speed calculation (e.g., Animator)
        return 0f; // Replace with your custom logic
    }

    private void PlayStepSound()
    {
        if (isPlayer)
        {
            SoundManager.Instance.PlayHumanStepSound();
        }
        else
        {
            SoundManager.Instance.PlayMonsterStepSound();
        }
    }
}