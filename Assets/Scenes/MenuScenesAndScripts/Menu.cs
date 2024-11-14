using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    public void OnPlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnContinueButton()
    {
        menuCanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
