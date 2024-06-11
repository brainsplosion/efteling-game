using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private Vector2 _input;
    private bool sprinting;
    private CharacterController _characterController;
    public BlastWave aoe;
    private Vector3 _direction;

    [SerializeField] private Animator animator;
    private float xInput, yInput;

    [SerializeField] private float rotationSpeed = 500f;
    private Camera _mainCamera;
    //[SerializeField] private float speed;

    [SerializeField] private Movement movement;
    //[SerializeField] private Movement speed;

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    [SerializeField] private float jumpPower;
    private int _numberOfJumps;
    [SerializeField] private int maxNumberOfJumps = 2;

    public GameObject crossfire_big;
    public GameObject crossfire_small;
    public GameObject slash_big;
    public GameObject slash_small;

    public AudioSource hitting;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        aoe = GetComponent<BlastWave>();
        _mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        getInput();
        ApplyRotation();
        ApplyGravity();
        ApplyMovement();
        updateAnimation();
        if(Input.GetKey("left shift"))
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }
        FlashButtons();
    }

    private void getInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    private void updateAnimation()
    {
        if (_direction.x > 0 || _direction.z >0 || _direction.z >0 || _direction.z <0)
        {
            //moving in animator component becomes true
            animator.SetBool("Moving", true);
            if (sprinting == true)
            {
                animator.SetBool("Sprinting", true);
            }
            else
            {
                animator.SetBool("Sprinting", false);
            }
        }
        else
        {
            //moving becomes false
            animator.SetBool("Moving", false);
            animator.SetBool("Sprinting", false);
        }
    }
    
    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        _direction.y = _velocity;
    }
    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return; //If there is no input, dont move (prevents from rotating back at 0 angle whenever not moving)
        _direction = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);
        var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
        
        /*transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);*/ //replace transform line underneath with this to not make player look at middle of screen
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    private void ApplyMovement ()
    {
        var targetSpeed = movement.isSprinting ? movement.speed * movement.multiplier : movement.speed;
        movement.currentSpeed = Mathf.MoveTowards(movement.currentSpeed, targetSpeed, movement.acceleration * Time.deltaTime);

        _characterController.Move(motion: _direction * movement.currentSpeed * Time.deltaTime);
    }
    public void Move(InputAction.CallbackContext context) //uses Unity Input System
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, y:0.0f, z:_input.y);
    }
    public void Jump (InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && _numberOfJumps >= maxNumberOfJumps) return;
        animator.SetBool("Jumping", true);
        if (_numberOfJumps == 0)
        {
            StartCoroutine(routine: WaitForLanding());
        }
 
        _numberOfJumps++;
        _velocity = jumpPower;
        //_velocity = jumpPower / _numberOfJumps; //Lower Jump power on your second jump in the air
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        movement.isSprinting = context.started || context.performed;
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);
        animator.SetBool("Jumping", false);
        _numberOfJumps = 0;
    }

    public void Speederer()
    {
        movement.speed += 3;
    }
    public void Slowerer()
    {
        movement.speed -= 3;
    }

    private void FlashButtons()
    {
        if (Input.GetMouseButton(1))
        {
            crossfire_small.SetActive(false);
            crossfire_big.SetActive(true);
            BlastWave.Instance.Activate();
        }
        else
        {
            crossfire_small.SetActive(true);
            crossfire_big.SetActive(false);
        }

        if (Input.GetMouseButton(0))
        {
            slash_small.SetActive(false);
            slash_big.SetActive(true);
            hitting.enabled = true;
        }
        else
        {
            slash_small.SetActive(true);
            slash_big.SetActive(false);
            hitting.enabled = false;
        }
    }

    public bool IsGrounded() => _characterController.isGrounded;
}

[System.Serializable]
public struct Movement
{
    public float speed;
    public float multiplier;
    public float acceleration;
    [HideInInspector] public bool isSprinting;
    [HideInInspector] public float currentSpeed;
}