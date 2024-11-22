using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void OnLoadGameButton()
    {
        PlayerPrefs.SetInt("LoadGame", 1);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
