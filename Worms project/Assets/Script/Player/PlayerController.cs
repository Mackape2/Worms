using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody rb;
    public GameObject linjal;
    public Transform orientation;


    [Header("Player Specific")]
    public bool isActivePlayer;
    public float teamOfPlayer;
    public bool isAlive = true; 
    
    [Header("Controls")]
    public PlayerInput controls;
    private InputAction move;
    private InputAction interact;
    
    [Header("Camera controls")]
    public static Vector3 movement;
    public GameObject playerCamera;
    
    
    [Header("Movement")]
    private Vector2 movementInput;
    private Vector3 moveDirection;
    
    public float speed = 5f;
    public float rotationSpeed = 10f;
    
    private void Awake()
    {
        controls = new PlayerInput();
        orientation = linjal.transform;
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
    
    private void SetDirection()
    {
        //Figure out forward vector from camera to player
        var cpos = playerCamera.transform.position;
        var newViewDirection = this.gameObject.transform.position - new Vector3(cpos.x, gameObject.transform.position.y, cpos.z);
        orientation.forward = newViewDirection.normalized;
        
        
        //Apply orienation and create movedirection
        moveDirection = orientation.forward * movementInput.y + orientation.right * movementInput.x;
        if (moveDirection != Vector3.zero)
            transform.forward = Vector3.Slerp(transform.forward, moveDirection.normalized, Time.deltaTime * rotationSpeed);
            
    }
    
    private void SetVelocity()
    {
        Vector3 newMovement = moveDirection.normalized * (speed  * Time.deltaTime);
        newMovement.y = rb.velocity.y;
        
        rb.velocity = newMovement;
    }
    private void Update()
    {
       
        SetDirection();
        
        if (rb.velocity.y <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(0,500f,0);
            } 
        }
           
    }
    private void FixedUpdate()
    {
        SetVelocity();
    }
}
