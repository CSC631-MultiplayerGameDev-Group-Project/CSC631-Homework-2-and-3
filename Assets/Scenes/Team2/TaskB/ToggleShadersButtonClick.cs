/// This scripts toggles between Diffuse and Transparent/Diffuse shaders
/// when clicking on the Game Object upon it is applied

using UnityEngine;

public class ToggleShadersButtonClick : MonoBehaviour
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

    void OnMouseDown()
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