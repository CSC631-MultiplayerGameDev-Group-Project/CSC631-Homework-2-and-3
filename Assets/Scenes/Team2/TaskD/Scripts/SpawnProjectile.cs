using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject> ();
    public RotateToMouse rotateToMouse;
    private GameObject effectToSpawn;
    
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown (0)){
            
            SpawnVFX();
        }
    }

    void SpawnVFX(){
    
        GameObject vfx;
        
        if(firePoint != null){
            vfx = Instantiate (effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if(rotateToMouse != null){
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else{
            Debug.Log("no fire point.");
        }
    }
}

