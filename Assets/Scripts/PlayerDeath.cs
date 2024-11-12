using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IOnHealthChange
{
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        playerHealth.AddObserver(this);
    }
    private void OnDisable()
    {
        playerHealth.RemoveObserver(this);
    }

    public void OnHealthChange(int health)
    {
        throw new System.NotImplementedException();
    }


}
