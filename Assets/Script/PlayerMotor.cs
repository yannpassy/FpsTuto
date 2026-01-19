using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]private float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // receive input from InputManager.cs and apply it to the CharacterManager
    public void ProcessMove(Vector2 _input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = _input.x;
        moveDirection.z = _input.y;
        // TransformDirection permet d'avancer vers là où le joueur regarde
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }
}
