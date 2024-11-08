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
    }

    public void TriggerUndoFlash()
    {
        if (vignette != null) // Tarkistetaan, että vignette löytyy ennen käynnistystä
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

        // Pienennä intensity takaisin nollaan
        while (elapsedTime < flashDuration / 2)
        {
            vignette.intensity.value = Mathf.Lerp(maxIntensity, 0, elapsedTime / (flashDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Varmistaa, että intensiteetti palautuu nollaan
        vignette.intensity.value = 0;
    }
}

