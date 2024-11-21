using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIChargeLeft : MonoBehaviour, IOnUndoChargesChange
{
    private UndoMovement undoMovement;
    TextMeshProUGUI chargesLeftText;
    [SerializeField] int chargesLeft;

    private void Awake()
    {
        chargesLeftText = GetComponent<TextMeshProUGUI>();
        chargesLeftText.text = chargesLeft.ToString();
        undoMovement = FindObjectOfType<UndoMovement>();
        undoMovement.AddUndoMovementListener(this);
    }
    public void OnUndoChargesChange(int charges, bool undoUsed)
    {
        chargesLeft = charges;
        chargesLeftText.text = chargesLeft.ToString();
        
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
