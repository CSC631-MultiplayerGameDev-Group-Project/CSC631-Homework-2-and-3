using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public float maximumLength;
    private Ray rayMouse;
    private Vector3 position;
    private Vector3 direction;
    private Quaternion rotation;
    

    // Update is called once per frame
    void Update()
    {
        if(cam != null){
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay (mousePos);

            if(Physics.Raycast (rayMouse.origin, rayMouse.direction, out hit, maximumLength)){
                RotateToMouseDirection(gameObject, hit.point);
            }
            else{
                var pos = rayMouse.GetPoint(maximumLength);
                RotateToMouseDirection (gameObject, pos);

            }
        }else{
            Debug.Log("No Camera");
        }
        
    }

    void RotateToMouseDirection(GameObject objSphere, Vector3 destination){
        direction = destination - objSphere.transform.position;
        rotation = Quaternion.LookRotation (direction);
        objSphere.transform.localRotation = Quaternion.Lerp (objSphere.transform.rotation, rotation, 1);
    }

    public Quaternion GetRotation(){
        return rotation;
    }
}
