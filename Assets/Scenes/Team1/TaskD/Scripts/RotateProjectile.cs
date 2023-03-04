using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateProjectile : MonoBehaviour
{

    public Camera cam;
    public float max;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if(Physics.Raycast (rayMouse.origin, rayMouse.direction, out hit, max))
            {
                rotateToMouse(gameObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(max);
                rotateToMouse(gameObject, hit.point);
            }
        }
        else
        {
            Debug.Log("No camera");
        }
        
    }

    void rotateToMouse (GameObject obj, Vector3 destination)
    {

        direction = destination - obj.transform.position;
        
        rotation = Quaternion.LookRotation(direction);;
        rotation = rotation * Quaternion.AngleAxis(180, Vector3.right);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);

    }
}
