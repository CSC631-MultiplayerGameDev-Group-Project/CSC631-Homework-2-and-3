using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;

public class Change_Material : MonoBehaviour
{
    [SerializeField] private Material mat;
    [SerializeField] private List<MeshRenderer> renderers;

    public void change()
    {
        foreach(var renderer in renderers)
        {
            renderer.material = mat;
        }
    }
}
