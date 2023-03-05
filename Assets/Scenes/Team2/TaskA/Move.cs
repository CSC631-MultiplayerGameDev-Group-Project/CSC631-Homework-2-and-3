using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;

    private int t;

    private void FixedUpdate()
    {
        transform.position = transform.up + transform.forward +
            transform.right * Mathf.Sin(Time.frameCount * speed * Time.deltaTime);
    }
}
