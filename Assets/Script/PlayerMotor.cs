using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    [SerializeField]private float speed = 5f;
    [SerializeField]private float gravity = -9.8f;
    [SerializeField]private float jumpHeight = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    // receive input from InputManager.cs and apply it to the CharacterManager
    public void ProcessMove(Vector2 _input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = _input.x;
        moveDirection.z = _input.y;
        // TransformDirection permet d'avancer vers là où le joueur regarde
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // gravity system
        playerVelocity.y += gravity * Time.deltaTime; 
        if(isGrounded && playerVelocity.y<0)
            playerVelocity.y = -2f;
        
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);  // ??? (from the tutorial, it didn't explain why)
        }
    }
}
