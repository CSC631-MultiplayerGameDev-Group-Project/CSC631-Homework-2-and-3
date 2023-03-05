using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Change_Camera : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private CinemachineVirtualCamera cinemachine;

    private bool isMain = false;

    void Update()
    {
        if(Input.GetKeyUp(key))
        {
            Change();
        }
    }
    private void Change()
    {
        if(isMain)
        {
            cinemachine.Priority = 1;
        }
        else
        {
            cinemachine.Priority = 3;
        }
        isMain = !isMain;
    }
}
