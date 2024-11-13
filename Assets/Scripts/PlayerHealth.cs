using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GlobalFloat playerHealth;


    private List<IOnHealthChange> observers = new List<IOnHealthChange>();

    public void AddObserver(IOnHealthChange observer)
    {
        if(!observers.Contains(observer)) observers.Add(observer);
    }

    public void RemoveObserver(IOnHealthChange observer)
    {
        if(observers.Contains(observer)) observers.Remove(observer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            playerHealth.currentHealth -= 20;
        }
    }
}
