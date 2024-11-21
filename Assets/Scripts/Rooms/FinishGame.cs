using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour, IInteractable
{

    public string UIText => "Let’s bail and never look back!";

    public void Interact()
    {
        SceneManager.LoadScene(0);
    }

}
