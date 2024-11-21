using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Singleton instance
    public static SoundManager Instance;

    [Header("Human Sounds")]
    public AudioClip[] humanStepSounds;
    public AudioClip humanDamageSound;

    [Header("Human deathsound")]
    public AudioClip deathSound;
    [Range(0f, 1f)] public float humanVolume = 1f; // Volume for Human death Sounds

    [Header("Monster Sounds")]
    public AudioClip[] monsterStepSounds;
    public AudioClip monsterDamageSound;
    public AudioClip monsterDeathSound;
    [Range(0f, 1f)] public float monsterVolume = 1f; // Volume for Monster Sounds

    [Header("Background Music")]
    public AudioClip backgroundMusic;
    [Range(0f, 1f)] public float backgroundVolume = 1f; // Volume for Background Music

    [Header("Weapon Sounds")]
    public AudioClip gunShotSound;
    [Range(0f, 1f)] public float weaponVolume = 1f; // Volume for Weapon Sounds

    [Header("Misc Sounds")]
    public AudioClip helmetSound;
    public AudioClip overHeat;
    public AudioClip collectibleSound;
    public AudioClip doorSound;
    public AudioClip EquipPickupsound;
    public AudioClip MainMenuMusic;
    [Range(0f, 1f)] public float miscVolume = 1f; // Volume for Misc Sounds

    private AudioSource audioSource;
    private AudioSource backgroundSource;

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
            backgroundSource = gameObject.AddComponent<AudioSource>();
            backgroundSource.clip = backgroundMusic;
            backgroundSource.loop = true;
            backgroundSource.playOnAwake = false;
            backgroundSource.volume = backgroundVolume; // Use the slider value
        }
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    // Generic method to play a one-shot sound with a volume multiplier
    private void PlaySound(AudioClip clip, float volumeMultiplier)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip, volumeMultiplier);
        }
    }

    // Generic method to play a random sound from an array with a volume multiplier
    private void PlayRandomSound(AudioClip[] clips, float volumeMultiplier)
    {
        if (clips != null && clips.Length > 0)
        {
            int randomIndex = Random.Range(0, clips.Length);
            PlaySound(clips[randomIndex], volumeMultiplier);
        }
    }

    // Background music methods
    public void PlayBackgroundMusic()
    {
        if (backgroundSource != null && !backgroundSource.isPlaying)
        {
            backgroundSource.volume = backgroundVolume; // Use the slider value for initial play
            backgroundSource.Play();
        }
    }

    // Background music volume
    public void SetBackgroundVolume(float volume)
    {
        if (backgroundSource != null)
        {
            backgroundSource.volume = volume; // Dynamically adjust the volume
        }
    }
    // Stop background music
    public void StopBackgroundMusic()
    {
        if (backgroundSource != null && backgroundSource.isPlaying)
        {
            backgroundSource.Stop();
        }
    }

    // Human sounds
    public void PlayHumanStepSound()
    {
        PlayRandomSound(humanStepSounds, humanVolume);
    }

    public void PlayHumanDamageSound()
    {
        PlaySound(humanDamageSound, humanVolume);
    }

    public void PlayDeathSound()
    {
        PlaySound(deathSound, humanVolume);
    }

    // Monster sounds
    public void PlayMonsterStepSound()
    {
        PlayRandomSound(monsterStepSounds, monsterVolume);
    }

    public void PlayMonsterDamageSound()
    {
        PlaySound(monsterDamageSound, monsterVolume);
    }

    public void PlayMonsterDeathSound()
    {
        PlaySound(monsterDeathSound, monsterVolume);
    }

    // Weapon sounds
    public void PlayGunShotSound()
    {
        PlaySound(gunShotSound, weaponVolume);
    }

    public void PlayOverHeatSound()
    {
        PlaySound(overHeat, weaponVolume);
    }

    // Misc sounds
    public void PlayHelmetSound()
    {
        PlaySound(helmetSound, miscVolume);
    }

    public void PlayCollectibleSound()
    {
        PlaySound(collectibleSound, miscVolume);
    }

    public void PlayDoorSound()
    {
        PlaySound(doorSound, miscVolume);
    }

    public void PlayEquipPickupSound()
    {
        PlaySound(EquipPickupsound, miscVolume);
    }

    public void PlayMainMenuMusic()
    {
        PlaySound(MainMenuMusic, miscVolume);
    }
}