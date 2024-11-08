using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnUndoChargesChange
{
    public void OnUndoChargesChange(int charges, bool undoUsed);
}
