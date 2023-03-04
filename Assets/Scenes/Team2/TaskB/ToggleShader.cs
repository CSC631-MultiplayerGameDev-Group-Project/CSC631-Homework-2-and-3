/// This scripts toggles between Diffuse and Transparent/Diffuse shaders
/// when space key is pressed
/// source: https://docs.unity3d.com/ScriptReference/Material-shader.html

using UnityEngine;

public class Example : MonoBehaviour
{

    Shader shader1;
    Shader shader2;
    Renderer rend;


    void Start()
    {
        rend = GetComponent<Renderer> ();
        shader1 = Shader.Find("Diffuse");
        shader2 = Shader.Find("Transparent/Diffuse");
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (rend.material.shader == shader1)
            {
                rend.material.shader = shader2;
            }
            else
            {
                rend.material.shader = shader1;
            }
        }
    }
}