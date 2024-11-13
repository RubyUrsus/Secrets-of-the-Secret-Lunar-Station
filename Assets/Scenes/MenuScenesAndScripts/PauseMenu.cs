using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject MenuCanvas;

    void Start()
    {
        MenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ToPauseMenu();
    }

    public void ToPauseMenu()
    {
        Time.timeScale = 0;
        MenuCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
