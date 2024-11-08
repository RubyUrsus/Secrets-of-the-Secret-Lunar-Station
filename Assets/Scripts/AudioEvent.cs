using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Member;

[CreateAssetMenu(fileName = "AudioEvent", menuName ="ScriptableObjects/Audio Event")]
public class AudioEvent : ScriptableObject
{
    [SerializeField]
    private AudioClip[] clips;
    [SerializeField, Range(0f, 1f)]
    private float volume = 1.0f;
    [SerializeField, Range(0f, 1f)]
    private float pitch = 1.0f;
    [Header("Sound randomization")]
    [SerializeField, Range(0f, 1f)]
    private float volumeRandomization;
    [SerializeField, Range(0f, 1f)]
    private float pitchRandomization;

    // #if - #endif voidaan rajata pois buildista
#if UNITY_EDITOR

    private AudioSource previewSource;


    public void AudioPreview()
    {
        Debug.Log("Playing audio");
        if (previewSource == null)
        {
            GameObject go = EditorUtility.CreateGameObjectWithHideFlags("AudioPreview", HideFlags.HideAndDontSave, typeof(AudioSource));
            previewSource = go.AddComponent<AudioSource>();
        }
        Play(previewSource);
    }

    public void StopAudioPreview()
    {
        Debug.Log("Stopping preview");
        if (previewSource != null)
        {
            previewSource.Stop();
            DestroyImmediate(previewSource.gameObject);
        }
    }
#endif
    public void Play(AudioSource audioSource)
    {
        int stepIndex = Random.Range(0, clips.Length);
        audioSource.clip = clips[stepIndex];
        audioSource.volume = Random.Range(1 - volumeRandomization, volume);
        audioSource.pitch = Random.Range(pitch - (pitchRandomization * 0.5f), pitch + (pitchRandomization * 0.5f));
        audioSource.Play();
    }
}
