using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage ; // text when the player look at the interactable

    // this function will called from the player
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        // this is an template function to be overridden by our subclass
    }
}
