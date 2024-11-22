using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    [SerializeField] Slider sensitivitySlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MouseSensitivity"))
        {

            float mouseSens = PlayerPrefs.GetFloat("MouseSensitivity", 1);
            sensitivitySlider.value = mouseSens;
        }
    }
    public void OnSliderMovement(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
    }
}
