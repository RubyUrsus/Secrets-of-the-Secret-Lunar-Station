using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // Particle effect prefab for overheat
    public GameObject OverheatedSmoke;
    // Particle effect prefab for hits 
    public GameObject hitEffectPrefab;           
    // Reference to the bullet prefab
    public GameObject bulletPrefab;
    

    // Point where the bullet will spawn
    public Transform firePoint;

    // Reference to the player's camera (or weapon)
    //public Transform recoilCamera;

    // Bullet and firing settings
    public LayerMask bulletMask;
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

    float cooldownTick = 0.1f;
    float tickTimer;

    [SerializeField]
    Transform camTransform;

    public int ShotsFired => shotsFired;

    void Start()
    {
        // Store the original rotation of the camera or weapon
        originalCameraRotation = camTransform.localEulerAngles;

        // Find the MouseLook script to apply recoil
        mouseLook = FindObjectOfType<MouseLook>();

        camTransform = Camera.main.transform;

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
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && canShoot && Time.timeScale != 0)
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
                GameObject OverheatedSmoke = Instantiate(this.OverheatedSmoke, firePoint.position, firePoint.rotation);
                OverheatedSmoke.transform.SetParent(firePoint, false);
                OverheatedSmoke.transform.position = firePoint.position;
                OverheatedSmoke.transform.rotation = firePoint.rotation;    
                SoundManager.Instance.PlayOverHeatSound();
                canShoot = false;
                cooldownStartTime = Time.time; // Start the cooldown timer
            }
        }

        if (!Input.GetButton("Fire1") && shotsFired != 0)
        {
            tickTimer += Time.deltaTime;
            if (tickTimer > cooldownTick)
            {
                shotsFired--;
                tickTimer = 0;
            }
        }
    }

    void Shoot()
    {
        SoundManager.Instance.PlayGunShotSound();
        // Instantiate the bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector3 direction = firePoint.forward;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hitInfo, 1000, bulletMask, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.blue, 20);
            direction = hitInfo.point - firePoint.position;
            Debug.DrawRay(firePoint.position, direction, Color.green, 20);

            Enemy enemy = hitInfo.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Apply damage to the enemy
                enemy.TakeDamage(1, hitInfo.point, direction); // Using the impact overload to apply force

                // Instantiate particle effect at the point of impact
                if (hitEffectPrefab != null)
                {
                    Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Debug.Log("Instantiate osuma");
                }

            }

            // Debug visualization
            Debug.DrawRay(firePoint.position, direction * hitInfo.distance, Color.green, 1.0f);

        }

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
            // Optional: Destroy bullet after 1 second to prevent memory overload
            Destroy(bullet, 0.1f);
        }
        
    }
}