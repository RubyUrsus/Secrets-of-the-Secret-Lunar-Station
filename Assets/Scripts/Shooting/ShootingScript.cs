using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // Reference to the bullet prefab
    public GameObject bulletPrefab;

    // Point where the bullet will spawn
    public Transform firePoint;

    // Reference to the player's camera (or weapon)
    public Transform recoilCamera;

    // Bullet and firing settings
    public float bulletSpeed = 20f;
    public float fireRate = 10f;

    // Recoil settings
    public float recoilAmount = 2f;
    public float recoilRecoverySpeed = 5f;

    // Shot tracking and cooldown settings
    private int shotsFired = 0;        // Counter for shots fired
    private float nextFireTime = 0f;   // Time of next allowed shot
    private bool canShoot = true;      // Control if player can shoot
    private float cooldownDuration = 3f;   // Cooldown time after 100 shots
    private float cooldownStartTime = 0f;  // When the cooldown started

    private Vector3 originalCameraRotation;
    public MouseLook mouseLook;

    void Start()
    {
        // Store the original rotation of the camera or weapon
        originalCameraRotation = recoilCamera.localEulerAngles;

        // Find the MouseLook script to apply recoil
        mouseLook = FindObjectOfType<MouseLook>();
    }

    void Update()
    {
        // Handle cooldown
        if (!canShoot)
        {
            // Check if cooldown period has passed
            if (Time.time >= cooldownStartTime + cooldownDuration)
            {
                // Reset shot counter and enable shooting again
                shotsFired = 0;
                canShoot = true;
            }
            return; // Prevent further shooting until cooldown is over
        }

        // Check if the player is holding down the fire button and if it's time to shoot again
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && canShoot)
        {
            // Update nextFireTime for fire rate and fire the shot
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
            mouseLook.ApplyRecoil();

            // Increase shot counter
            shotsFired++;

            // Start cooldown if 100 shots have been fired
            if (shotsFired >= 100)
            {
                canShoot = false;
                cooldownStartTime = Time.time; // Start the cooldown timer
            }
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add velocity to the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }

        // Optional: Destroy bullet after 1 second to prevent memory overload
        Destroy(bullet, 1f);
    }
}