using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() 
    {
        onFoot.Enable();    
    }

    void OnDisable()
    {
        onFoot.Disable();
    }
}
