using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class UndoMovement : MonoBehaviour
{
    Stack<Vector3> undoStack = new Stack<Vector3>();
    [SerializeField]
    int undoDistance = 10;
    CharacterController characterController;
    Vector3 lastUndo;
    [SerializeField]
    int undoCharges = 3;
    bool undoUsed;

    UndoIndicator undoInd;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        undoStack.Push(transform.position);
        lastUndo = undoStack.Peek();
        undoInd = FindObjectOfType<UndoIndicator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (CheckDistancePeek() && CheckDistancePrevious() && characterController.isGrounded)
        {
            undoStack.Push(transform.position);
        }
        Debug.DrawRay(undoStack.Peek(), Vector3.up, Color.yellow);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (undoStack.Count > 1 && undoCharges > 0) UndoLastMovement();
            else if (undoStack.Count <= 1) Debug.Log("No positions available!");
            else if (undoCharges <= 0) Debug.Log("Not enough charges");
        }
             
        if (Input.GetKeyDown(KeyCode.Return)) AddUndoCharge();
    }

    void UndoLastMovement()
    {
        lastUndo = undoStack.Peek();
        transform.position = undoStack.Pop();
        undoCharges--;
        undoInd.TriggerUndoFlash();
    }

    public void AddUndoCharge()
    {
        undoCharges++;
    }

    public void ClearStack()
    {
        undoStack.Clear();
    }

    bool CheckDistancePeek()
    {
        if (Vector3.Distance(transform.position, undoStack.Peek()) > undoDistance) return true;
        else return false;
    }
    bool CheckDistancePrevious()
    {
        if (Vector3.Distance(transform.position, lastUndo) > (undoDistance/2)) return true;
        else return false;
    }

}
