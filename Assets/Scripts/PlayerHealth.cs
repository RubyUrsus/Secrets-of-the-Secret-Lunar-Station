using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] GlobalFloat playerHealth;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject pauseMenuEmpty;

    SaveManager saveManager;


    private void Start()
    {
        playerHealth.currentHealth = playerHealth.maxHealth;
        saveManager = GetComponent<SaveManager>();
    }

    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deathScreen.SetActive(true);
        pauseMenuEmpty.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //SoundManager.Instance.PlayHumanDamageSound();
        if (collision.gameObject.tag == "Damage")
        {
            playerHealth.currentHealth -= 20;
        }
    }

    public void TakeDamagee(float damageAmount)
    {
        //throw new System.NotImplementedException();
        playerHealth.currentHealth -= 20;
    }
}
