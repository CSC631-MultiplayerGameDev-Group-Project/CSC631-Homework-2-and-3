using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSmoothness : MonoBehaviour
{
    [SerializeField]
    private GameObject thisObject;

    private Renderer objectRender;

    // Start is called before the first frame update
    void Start()
    {
        objectRender = thisObject.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeObjectSmoothness);

    }

    private void ChangeObjectSmoothness() 
    {

        
        if (objectRender != null) 
        {
            if(objectRender.material.GetFloat("_Glossiness") < 1)
                objectRender.material.SetFloat("_Glossiness", 1);
            else
                objectRender.material.SetFloat("_Glossiness", 0);
        }
    }

   
}
