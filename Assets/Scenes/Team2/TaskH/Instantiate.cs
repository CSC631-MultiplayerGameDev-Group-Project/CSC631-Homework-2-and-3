using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Script clones prefab on keyboard press 'k'.
script must be added an empty game object to be instantiated.
clones will be added to coordinate (0,0,0).
*/
public class Instantiate : MonoBehaviour
{
    public GameObject instantiatedObject;  
    void Update()
    {
        // on keypress k create object.
        if(Input.GetKeyDown(KeyCode.K)){
            Instantiate(instantiatedObject); //creates clone of prefab object.
        }
    }
}
