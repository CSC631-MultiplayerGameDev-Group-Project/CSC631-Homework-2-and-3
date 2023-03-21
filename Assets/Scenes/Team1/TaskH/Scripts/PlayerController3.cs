using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    // declare reference variables
    PlayerControls control;
    CharacterController characterController;
    Animator animator;

    // variables to store optimized setter/getter parameters IDs
    int isWalkingHash;
    int isRunningHash;

    // variables to store player input values
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;

    // constants
    float rotationFactorPerFrame = 15.0f;
    float walkMultiplier = 3.0f;
    float runMultiplier = 6.0f;
    //int zero = 0;

    // gravity variables
    float gravity = -9.8f;
    float groundedGravity = -.05f;

    // jump variables
    bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 4.0f;
    float maxJumpTime = 0.75f;
    bool isJumping = false;
    int isJumpingHash;
    bool isJumpAnimating = false;

    // awake is called earlier than start in unity's event life cycle
    void Awake()
    {
        //Debug.Log(UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset.GetType().Name);
        // intially set reference variables
        control = new PlayerControls();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        // set the player input callbacks
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");

        // set the player input callbacks
        control.Player.Move.started += onMovementInput;
        control.Player.Move.canceled += onMovementInput;
        control.Player.Move.performed += onMovementInput;
        control.Player.Run.started += onRun;
        control.Player.Run.canceled += onRun;
        control.Player.Jump.started += onJump;
        control.Player.Jump.canceled += onJump;

        setupJumpVariables();
    }

    void setupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void handleJump()
    {
        if(!isJumping && characterController.isGrounded && isJumpPressed)
        {
            // set animator here
            animator.SetBool(isJumpingHash, true);
            isJumpAnimating = true;
            
            isJumping = true;
            currentMovement.y = initialJumpVelocity * .5f;
            currentRunMovement.y = initialJumpVelocity * .5f;
        }else if (!isJumpPressed && isJumping && characterController.isGrounded)
        {
            isJumping = false;
        }

    }

    void onJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }

    void onRun(InputAction.CallbackContext context) 
    {
        isRunPressed = context.ReadValueAsButton();

    }

    void handleRotation() 
    {
        Vector3 positionToLookAt;
        // the change in position our character should point to
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        // the current rotation of our character
        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            // creates a new rotation based on where the player is currently pressing
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

    }

    void onMovementInput(InputAction.CallbackContext context) 
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * walkMultiplier;
        currentMovement.z = currentMovementInput.y * walkMultiplier;
        currentRunMovement.x = currentMovementInput.x * runMultiplier;
        currentRunMovement.z = currentMovementInput.y * runMultiplier;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }
    void handleAnimation()
    {
        // get parameter values from animator
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        
        // start walking if movement prssed is true
        if(isMovementPressed && !isWalking) 
        {
            animator.SetBool(isWalkingHash, true);
        }
        // stop walking if isMovementPressed is false
        else if(!isMovementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
        // run if movement and run are true
        if((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        // stop running if movement or run pressed are false and currently running
        else if ((!isMovementPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void handleGravity()
    {
        bool isFalling = currentMovement.y <= 0.0f || !isJumpPressed;
        float fallMultiplier = 2.0f;
        // apply proper gravity depending on if the character is grounded or not
        if (characterController.isGrounded)
        {

            // set animator here
            if (isJumping) 
            {
                animator.SetBool(isJumpingHash, false);
                isJumpAnimating = false;
            }
            

            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }else if (isFalling)
        {
            float previousYVelocity = currentMovement.y;
            float newYVelocity = currentMovement.y + (gravity * fallMultiplier * Time.deltaTime);
            //float nextYVelocity = (previousYVelocity + newYVelocity) * .5f; // no limits on fall speed
            float nextYVelocity = Mathf.Max((previousYVelocity + newYVelocity) * .5f, -20.0f); // limit on max fall speed
            currentMovement.y = nextYVelocity;
            currentRunMovement.y = nextYVelocity;
        }
        else
        {
            float previousYVelocity = currentMovement.y;
            float newYVelocity = currentMovement.y + (gravity * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
            currentMovement.y = nextYVelocity;
            currentRunMovement.y = nextYVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        handleRotation();
        handleAnimation();
        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }
        handleGravity();
        handleJump();
    }

    void OnEnable()
    {
        control.Player.Enable();
    }
    void OnDisable()
    {
        control.Player.Disable();
    }
}
