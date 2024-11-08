using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.Rendering;

public class UndoIndicator : MonoBehaviour
{
    [SerializeField] AudioEvent teleportSound;
    public Volume volume;
    private Vignette vignette;
    public float maxIntensity = 0.5f;
    public float flashDuration = 0.5f;

    void Start()
    {
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
    }

    public void TriggerUndoFlash()
    {
        if (vignette != null) // Tarkistetaan, ett� vignette l�ytyy ennen k�ynnistyst�
        {
            StartCoroutine(UndoFlashRoutine());
        }
    }

    private IEnumerator UndoFlashRoutine()
    {
        float elapsedTime = 0f;

        // Nosta intensity maksimiasetukseen
        while (elapsedTime < flashDuration / 2)
        {
            vignette.intensity.value = Mathf.Lerp(0, maxIntensity, elapsedTime / (flashDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;

        // Pienenn� intensity takaisin nollaan
        while (elapsedTime < flashDuration / 2)
        {
            vignette.intensity.value = Mathf.Lerp(maxIntensity, 0, elapsedTime / (flashDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Varmistaa, ett� intensiteetti palautuu nollaan
        vignette.intensity.value = 0;
    }
}

