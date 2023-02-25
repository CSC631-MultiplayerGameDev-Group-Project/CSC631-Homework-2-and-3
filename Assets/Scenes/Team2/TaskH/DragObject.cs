using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    
    private float CameraZDistance;
    private void OnMouseDown(){
    
        //Takes z value of game object from camera. converts from world points to screen points.
        CameraZDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseDrag() {
        
        // New Vector with mouse(x,y) position takes z position from camera. Will keep same distance from camera.
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance);

        // Takes screen position of object converts from screen points to world points.
        Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //new position added game object script is attached to.
        transform.position = newWorldPosition;
    } 

    //Refrence How To Move Objects With Mouse Drag in Unity | Unity 3D Tutorial
    //Explanation as i understand it.
}
