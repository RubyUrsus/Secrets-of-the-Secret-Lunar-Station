using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        mouseLook.enabled = false;
    }

    public void OnContinueButton()
    {
        StartCoroutine(PressDelay());

        menuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
    }

    IEnumerator PressDelay()
    {
        yield return new WaitForSecondsRealtime(0.2f);

        Time.timeScale = 1;
    }
}
