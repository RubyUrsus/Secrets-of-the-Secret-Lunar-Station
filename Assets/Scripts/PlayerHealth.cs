using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] GlobalFloat playerHealth;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject pauseMenuEmpty;

    private void Start()
    {
        playerHealth.currentHealth = playerHealth.maxHealth;
    }

    private void Update()
    {
        if (playerHealth.currentHealth <= 0) Death();
    }

    private void Death()
    {
        SoundManager.Instance.StopBackgroundMusic();
        SoundManager.Instance.PlayDeathSound();
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
