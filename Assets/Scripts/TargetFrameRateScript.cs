using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRateScript : MonoBehaviour
{
    // Aseta haluttu ruudunpäivitystaajuus
    public int targetFrameRate = 60;

    void Start()
    {
        // Aseta ruudunpäivitystaajuus pelin käynnistyessä
        Application.targetFrameRate = targetFrameRate;
    }

    void Update()
    {
        // (Valinnainen) Varmista, että arvo pysyy oikein myös kesken pelin
        if (Application.targetFrameRate != targetFrameRate)
        {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}
