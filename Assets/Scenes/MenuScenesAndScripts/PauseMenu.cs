using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] Button ContinueButton;
    [SerializeField] MouseLook mouseLook;
    SaveManager saveManager;

    void Start()
    {
        ContinueButton.onClick.AddListener(OnContinueButton);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ToPauseMenu();
    }

    public void ToPauseMenu()
    {
        Time.timeScale = 0;
        menuCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        mouseLook.enabled = false;
    }

    public void OnContinueButton()
    {
        StartCoroutine(PressDelay());

        menuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
    }

    public void OnLoadGameButton()
    {
        PlayerPrefs.SetInt("LoadGame", 1);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator PressDelay()
    {
        yield return new WaitForSecondsRealtime(0.2f);

        Time.timeScale = 1;
    }
}
