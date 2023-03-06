using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class On_Collision_Do_Things : MonoBehaviour
{
    [SerializeField] private Material newMat;
    private Material oldMat;

    private MeshRenderer meshRenderer;
    private bool isOld;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        oldMat = meshRenderer.material;
        isOld = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        if (isOld)
        {
            meshRenderer.material = newMat;
        }
        else
        {
            meshRenderer.material = oldMat;
        }

        isOld = !isOld;
    }
}
