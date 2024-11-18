using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GlobalFloat playerHealth;

    //muu
    SaveManager saveManager;
    //tos

    private void Start()
    {
        playerHealth.currentHealth = playerHealth.maxHealth;
        //muu
        saveManager = FindObjectOfType<SaveManager>();
        //tos
    }

    private void Update()
    {
        //muu
        if (Input.GetKeyDown(KeyCode.K)) playerHealth.currentHealth = 0;
        //tos
        if (playerHealth.currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Dead");
        //muu
        saveManager.Load();
        //tos

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Damage")
    //    {
    //        playerHealth.currentHealth -= 20;
    //    }
    //}
}
