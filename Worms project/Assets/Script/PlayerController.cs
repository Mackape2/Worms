using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Components
    public CharacterController characterController;
    public float teamOfPlayer;
    public bool isAlive = true; 
    
    //Controls
    public PlayerInput controls;
    private InputAction move;
    private InputAction interact;
    
    //Camera
    public static Vector3 movement;
    public GameObject playerCamera;
    
    //Movement
    public Vector2 movementInput;
    public float speed = 5f;

    public bool isActivePlayer;
    
    
    private void Awake()
    {
        controls = new PlayerInput();
    }
    
    private void OnEnable()
    {
        move = controls.Player.Movement; 
       
        
        move.Enable();
        move.performed += OnMove;

    }
    
    private void OnDisable()
    {
        move.performed -= OnMove;
        move.Disable();
    }
    
    private void OnMove(InputAction.CallbackContext obj)
    {
        movementInput = obj.ReadValue<Vector2>();

    }
    
    private void FixedUpdate()
    {
        movement = new Vector3((movementInput.x), 0, (movementInput.y)).normalized;
        //Making the Player look forward

        if (movement != Vector3.zero)
            gameObject.transform.forward = movement;
        //Have to implement the gravity in code because the character controller collides with the rigidbody
        if (!characterController.isGrounded)
            movement.y = -1;
        if(!characterController.enabled == false)        
            characterController.Move(movement * (Time.fixedDeltaTime * speed));
    }
}
