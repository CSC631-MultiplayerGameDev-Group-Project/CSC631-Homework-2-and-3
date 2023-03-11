using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float forwardInput;
    private float horizontalInput;
    public Transform effect;

    // Start is called before the first frame update
    void Start()
    {
        //effect.GetComponent<ParticleSystem> ().enableEmission = false;
        var emission = effect.GetComponent<ParticleSystem>().emission;
        emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get Player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
    }
}
