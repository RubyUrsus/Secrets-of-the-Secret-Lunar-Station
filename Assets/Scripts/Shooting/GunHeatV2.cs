using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHeatV2 : MonoBehaviour
{
    [SerializeField]
    Renderer heatLevel;
    [SerializeField]
    Material coolMaterial;
    [SerializeField]
    Material hotMaterial;
    [SerializeField]
    ShootingScript shootingScript;
    [SerializeField] private int[] shotThresholds = { 19, 39, 59, 79, 99 }; // Kynnysarvot, jolloin valot syttyv‰t


    // Update is called once per frame
    void Update()
    {
        int shotsFired = shootingScript.ShotsFired;
        UpdateLights(shotsFired);



        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    heatLevel.SetMaterials;
        //}
        //if (shootingScript.ShotsFired > 19) heatLevel.materials[1] = hotMaterial;
        //else heatLevel.materials[1] = coolMaterial;
        //if (shootingScript.ShotsFired > 39) heatLevel.materials[2] = hotMaterial;
        //else heatLevel.materials[2] = coolMaterial;
        //if (shootingScript.ShotsFired > 59) heatLevel.materials[3] = hotMaterial;
        //else heatLevel.materials[3] = coolMaterial;
        //if (shootingScript.ShotsFired > 79) heatLevel.materials[4] = hotMaterial;
        //else heatLevel.materials[4] = coolMaterial;
        //if (shootingScript.ShotsFired > 99) heatLevel.materials[5] = hotMaterial;
        //else heatLevel.materials[5] = coolMaterial;
    }

    void UpdateLights(int shotsFired)
    {
        // Kopioi materiaalit listaan
        Material[] materials = heatLevel.materials;

        // Kytke valot p‰‰lle shotsFired-kynnyksist‰ riippuen
        for (int i = 0; i < shotThresholds.Length; i++)
        {
            if (shotsFired > shotThresholds[i])
            {
                materials[i] = hotMaterial;
            }
            else
            {
                materials[i] = coolMaterial;
            }
        }

        // P‰ivit‰ MeshRendererin materiaalit
        heatLevel.materials = materials;
    }
}
