using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioEvent))]
public class AudioEventEditor : Editor
{
    // Tämän scriptin tulee olla Editor kansiossa, jotta Unity osaa buildata pelin

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AudioEvent audioEvent = (AudioEvent)target;

        if (GUILayout.Button("Play"))
        {
            audioEvent.AudioPreview();
        }

        if (GUILayout.Button("Stop"))
        {
            audioEvent.StopAudioPreview();
        }
    }


}
