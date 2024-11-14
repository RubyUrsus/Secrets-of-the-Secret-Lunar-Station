using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalFloat", menuName = "ScriptableObjects/GlobalFloat")]

public class GlobalFloat : ScriptableObject
{
    public float maxHealth;
    public float minHealth;
    public float currentHealth;
}
