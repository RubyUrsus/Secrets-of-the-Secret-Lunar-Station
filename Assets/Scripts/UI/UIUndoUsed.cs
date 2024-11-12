using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class UIUndoUsed : MonoBehaviour, IOnUndoChargesChange
{
    private UndoMovement undoMovement;
    private Inventory inventory;
    [SerializeField]
    Image undoIcon;
    [SerializeField]
    float flashDuration = 0.3f;



    // Start is called before the first frame update
    void Awake()
    {
        undoMovement = FindObjectOfType<UndoMovement>();
        undoMovement.AddUndoMovementListener(this);

        inventory = FindObjectOfType<Inventory>();
        undoIcon.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (inventory.HasUndo) undoIcon.gameObject.SetActive(true);
        else undoIcon.gameObject.SetActive(false);
    }


    public void OnUndoChargesChange(int charges, bool undoUsed)
    {
        UndoFlashRoutine();
    }

    private void OnEnable()
    {
        undoMovement.AddUndoMovementListener(this);
    }

    private void OnDisable()
    {
        undoMovement.RemoveUndoMovementListener(this);
    }


    private IEnumerator UndoFlashRoutine()
    {
        float elapsedTime = 0f;

        // Pienennä intensity takaisin nollaan
        while (elapsedTime < flashDuration)
        {
            undoIcon.fillAmount = Mathf.Lerp(1, 0, elapsedTime / flashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        undoIcon.fillAmount = 1;
    }
}
