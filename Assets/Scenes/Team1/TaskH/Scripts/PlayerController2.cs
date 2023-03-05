using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    PlayerControls controls;
    Vector2 move;
    public float speed = 10;

    // Awake() is called before Start() method
    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Move.performed += context => move = context.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
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
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed *
        Time.deltaTime;
        transform.Translate(movement, Space.World);
    }


}
