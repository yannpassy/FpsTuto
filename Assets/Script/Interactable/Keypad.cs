using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] private Animator anim;
    private bool isDoorOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        isDoorOpen = !isDoorOpen;
        anim.SetBool("isOpen", isDoorOpen);

    }
}
