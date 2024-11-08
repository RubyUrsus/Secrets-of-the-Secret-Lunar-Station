using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIChargeLeft : MonoBehaviour, IOnUndoChargesChange
{
    private UndoMovement undoMovement;
    TextMeshProUGUI chargesLeftText;
    [SerializeField]
    int chargesLeft;

    private void Awake()
    {
        chargesLeftText = GetComponent<TextMeshProUGUI>();
        chargesLeftText.text = "CHARGES LEFT " + chargesLeft.ToString();
        undoMovement = FindObjectOfType<UndoMovement>();
        undoMovement.AddUndoMovementListener(this);
    }


    public void OnUndoChargesChange(int charges, bool undoUsed)
    {
        chargesLeft = charges;
        chargesLeftText.text = "CHARGES LEFT " + chargesLeft.ToString();
    }

    private void OnEnable()
    {
        undoMovement.AddUndoMovementListener(this);
    }

    private void OnDisable()
    {
        undoMovement.RemoveUndoMovementListener(this);
    }
}
