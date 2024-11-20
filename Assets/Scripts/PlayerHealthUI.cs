using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Image healthBar;
    [SerializeField] Sprite[] healthBarSprites;
    [SerializeField] GlobalFloat playerHealth;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    void Update()
    {

        if (playerHealth.currentHealth == playerHealth.maxHealth)
        {
            healthBar.sprite = healthBarSprites[0];
        }

        if (playerHealth.currentHealth == 80)
        {
            healthBar.sprite = healthBarSprites[1];
        }

        if (playerHealth.currentHealth == 60)
        {
            healthBar.sprite = healthBarSprites[2];
        }

        if (playerHealth.currentHealth == 40)
        {
            healthBar.sprite = healthBarSprites[3];
        }

        if (playerHealth.currentHealth == 20)
        {
            healthBar.sprite = healthBarSprites[4];
        }

    }
}
