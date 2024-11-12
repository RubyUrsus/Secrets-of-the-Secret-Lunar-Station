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

    // Bullet settings
    public float bulletSpeed = 20f;
    public float fireRate = 10f;

    // Recoil settings
    public float recoilAmount = 2f;    // Amount of recoil
    public float recoilRecoverySpeed = 5f;  // Speed at which recoil recovers

    private float nextFireTime = 0f;
    private Vector3 originalCameraRotation;

    public MouseLook mouseLook;

    void Start()
    {
        // Store the original rotation of the camera or weapon
        originalCameraRotation = recoilCamera.localEulerAngles;

        mouseLook = FindObjectOfType<MouseLook>();
    }

    void Update()
    {
        // Check if the player is holding down the fire button (left mouse button by default)
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
            mouseLook.ApplyRecoil();
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

        // Optional: Destroy bullet after 1 seconds to prevent memory overload
        Destroy(bullet, 1f);
    }

    //void ApplyRecoil()
    //{
    //    // Randomize a slight upward rotation (recoil) in the camera or weapon
    //    float recoilX = Random.Range(recoilAmount * 0.8f, recoilAmount); // Random upward recoil
    //    float recoilY = Random.Range(-recoilAmount / 4, recoilAmount / 4); // Slight side-to-side recoil

    //    // Apply recoil to the local rotation of the camera or weapon
    //    recoilCamera.localEulerAngles += new Vector3(-recoilX, recoilY, 0f);
    //}

    //void RecoverRecoil()
    //{
    //    // Smoothly return the camera or weapon to its original rotation
    //    recoilCamera.localEulerAngles = Vector3.Lerp(recoilCamera.localEulerAngles, originalCameraRotation, Time.deltaTime * recoilRecoverySpeed);
    //}
}