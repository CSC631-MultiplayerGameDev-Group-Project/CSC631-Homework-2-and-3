/// This script changes the GameObject whom it is applied to into a GoldenYellow material.

using System.Collections;
using UnityEngine;
using UnityEditor;

public class ChangeToGoldenYellow : MonoBehaviour
{
    void Start()
    {
    }

    void OnMouseDown()
    {
        Material GoldenYellowMaterial = Resources.Load("Materials/GoldenYellow", typeof(Material)) as Material;
        GetComponent<Renderer>().material = GoldenYellowMaterial;
    }
}