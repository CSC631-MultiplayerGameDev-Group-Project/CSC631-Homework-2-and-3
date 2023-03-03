using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float firRate; 
    // Update is called once per frame
    void Update()
    {
        if(speed != 0){
            transform.position += transform.forward * (speed * Time.deltaTime);
        }else{
            Debug.Log("no Speed!");
        }
        destroyBulletOvertime();
    }

    private void OnCollisionEnter(Collision other) { 
        speed = 0;

        Destroy(gameObject);
    }

    private void destroyBulletOvertime(){
         Destroy(gameObject,5);
    }
}

