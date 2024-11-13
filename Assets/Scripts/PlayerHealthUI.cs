using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Image healthBar;
    [SerializeField] GlobalFloat playerHealth;

    void Start()
    {
        healthBar = GetComponent<Image>();

    }

    void Update()
    {
        healthBar.fillAmount = playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
