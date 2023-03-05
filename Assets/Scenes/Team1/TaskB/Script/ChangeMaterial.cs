using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField]
    private GameObject thisObject;

    [SerializeField]
    private Material[] materialList;

    private Renderer objectRender;

    private int randomTextureIndex;
    // Start is called before the first frame update
    void Start()
    {
        objectRender = thisObject.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeGameMaterial);
    }
    private void ChangeGameMaterial() 
    {
        randomTextureIndex = Random.Range(0, materialList.Length);
        objectRender.material = materialList[randomTextureIndex];
    }
   
}
