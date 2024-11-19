using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;

    public void OnPlayButton()
    {
        PlayerPrefs.SetInt("LoadGame", 0);
        SceneManager.LoadScene(2);
    }

    public void OnLoadGameButton()
    {
        PlayerPrefs.SetInt("LoadGame", 1);
        SceneManager.LoadScene(2);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}
