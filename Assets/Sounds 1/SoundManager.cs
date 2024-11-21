using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Singleton instance
    public static SoundManager Instance;

    [Header("Human Sounds")]
    public AudioClip[] humanStepSounds; // Array for multiple step sounds
    public AudioClip humanDamageSound;
    public AudioClip deathSound;

    [Header("Monster Sounds")]
    public AudioClip[] monsterStepSounds; // Array for multiple step sounds
    public AudioClip monsterDamageSound;
    public AudioClip monsterDeathSound;

    [Header("Background Music")]
    public AudioClip backgroundMusic;

    [Header("Weapon Sounds")]
    public AudioClip gunShotSound;

    [Header("Misc")]
    public AudioClip helmetSound;
    public AudioClip overHeat;
    public AudioClip collectibleSound;
    public AudioClip doorSound;

    private AudioSource audioSource;
    private Dictionary<string, AudioSource> backgroundSources = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        // Set up singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Add AudioSource component for generic sound effects
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // Add AudioSource for background music
        if (backgroundMusic)
        {
            AudioSource bgMusicSource = gameObject.AddComponent<AudioSource>();
            bgMusicSource.clip = backgroundMusic;
            bgMusicSource.loop = true;
            bgMusicSource.playOnAwake = false;
            bgMusicSource.volume = 0.5f; // Adjust volume if needed
            backgroundSources.Add("background", bgMusicSource);
        }
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    // Play a one-shot sound
    private void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }

    // Play a random sound from an array
    private void PlayRandomSound(AudioClip[] clips, float volume = 1.0f)
    {
        if (clips != null && clips.Length > 0)
        {
            int randomIndex = Random.Range(0, clips.Length);
            PlaySound(clips[randomIndex], volume);
        }
    }

    // Background music
    public void PlayBackgroundMusic()
    {
        if (backgroundSources.TryGetValue("background", out var bgMusicSource))
        {
            if (!bgMusicSource.isPlaying)
            {
                bgMusicSource.Play();
            }
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundSources.TryGetValue("background", out var bgMusicSource))
        {
            if (bgMusicSource.isPlaying)
            {
                bgMusicSource.Stop();
            }
        }
    }

    // Human sounds
    public void PlayHumanStepSound()
    {
        PlayRandomSound(humanStepSounds);
    }

    public void PlayHumanDamageSound()
    {
        PlaySound(humanDamageSound);
    }

    public void PlayDeathSound()
    {
        PlaySound(deathSound);
    }

    // Monster sounds
    public void PlayMonsterStepSound()
    {
        PlayRandomSound(monsterStepSounds);
    }

    public void PlayMonsterDamageSound()
    {
        PlaySound(monsterDamageSound);
    }

    public void PlayMonsterDeathSound()
    {
        PlaySound(monsterDeathSound);
    }

    // Weapon sounds
    public void PlayGunShotSound()
    {
        PlaySound(gunShotSound);
    }

    public void PlayOverHeatSound()
    {
        PlaySound(overHeat);
    }


    // Misc sounds

    public void PlayHelmetSound()
    {
        PlaySound(helmetSound);
    }

    public void PlayCollectibleSound()
    {
        PlaySound(collectibleSound);
    }
    public void PlayDoorSound()
    {
        PlaySound(doorSound);
    }



}
