using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public GameObject cameraBehind;
    public GameObject cameraAbove;
    public GameObject mainCamera;

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
        if (Input.GetButtonDown("CameraDefault"))
        {
            mainCamera.SetActive(true);
            cameraAbove.SetActive(false);
            cameraBehind.SetActive(false);
        }
    }
}
