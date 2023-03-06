using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClick_Toggle_Material : MonoBehaviour
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

    private void OnMouseUp()
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
