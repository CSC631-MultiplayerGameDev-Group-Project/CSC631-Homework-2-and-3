using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject cameraBehind;
    public GameObject cameraAbove;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("CameraBehind"))
        {
            cameraBehind.SetActive(true);
            cameraAbove.SetActive(false);
        }
        if (Input.GetButtonDown("CameraAbove"))
        {
            cameraAbove.SetActive(true);
            cameraBehind.SetActive(false);
        }
    }
}
