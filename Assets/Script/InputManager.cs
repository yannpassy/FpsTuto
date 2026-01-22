using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        onFoot.Jump.performed += ctx => motor.Jump(); // each time the button jump is pushed, call motor.Jump()
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        //tell the playermotor to moveusing the value from my movement action
        motor.ProcessMove(onFoot.Mouvement.ReadValue<Vector2>()); // mouvement is from the input action you created. you made it in french
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
