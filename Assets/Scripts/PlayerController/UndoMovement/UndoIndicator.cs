using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.Rendering;

public class UndoIndicator : MonoBehaviour, IOnUndoChargesChange
{
    private UndoMovement undoMovement;
    [SerializeField] AudioEvent teleportSound;
    AudioSource audioSource;
    public Volume volume;
    private Vignette vignette;
    [SerializeField]
    float maxIntensity = 0.5f;
    [SerializeField]
    public float flashDuration = 0.5f;
    private int undoCharges;

    void Awake()
    {
        undoMovement = FindObjectOfType<UndoMovement>();
        undoMovement.AddUndoMovementListener(this);

        // Varmista, että Vignette löytyy Volume-profiilista
        if (volume != null && volume.profile.TryGet(out vignette))
        {
            vignette.intensity.overrideState = true;  // Varmista, että intensiteetti on säädettävissä
            vignette.intensity.value = 0f;            // Aloitusarvoksi 0
        }
        else
        {
            Debug.LogWarning("Vignette-efektiä ei löytynyt Volume Profilesta!");
        }
        audioSource = GetComponent<AudioSource>();
    }


    private IEnumerator UndoFlashRoutine()
    {
        float elapsedTime = 0f;

        // Pienennä intensity takaisin nollaan
        while (elapsedTime < flashDuration)
        {
            vignette.intensity.value = Mathf.Lerp(maxIntensity, 0, elapsedTime / flashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Varmistaa, että intensiteetti palautuu nollaan
        vignette.intensity.value = 0;
    }


    private void OnEnable()
    {
        undoMovement.AddUndoMovementListener(this);
    }

    private void OnDisable()
    {
        undoMovement.RemoveUndoMovementListener(this);
    }

    public void OnUndoChargesChange(int charges, bool undoUsed)
    {
        if (vignette != null && undoUsed) // Tarkistetaan, että vignette löytyy ennen käynnistystä
        {
            StartCoroutine(UndoFlashRoutine());
            teleportSound.Play(audioSource);
        }
    }
}

