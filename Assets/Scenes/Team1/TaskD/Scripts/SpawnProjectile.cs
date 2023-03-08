using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> effect = new List<GameObject>();

    private GameObject effectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = effect[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SpawnEffect();
            //Physics.IgnoreCollision(effectToSpawn.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("NoCollision").GetComponent<Collider>());
        }   
    }

    void SpawnEffect()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            //vfx.name = "bullet";
            Quaternion target = firePoint.transform.rotation;
            vfx.transform.rotation = target * Quaternion.AngleAxis(90, Vector3.right);
        }
        else
        {
            Debug.Log("Failed to fire.");
        }
    }
}
