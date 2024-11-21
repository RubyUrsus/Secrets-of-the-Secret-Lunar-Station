using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMainMenuSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMainMenuMusic();
    }

}
