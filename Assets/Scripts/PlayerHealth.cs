using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private List<IOnHealthChange> observers = new List<IOnHealthChange>();

    public void AddObserver(IOnHealthChange observer)
    {
        if(!observers.Contains(observer)) observers.Add(observer);
    }

    public void RemoveObserver(IOnHealthChange observer)
    {
        if(observers.Contains(observer)) observers.Remove(observer);
    }
}
