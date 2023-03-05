using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject muzzle;
    public GameObject hit;

    // Start is called before the first frame update
    void Start()
    {
        if(muzzle != null)
        {
            var muzzleVFX = Instantiate(muzzle, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward * -1;
            var destroyMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
            if(destroyMuzzle != null)
            {
                Destroy(muzzleVFX, destroyMuzzle.main.duration);
            }
            else
            {
                var destroyMuzzleChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, destroyMuzzleChild.main.duration);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        } 
        else
        {
            Debug.Log("Not moving");
        }
    }

    void OnCollisionEnter (Collision co)
    {
        speed = 0;

        ContactPoint contact = co.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(hit != null)
        {
            var hitVFX = Instantiate(hit, pos, rot);
            var destroyHit = hitVFX.GetComponent<ParticleSystem>();
            if (destroyHit != null)
            {
                Destroy(hitVFX, destroyHit.main.duration);
            }
            else
            {
                var destroyHitChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitVFX, destroyHitChild.main.duration);
            }
        }
        Destroy(gameObject);
    }
}
