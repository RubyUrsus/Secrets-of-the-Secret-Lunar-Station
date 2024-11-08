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

        // Varmista, ett� Vignette l�ytyy Volume-profiilista
        if (volume != null && volume.profile.TryGet(out vignette))
        {
            vignette.intensity.overrideState = true;  // Varmista, ett� intensiteetti on s��dett�viss�
            vignette.intensity.value = 0f;            // Aloitusarvoksi 0
        }
        else
        {
            Debug.LogWarning("Vignette-efekti� ei l�ytynyt Volume Profilesta!");
        }
        audioSource = GetComponent<AudioSource>();
    }


    private IEnumerator UndoFlashRoutine()
    {
        float elapsedTime = 0f;

        // Pienenn� intensity takaisin nollaan
        while (elapsedTime < flashDuration)
        {
            vignette.intensity.value = Mathf.Lerp(maxIntensity, 0, elapsedTime / flashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Varmistaa, ett� intensiteetti palautuu nollaan
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
        if (vignette != null && undoUsed) // Tarkistetaan, ett� vignette l�ytyy ennen k�ynnistyst�
        {
            StartCoroutine(UndoFlashRoutine());
            teleportSound.Play(audioSource);
        }
    }
}

