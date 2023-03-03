using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    // Tells button what to do when it is clicked
    public void ClickStart() {
        SceneManager.LoadScene("t1-task-Initial");
    }
}