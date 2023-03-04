/// This scripts allows the game object that it is applied onto
/// to change between two chosen materials. THe materials must
/// be manually set in the scene.

using System.Collections;
using UnityEngine;

public class ToggleMaterial : MonoBehaviour
{
// put the first material here.
    public Material material1;

// put the second material here.
    public Material material2;
    bool FirstMaterial = true;
    bool SecondndMaterial = false;

    void Start()
    {
        GetComponent<Renderer>().material = material1;
    }

    void OnMouseDown()
    {
        if (FirstMaterial)
        {
            GetComponent<Renderer>().material = material2;
            SecondndMaterial = true;
            FirstMaterial = false;
        }
        else if (SecondndMaterial)
        {
            GetComponent<Renderer>().material = material1;
            FirstMaterial = true;
            SecondndMaterial = false;
        }
    }
}