using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRateScript : MonoBehaviour
{
    // Aseta haluttu ruudunp�ivitystaajuus
    public int targetFrameRate = 60;

    void Start()
    {
        // Aseta ruudunp�ivitystaajuus pelin k�ynnistyess�
        Application.targetFrameRate = targetFrameRate;
    }

    void Update()
    {
        // (Valinnainen) Varmista, ett� arvo pysyy oikein my�s kesken pelin
        if (Application.targetFrameRate != targetFrameRate)
        {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}
