using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.UI;

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

    private Inventory inventory;
    Image undoIcon;


    void Awake()
    {

        undoMovement = FindObjectOfType<UndoMovement>();
        undoMovement.AddUndoMovementListener(this);

        inventory = FindObjectOfType<Inventory>();
        GameObject go = GameObject.FindGameObjectWithTag("UndoChargesUI");
        undoIcon = go.GetComponent<Image>();
        undoIcon.gameObject.SetActive(false);

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



    private void Update()
    {
        if (inventory.HasUndo) undoIcon.gameObject.SetActive(true);
        else undoIcon.gameObject.SetActive(false);
    }

    private IEnumerator UndoFlashRoutine()
    {
        float elapsedTime = 0f;

        // Pienennä intensity takaisin nollaan
        while (elapsedTime < flashDuration)
        {
            undoIcon.fillAmount = Mathf.Lerp(1, 0, elapsedTime / flashDuration);
            vignette.intensity.value = Mathf.Lerp(maxIntensity, 0, elapsedTime / flashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        undoIcon.fillAmount = 1;
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

