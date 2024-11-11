using UnityEngine;

public interface IInteractable
{
    public string UIText { get; }

    public void Interact(Vector3 direction);
}
