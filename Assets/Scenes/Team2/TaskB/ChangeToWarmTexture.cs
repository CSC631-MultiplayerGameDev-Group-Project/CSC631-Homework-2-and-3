/// This script changes the GameObject whom it is applied to into a warm material.

using System.Collections;
using UnityEngine;
using UnityEditor;

public class ChangeToWarmMaterial : MonoBehaviour
{
    void Start()
    {
    }

    void OnMouseDown()
    {
        Material warmMaterial = Resources.Load("Materials/Warm", typeof(Material)) as Material;
        GetComponent<Renderer>().material = warmMaterial;
    }
}