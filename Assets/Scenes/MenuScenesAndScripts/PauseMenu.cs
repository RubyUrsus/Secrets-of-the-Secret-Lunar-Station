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
        Cursor.visible = true;
        mouseLook.enabled = false;
    }

    public void OnContinueButton()
    {
        StartCoroutine(PressDelay());

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseLook.enabled = true;
        menuCanvas.SetActive(false);
    }

    public void OnLoadGameButton()
    {
        PlayerPrefs.SetInt("LoadGame", 1);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    IEnumerator PressDelay()
    {
        yield return new WaitForSecondsRealtime(0.2f);

        Time.timeScale = 1;
    }
}
