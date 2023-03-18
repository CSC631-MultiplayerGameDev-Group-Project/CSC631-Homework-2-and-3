using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    PlayerControls controls;
    Vector2 move;
    public float speed = 1.68f;
    private Rigidbody rb;
    public float gravityScale = 1.44f;
    public float customDragFactor = 6;
    public float jumpForce = 10;

    public float jumpTime;
    public float airTime = 0.5f;
    private Vector3 sizeCollider;
    private bool didJump = false;
    // Awake() is called before Start() method
    void Awake()
    {
        controls = new PlayerControls();
        //controls.Player.Move.performed += context => move = context.ReadValue<Vector2>();
        //controls.Player.Move.canceled += ctx => move = Vector2.zero;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        //sizeCollider = GetComponent<Collider>().bounds.size;
        

    }

    private void OnMoveEnable() 
    {
        controls.Player.Move.performed += context => 
        {
            move = context.ReadValue<Vector2>();
        };
        controls.Player.Move.canceled += ctx =>
        {
            //rb.velocity = Vector2.zero;
            move = Vector2.zero;
        };
    }

    private void MoveUpdateCheck() 
    {
        Vector3 movement2 = new Vector3(move.x, 0.0f, move.y) * speed; //trying to add gravity feel
        rb.AddForce(movement2, ForceMode.VelocityChange); // rigidbody movement method that relies on drag and mass (feels slow to start & stop)
    }

    private void OnJumpEnable() 
    {
        //controls.Player.Jump.started += context => jumpForce = 1;
        controls.Player.Jump.performed += context => jumpFull(); //this happens when jump is pressed

        controls.Player.Jump.canceled += jumpCancel; // this happens when jump is released

            //rb.AddForce(Vector3.up * Physics.gravity.y * (gravityScale - 1));
        
    }
    private void jumpFull() 
    {
        if (IsGrounded()) { //problem when jump is held, floaty, gravity force isn't applied until releasing jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            didJump = true;
             }
            //rb.AddRelativeForce(Vector3.down * jumpForce*(float)context.duration, ForceMode.Impulse);
        /* if (rb.velocity.y < 0.0f)
         {
             Debug.Log("does this ever occur? in velocity check  ");
             rb.AddForce(Vector3.up * Physics.gravity.y * (gravityScale - 1));
         }*/



        /*jumpTime += Time.deltaTime;
        if(jumpTime > airTime) { rb.AddForce(Vector3.up * Physics.gravity.y * (gravityScale - 1)); }*/

        //Debug.Log("jump occured is " + context.ToString() + "\n jump time is " + jumpTime);
    }

    private void jumpCancel(InputAction.CallbackContext context) 
    {
        //rb.AddForce(Vector3.up * Physics.gravity.y * (gravityScale - 1));
        //jumpTime = 0;
        /*var j = context.duration;
        if (j > 1)
        {
            j = 0; 
        }
        rb.AddForce(Vector3.up * ((float)j * jumpForce), ForceMode.Impulse);*/
        
        //Debug.Log("jump duration above 0 velocity in y is " + context.ToString());
    }

    private bool IsGrounded() 
    {
        //Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        //if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        if(Physics.Raycast(this.transform.position + Vector3.up * 0.25f, Vector3.down, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }
    //private void OnMoveDisable() {    }

    private void OnEnable()
    {
        controls.Player.Enable();
        OnMoveEnable();
        OnJumpEnable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
    void SendMessage(Vector2 coordinates)
    {
        Debug.Log("Button Pressed, coordinates = " + coordinates);
    }

    void FixedUpdate()
    {
        //Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
        //transform.Translate(movement, Space.World); // transform method otherwise use one below for rigidbody method
        //rb.MovePosition(transform.position + movement); // rigidbody method for movement movePosition

        MoveUpdateCheck();
        rb.AddForce( -(rb.velocity.x * customDragFactor), 0, -(rb.velocity.z * customDragFactor))  ;
        if (!IsGrounded()) {
            rb.AddForce(0, Physics.gravity.y * (gravityScale - 1), 0);
        }
        /*if ( didJump && (rb.velocity.y < 0.0f) )
        {
            Debug.Log("does this ever occur? in velocity check  ");
            rb.AddForce(Vector3.down * Physics.gravity.y * (gravityScale - 1));
        } 
        if (IsGrounded()) { didJump = false;}*/
        //Debug.Log(IsGrounded());

        //rb.AddForce(Vector3.up * Physics.gravity.y * (gravityScale - 1) );
        //Vector3 movement1 = new Vector3(move.x, 0.0f, move.y) * speed; //just movement, no jump
        //Vector3 movement2 = new Vector3(move.x, 0.0f , move.y) * speed; //trying to add gravity feel
        //rb.AddForce(movement2, ForceMode.VelocityChange); // rigidbody movement method that relies on drag and mass (feels slow to start & stop)
        //rb.velocity = movement1; // rigidbody velocity ignores physics
    }


}
