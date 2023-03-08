using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject character;

    PlayerControls control;

    private Transform PickUpPoint;
    private Transform Player;

    private Rigidbody rb;
    private Renderer rend;
    private Collider collision;

    private float pickUpDistance;
    private bool itemIsPickedUp;

    void Awake()
    {
        control = new PlayerControls();
        control.Player.PickUp.Enable();
        control.Player.Drop.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        collision = GetComponent<Collider>();
        Player = character.transform;
        // get's the 1st child of character gameObject and gets transform
        PickUpPoint = character.transform.GetChild(0).gameObject.transform;
        //Debug.Log("name of Player is " + Player.name + "name of PickUpPoint is " + PickUpPoint.name);

    }

    private void PickUpObject()
    {
        bool pressedPickUp = control.Player.PickUp.IsPressed();

        pickUpDistance = Vector3.Distance(Player.position, transform.position);

        if (pickUpDistance <= 2)
        {

            if ((pressedPickUp) && (itemIsPickedUp == false) && (PickUpPoint.childCount < 1))
            {
                //rend.enabled = false; // visibility of gameObjects getting picked up
                rb.isKinematic = true; // ignore physics
                rb.useGravity = false; // gravity for gameObjects getting picked up
                collision.enabled = false; // collider for gameObjects getting picked up
                this.transform.position = PickUpPoint.position;
                this.transform.parent = PickUpPoint;
                //Debug.Log("transform position is now " + this.transform.position + " and the parent is now " + this.transform.parent);
                itemIsPickedUp = true;
            }
        }
    }

    private void DropObject()
    {
        bool pressedDrop = control.Player.Drop.IsPressed();

        pickUpDistance = Vector3.Distance(Player.position, transform.position);

        if (pickUpDistance <= 2)
        {

            if ((pressedDrop) &&  (PickUpPoint.childCount >= 1))
            {
                //Debug.Log("pressedPickUp is " + pressedPickUp);
                //rend.enabled = true; // visibility of gameObjects getting picked up
                rb.isKinematic = false; // re-enable physics
                rb.useGravity = true; // gravity for gameObjects getting picked up
                collision.enabled = true;  // collider for gameObjects getting picked up
                this.transform.position = PickUpPoint.position;
                this.transform.parent = null;

                itemIsPickedUp = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PickUpObject();
        DropObject();
    }
}
